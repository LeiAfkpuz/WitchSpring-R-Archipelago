import asyncio
import json
from pathlib import Path
from NetUtils import ClientStatus
from CommonClient import CommonContext, server_loop, gui_enabled, get_base_parser, logger

GAME_NAME = "Witchspring R"

def get_game_install_dir() -> "Path | None":
    """The WitchSpring R install folder, from host.yaml (witchspringrap_options -> game_path)."""
    from .world import WSRWorld
    try:
        game_dir = Path(str(WSRWorld.settings.game_path))
    except Exception:
        return None
    if not game_dir.is_dir():
        return None
    return game_dir

class WSRContext(CommonContext):
    game = GAME_NAME
    items_handling = 0b111 # receive local + remote + starting items

    def __init__(self, server_address, password):
        super().__init__(server_address, password)
        self.wsr_seed_name = "UnknownSeed"
        self.received_item_count = 0
        self.goal_choice = 2
        self.bridge_ready = False
        self.bridge_root = None
        self.bridge_dir = None
        self.bridge_loop_task = None

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
            self.goal_choice = int(args.get("slot_data", {}).get("goal_choice", 2))
            if self.setup_bridge():
                self.write_received_items()
                if self.bridge_loop_task is None or self.bridge_loop_task.done():
                    self.bridge_loop_task = asyncio.create_task(self.check_bridge_loop())

        elif cmd == "ReceivedItems":
            if self.bridge_ready:
                self.write_received_items()
            asyncio.create_task(self.check_goal())

    def setup_bridge(self) -> bool:
        game_dir = get_game_install_dir()

        if game_dir is None:
            logger.error(
                "WitchSpring R install folder not found. Open your Archipelago host.yaml, set "
                "'game_path' under 'witchspringrap_options' to the folder containing the game "
                "(the one with the BepInEx folder in it), then reconnect to your slot."
            )
            self.bridge_ready = False
            return False

        self.bridge_root = game_dir / "Archipelago"
        self.bridge_dir = self.bridge_root / "Sessions" / self.get_session_dir_name()
        self.update_bridge_paths()
        self.write_active_session_file()
        self.reset_bridge_if_new_session()
        self.bridge_ready = True
        logger.info(f"[WSRBridge] Bridge folder: {self.bridge_dir}")
        return True

    def get_session_dir_name(self) -> str:
        safe_seed = "".join(c if c.isalnum() or c in "-_." else "_" for c in str(self.wsr_seed_name))
        safe_slot_name = "".join(c if c.isalnum() or c in "-_." else "_" for c in str(self.auth))

        return f"{safe_seed}__team{self.team}__slot{self.slot}__{safe_slot_name}"

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
        active_session_file = self.bridge_root / "active_session.json"
        active_session_file.parent.mkdir(parents=True, exist_ok=True)

        active_session = {
            # The plugin joins session_dir onto its own <game>/Archipelago/Sessions root,
            # so this file never needs to carry an absolute path between the two sides.
            "session_dir": self.bridge_dir.name,
            "bridge_dir": str(self.bridge_dir),
            "seed_name": str(self.seed_name),
            "slot_name": str(self.auth),
            "team": int(self.team),
            "slot": int(self.slot),
        }

        active_session_file.write_text(
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

            for entry in location_names:
                if isinstance(entry, int):
                    location_id = entry
                else:
                    print(f"Skipping non-ID location for now: {entry}")
                    continue
                if location_id not in self.locations_checked and location_id not in self.checked_locations:
                    location_ids.append(location_id)

            if location_ids:
                # checked_locations.json is a permanent ledger - the game plugin only
                # ever adds to it and we never clear it, so a check written there can
                # survive a game crash, a client crash, or both. The server ignores
                # duplicate checks, and CommonContext resends locations_checked after
                # a reconnect, so over-sending is always safe.
                self.locations_checked.update(location_ids)
                await self.send_msgs([{
                    "cmd": "LocationChecks",
                    "locations": list(self.locations_checked),
                }])

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