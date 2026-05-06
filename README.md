# Running we go!
**Run, survive and try to escape the horrors that await in this cave!**

## Overview
Running we go is an endeless runner where the player needs to survive as long as possible. The player will encounter enemies and obstacles that will try to stop them from escaping, but they have a secret ability...  
#### **The player can change between running on the ground or on the cave's ceiling**.  
That is right! The player can decide whether to run on the floor or the ceiling so they can try dodging enemies, obstacles, collecting gems and running as far as possible. 

## Development 
The game was developed inside Unity by me, Claudia Rodriguez. It was programmed using C# and JetBrains Raiders. All art assets (sprites, fonts, sound) are from third parties and free to use.

Controls:
  - Movement : *AD or Left / Right arrows*
  - Jump between ground and ceiling : *R*
  - Jumping: *W or Up arrow*
  - Pause: *Esc*

## Game Features - Programming wise
- *Generic pool system:* Used for enemies, map, VFX, pick-ups pool creation. 
- *Scriptable Objects:* SO used to set pools and spawners, creating cleaner code and ease changes.
- *HUD:* Used to track score, lives and pickups. Uses a UI reference script of type singelton to set references and a UI updator that using the set references updates the game. 
- *Player Inventory:* Tracks pick-ups.
- *Difficulty controlled by a costumizable curve:* The speed for enemies and map movement is set through a curve allowing smooth and controlled movement, in addition allowing to easily change the level difficulty, speed, and time to reach max. speed. 
- *Game/Audio/UI Managers:* Created using a Singleton pattern, used to get references and set general aspects such as pools and spawners.

## How to run the game
The user just needs to run the scene called "Menu". No further set up is needed. 
Additionally, game can be played online on itch.io : 
