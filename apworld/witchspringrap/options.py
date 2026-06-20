from dataclasses import dataclass
from Options import Choice, OptionGroup, PerGameCommonOptions, Range, Toggle

class GoalChoice(Choice):
    """
    Choose which Chapter will be your end point. Will update in the future for Jude boss goal.

    ***Chapter 2 is the most stable, with 3 being pretty stable. While the others should function properly, they are untested as of this moment and therefore not recommended!***

    ex: 2 goal will have you play through chapter 1 then goal upon reaching chapter 2
    4 goal will have you play through chapters 1, 2, 3 and goal upon reaching chapter 4.
    """
    display_name = "Goal"
    option_chapter_2 = 2
    option_chapter_3 = 3
    option_chapter_4 = 4
    option_chapter_5 = 5
    option_chapter_6 = 6
    option_chapter_7 = 7
    option_chapter_9 = 9
    default = 2

class Battlesanity(Toggle):
    """
    Adds a check for clearing each field battle (every set of field enemies). This adds a
    large number of locations - each battle becomes a check the first time you win it.

    Story/boss battles triggered by events are not included.
    """
    display_name = "Battlesanity"
    default = 0

class Bestiary(Toggle):
    """
    Adds a check for defeating each enemy in the game's bestiary (one per unique enemy;
    any rank/shield variant counts). Like Battlesanity, this adds many locations.
    """
    display_name = "Bestiary"
    default = 0

class QuestSanity(Toggle):
    """
    Adds a check for completing each quest (main story quests and request-board quests).
    Like Battlesanity/Bestiary, this adds many locations. (Chapter 9 quests are deferred
    until an end-game goal exists.)
    """
    display_name = "QuestSanity"
    default = 0