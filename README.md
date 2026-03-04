# ** Warning: Game is a work in progress! **

# Running we go!
**Run, survive and try to escape the horrors that await in this cave!**

## Overview
Running we go is an endeless runner where the player needs to survive as long as possible. The player will encounter strange enemies and obstacles that will try to stop them from escaping, but they have a secret ability...  
#### **The player can change between running on the ground or on the cave's ceiling**.  
That is right! The player can decide whether to run on the floor or the ceiling so they can try dodging enemies, obstacles, collecting gems and running as far as possible. 

## Development 
The game was developed inside Unity by me, Claudia Rodriguez. It was programmed using C# and JetBrains Raiders. All art assets are from third parties and are free to use. While the game is a WIP, the 
core mechanics can be tested inside the game. The user can load the scene called "Endless Runner" and test the game.

Controls:
  - Movement : *AD or Left / Right arrows*
  - Jump between ground and ceiling : *R*
  - Jumping: *W or Up arrow*
  - Pause: *Esc*

## Game Features
- *Generic pool system:* Used for enemies, map, VFX, pick-ups pool creation. 
- *Scriptable Objects:* SO used to set pools and spawners, creating cleaner code and ease changes.
- *HUD:* Used to track score, lives and pickups.
- *Player Inventory:* Tracks pick-ups.
- *Game Manager:* Created using a Singleton pattern, used to get references and set general aspects such as pools and spawners.
