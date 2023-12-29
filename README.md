# Pixel Hero 2D

### Project Description
Pixel Hero 2D is a 2D game prototype developed as part of the technical test approved in Module 5 (M5P1). This project has allowed me to learn about creating animations, managing states, item collection, and implementing a system for unlocking extra abilities for the main character.

## **Animations**
The following are the animations used in the state machines of the various characters and elements of the game:

- **Player:**
  - Idle
  - Run
  - Jump
  - Double Jump
  - Ball Move
  - Ball Idle
  - Bow

- **Bomb:**
  - Active
  - Explosion

- **Arrow:**
  - Arrow Flying

- **Bat:**
  - Fly

## **Pickups**
The types of pickups implemented in the game are:

- Shining Coin
- Spinning Coin
- Shining Heart

## **Attacks**
The types of attacks available to the player are:

- Arrow Shot
- Bomb Drop

# Gameplay Preview

## Jump and Double Jump
![Jump and Double Jump](https://github.com/JuanGr95/Pixel-Hero-2D/assets/131586834/04f3a556-ff40-41d7-8f19-60811d246a1d)


## Ball Mode, Bombs and Box Explosions
![Ball Mode, Bombs and Box Explosions](https://github.com/JuanGr95/Pixel-Hero-2D/assets/131586834/8220ba02-3ae0-4ecc-879f-a7a040e19566)

## Dash Mode
![Dash Mode](https://github.com/JuanGr95/Pixel-Hero-2D/assets/131586834/7240b113-7604-4e25-bd88-79e55bd5bc56)

## Hearts and Coins Pickups
![Hearts and Coins Pickups](https://github.com/JuanGr95/Pixel-Hero-2D/assets/131586834/186f1401-c788-42c6-9914-64b63c77beff)

## Arrows
![Arrows](https://github.com/JuanGr95/Pixel-Hero-2D/assets/131586834/a187fb8a-e688-4046-a337-e7cbf0c2b680)

---
<!--
### Project Specifications

#### Unlocking System for EXTRAS
The unlocking system for EXTRAS allows the player to keep track of the items collected and to distinguish what type of item it is. Items have looping sprite sequence animations and must be collected with an Alpha Fade animation and a movement on the Y-axis.

The scripts used to implement this system are:
- `ItemController.cs`
- `ItemsManager.cs`
- `PlayerExtrasTracker.cs` (optional for communication with ItemsManager)

The order of unlocking EXTRAS is as follows:
1. Double Jump - 5 Shining Heart items
2. Dash - 6 Spinning Coin items
3. Ball Mode and Drop Bombs - 10 Shining Coin items

The `UIManager.cs` script is responsible for text debugging with the ONGUI class to display the pending item count during gameplay in the editor.

#### Enemies and Arrows System
The Bat-type enemy is destroyed with arrows and has a simulated destruction animation with particles. The particle system is adjusted to the size and color of the Bat. If a Bat touches the Player, the level is restarted along with the item count collected in the scene.

The relevant scripts for this system are:
- `ArrowControler.cs` (extended for collisions)
- `EnemyController.cs` (to manage the destruction animation)

---
-->
