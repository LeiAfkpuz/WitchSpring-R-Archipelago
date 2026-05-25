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