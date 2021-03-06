- [EECS290FinalProject](#eecs290finalproject)
  - [Game Design Document outline](#game-design-document-outline)
    - [Game Title](#game-title)
    - [Game Genre](#game-genre)
    - [Premise/Narrative/Story](#premisenarrativestory)
    - [Player's Role and Game Goal (How do you beat the game?)](#players-role-and-game-goal-how-do-you-beat-the-game)
    - [Gameplay/Mechanics (What abilities, activities, puzzles must be solved?)](#gameplaymechanics-what-abilities-activities-puzzles-must-be-solved)
    - [Scoring or other feedback  (How is player progress and performance quantified?)](#scoring-or-other-feedback-how-is-player-progress-and-performance-quantified)
    - [Writing/Art/Music style (What perspective, ambiance, or time period is conveyed?)](#writingartmusic-style-what-perspective-ambiance-or-time-period-is-conveyed)
    - [Innovation (What is unique about the design or implementation?)](#innovation-what-is-unique-about-the-design-or-implementation)
    - [Team Member Roles (Division of labor, timelines?) TENTATIVE](#team-member-roles-division-of-labor-timelines-tentative)
    - [Stages](#stages)

# EECS290FinalProject: Butter 'em Up!
Final Project for the intro to game design class at CWRU

Cameron: “I’m constitutionally required to defend bread to my last breath.”

Zubair: “Then you can create all the enemies!”


## Game Design Document outline
Game Title 
-----
Butter 'Em Up!

Game Genre
--
Dungeon crawler

Premise/Narrative/Story
--
Bread and Spread have always been on friendly terms, but in the face of gluten-free alternatives, they want to merge. Crown Princess de Pâques of the Kingdom of Bread’s royal family, the Couronnes, was set to marry Prince Nova Lox, Crown Prince of the Kingdom of Spread. The wedding was beautiful, but the day after, Princess de Pâques awoke stale. The Baguette Guard too has come down with a strange affliction. They’re attacking… spread?

You have been called to retrieve the essential parts of the mythical Wash of Sweetness required to save her. The only problem? It seems that all of Bread has been affected by the curse laid upon Princess de Pâques and the recipe for the Wash of Sweetness is lost to time.

Player's Role and Game Goal (How do you beat the game?)
--
The player is a minor noble of The Kingdom of Spread. The player can pick from a list of titles and 2 or 3 player sprites.

The goal of the game is to collect the components of the Wash of Sweetness.

Gameplay/Mechanics (What abilities, activities, puzzles must be solved?)
--
The player's attacks are different kinds of spreads. Each attack "saves" bread from the curse, recruiting them to the player's team.

The more people the player saves from the curse, the stronger they become. As the player gets stronger, they get access to different spreads.

As the player completes levels, they receive components of the Wash of Sweetness.

Scoring or other feedback  (How is player progress and performance quantified?)
-- 
2 ways to score :
- The number of key items (recipe parts, egg, milk and butter) that you have collected. This is the main progression of the game.
- We will track the number of bread killed versus befriended internally and provide feedback at certain (TBD) intervals.

Writing/Art/Music style (What perspective, ambiance, or time period is conveyed?)
--
Medieval-ish style of writing and music. Comedic aspect too. Art style: paper drawn.

Innovation (What is unique about the design or implementation?)
--
The fact that you can befriend your enemies.

Team Member Roles (Division of labor, timelines?) TENTATIVE
--
Cameron: Sprites + Art

Zubair: Level Design (Lead) + Storyline

Mira: Storyline (Lead) + Level Design

Kegan: Music research

Stages
--
Stage premise: the final boss of each world points to the next
    BIG RECIPE:
    Preheat oven to 350
    Beat Eggs
    Combine all ingredients
    Dip bread in mix
    Place prepared bread on cookie sheet
    Cook till golden brown

### The Castle
- Starting weapon:
  - Margarine
- Drops:
  - World Map
  - Key to Castle, "recipe needs 1 cup of fresh milk"
-Boss:
  - Head Guard

### Aisle 1: Dairy
- Acquired Weapons (dairy-based):
  - Cream Cheese
  - Butter
  - Condensed Milk
- Drops:
  - "Combine in large bowl"
  - "Preheat oven"
  - "6 tbsp of sugar" + 1 cup of fresh milk (boss drop)
-Boss:
  - Undecided
  
### Aisle 2: Sugar
- Acquired Weapons (sweet):
  - Jams/Jellies
  - Preserves
  - Nut Spreads
- Drops
  - "350 degrees"
  - "Place prepared bread on cookie sheet"
  - "3 Eggs" + 6 tbsp of sugar

### Aisle 3: Eggs
- Acquired Weapons (non-traditional spreads):
  - Undetermined
- Drops:
  - "Dip bread in mix"
  - "Beat eggs thoroughly"
  - "Bake until Golden Brown" + 3 Eggs
