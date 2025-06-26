-A boss rush prototype game similar to an already existing one
(Hollow Knight) where the player can choose items, a game mode
and a boss to fight from the menu.

Assets/Scripts/PlayTest Scene Scripts - this is where most of the code is at.



Currently has 2 game modes:

1. Classic - same controls and abilities as in the original Hollow Knight

-jump, double jump, wall slide, wall jump, dash
-3 spells from the original
-12 items (charms) to choose from in the menu before the boss


2. Ultimate - a couple of additional movement abilities

-everything in classic + fast fall, spot dodge, air dodge, roll
-3 spells from the original
-12 new items (charms) to choose from in the menu before the boss

Currently has 1 boss with 4 phases and 10 attacks.

Currently has 3 arenas.

Has an input buffer system for better user experience
(for example, if the player presses the attack button twice in quick
succession, even though the attack was on cooldown when the attack
button was pressed the second time, the player will still perform
the attack exactly when the attack cooldown is over, because of the
buffer system, instead of the second attack never happening).



What I learned from this passion project:

-Working with a menu/graphic user interface, animations, physics
-Refactoring code, writing scalable, consistent and readable code that has just the right amount of abstraction
-How to plan my ideas, functionalities and mechanics before actually implementing them
-Debugging, having a better feel for avoiding code that would cause hard to debug problems later down the line.
-Thinking about the user experience - input buffer system for making the game feel more fluid, 
the player has a slightly smaller hitbox then the sprite so that it doesn't feel like they took unfair damage,
after walking off a ledge, there's still a couple of frames when the player can jump, 
in order to not frustrate the player if they just barely missed the timing
-Planning how certain systems will work and designing them - the hitbox system, the boss (enemy) attack system,
the player state system, the input buffering system, the item system.
-Better understanding the trade off between readability, memory efficiency, development time and scalability


Note: This project was committed all at once after development had already started, 
as I didn't know how to use Git from the beginning. Version history is limited in early stages.