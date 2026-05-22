import asyncio
import json
from pathlib import Path
from NetUtils import ClientStatus
from CommonClient import CommonContext, server_loop, gui_enabled, get_base_parser
import os

GAME_NAME = "Witchspring R"
BRIDGE_DIR = Path(os.getenv("LOCALAPPDATA", Path.home())) / "Archipelago" / "WitchspringR" / "Bridge"
RECEIVED_ITEMS_FILE = BRIDGE_DIR / "received_items.json"
CHECKED_LOCATIONS_FILE = BRIDGE_DIR / "checked_locations.json"
SESSION_FILE = BRIDGE_DIR / "bridge_session.json"
PROCESSED_INDEX_FILE = BRIDGE_DIR / "processed_received_index.txt"
ACTIVE_SESSION_FILE = (Path(os.getenv("LOCALAPPDATA", Path.home())) / "Archipelago" / "WitchspringR" / "active_session.json")

class WSRContext(CommonContext):
    game = GAME_NAME
    items_handling = 0b111 # receive local + remote + starting items

    def __init__(self, server_address, password):
        super().__init__(server_address, password)
        self.wsr_seed_name = "UnknownSeed"
        self.received_item_count = 0
        BRIDGE_DIR.mkdir(parents=True, exist_ok=True)
        self.goal_choice = 2

    async def server_auth(self, password_requested: bool = False):
        if password_requested and not self.password:
            await super().server_auth(password_requested)
            return
        
        await self.get_username()
        await self.send_connect()

    def on_package(self, cmd: str, args: dict):
        super().on_package(cmd, args)

        if cmd == "RoomInfo":
            self.wsr_seed_name = str(args.get("seed_name", "Unknown Seed"))

        if cmd == "Connected":
            self.bridge_dir = self.get_session_bridge_dir()
            self.update_bridge_paths()
            self.write_active_session_file()
            self.goal_choice = int(args.get("slot_data", {}).get("goal_choice", 2))
            self.reset_bridge_if_new_session()
            self.write_received_items()
            #self.set_notify(self.checked_locations)
            asyncio.create_task(self.check_bridge_loop())
            

        elif cmd == "ReceivedItems":
            self.write_received_items()
            asyncio.create_task(self.check_goal())
        
    def get_session_bridge_dir(self):
        safe_seed = "".join(c if c.isalnum() or c in "-_." else "_" for c in str(self.wsr_seed_name))
        safe_slot_name = "".join(c if c.isalnum() or c in "-_." else "_" for c in str(self.auth))

        session_id = f"{safe_seed}__team{self.team}__slot{self.slot}__{safe_slot_name}"

        return (
            Path(os.getenv("LOCALAPPDATA", Path.home()))
            / "Archipelago"
            / "WitchspringR"
            / "Sessions"
            / session_id
        )

    def write_received_items(self):
        items = []

        for index, network_item in enumerate(self.items_received):
            item_name = self.item_names.lookup_in_game(network_item.item)
            location_name = self.location_names.lookup_in_game(network_item.location)
            player_name = self.player_names.get(network_item.player, f"Player {network_item.player}")
            
            items.append({
                "index": index,
                "item": item_name,
                "location": location_name,
                "player": player_name,
            })

        self.received_items_file.write_text(
            json.dumps(items, indent=2),
            encoding="utf-8"
        )
        
    def write_active_session_file(self):
        ACTIVE_SESSION_FILE.parent.mkdir(parents=True, exist_ok=True)

        active_session = {
            "bridge_dir": str(self.bridge_dir),
            "seed_name": str(self.seed_name),
            "slot_name": str(self.auth),
            "team": int(self.team),
            "slot": int(self.slot),
        }

        ACTIVE_SESSION_FILE.write_text(
            json.dumps(active_session, indent=2),
            encoding="utf-8"
        )

    async def check_goal(self):
        for network_item in self.items_received:
            item_name = self.item_names.lookup_in_game(network_item.item)

            if item_name == f"Chapter {self.goal_choice}":
                await self.send_msgs([{
                    "cmd": "StatusUpdate",
                    "status": ClientStatus.CLIENT_GOAL
                }])
                return

    async def check_bridge_loop(self):
        while not self.exit_event.is_set():
            await asyncio.sleep(1)

            if not self.checked_locations_file.exists():
                continue

            try:
                data = json.loads(self.checked_locations_file.read_text(encoding="utf-8"))
            except Exception:
                continue

            location_names = data.get("checked_locations", [])
            location_ids = []

            #for name in location_names:
            #    location_id = self.location_names.lookup_name_to_id.get(name)
            #    if location_id is not None and location_id not in self.checked_locations:
            #        location_ids.append(location_id)
            #for name in location_names:
            #    try:
            #        location_id = self.location_names[name]
            #    except KeyError:
            #        print(f"Unknown location name in checked_locations.json: {name}")
            #        continue

            #    if location_id not in self.locations_checked:
            #        location_ids.append(location_id)
            for entry in location_names:
                if isinstance(entry, int):
                    location_id = entry
                else:
                    print(f"Skipping non-ID location for now: {entry}")
                    continue
                if location_id not in self.locations_checked:
                    location_ids.append(location_id)


            if location_ids:
                await self.send_msgs([{
                    "cmd": "LocationChecks",
                    "locations": location_ids,
                }])
                self.checked_locations_file.write_text(
                    json.dumps({"checked_locations": []}, indent=2),
                    encoding="utf-8"
                )

                self.checked_locations.update(location_ids)

    import json
    def reset_bridge_if_new_session(self):
        self.bridge_dir.mkdir(parents=True, exist_ok=True)

        current_session = {
            "seed_name": str(self.seed_name),
            "slot_name": str(self.auth),
            "team": int(self.team),
            "slot": int(self.slot),
        }

        old_session = None

        if self.session_file.exists():
            try:
                old_session = json.loads(self.session_file.read_text(encoding="utf-8"))
            except Exception:
                old_session = None

        if old_session != current_session:
            print("[WSRBridge] New AP session detected. Resetting bridge files.")

            for path in [
                self.checked_locations_file,
                self.received_items_file,
                self.processed_index_file,
            ]:
                if path.exists():
                    path.unlink()

            self.session_file.write_text(
                json.dumps(current_session, indent=2),
                encoding="utf-8"
            )
        else:
            print("[WSRBridge] Same AP session detected. Keeping bridge files.")

    def update_bridge_paths(self):
        self.bridge_dir.mkdir(parents=True, exist_ok=True)

        self.received_items_file = self.bridge_dir / "received_items.json"
        self.checked_locations_file = self.bridge_dir / "checked_locations.json"
        self.session_file = self.bridge_dir / "bridge_session.json"
        self.processed_index_file = self.bridge_dir / "processed_received_index.txt"
    
async def main():
        parser = get_base_parser()
        args = parser.parse_args()

        ctx = WSRContext(args.connect, args.password)
        ctx.server_task = asyncio.create_task(server_loop(ctx), name="server loop")

        if gui_enabled:
            ctx.run_gui()
        ctx.run_cli()

        await ctx.exit_event.wait()
        ctx.server_address = None
        await ctx.shutdown()

if __name__ == "__main__":
        asyncio.run(main())