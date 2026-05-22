from dataclasses import dataclass
from typing import TYPE_CHECKING

@dataclass
class WSREventGate:
    scene: str
    game_id: str
    method_index: int
    required_item: str
    message: str = ""

event_gates = [
    WSREventGate(
        scene="Forest_BlackWitch",
        game_id="event_13",
        method_index=10,
        required_item="Mind Control Circle",
        message="You need Mind Control to continue",
    ),

]