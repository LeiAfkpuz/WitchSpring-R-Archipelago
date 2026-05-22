from .world import WSRWorld as WSRWorld

def launch_client(*args):
    import asyncio
    from .WSRClient import main
    asyncio.run(main())

try:
    from worlds.LauncherComponents import Component, Type, components, launch_subprocess

    components.append(Component(
        "Witchspring R Client",
        component_type=Type.CLIENT,
        func=lambda *args: launch_subprocess(launch_client, name="Witchspring R Client", args=args),
        game_name="Witchspring R",
        supports_uri=True,
    ))
except Exception:
    pass
