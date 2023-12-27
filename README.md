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
  - Dash
  - Ball Mode
  - Drop Bomb

- **Bomb:**
  - Tick
  - Explode

- **Arrow:**
  - Shoot
  - Hit

- **Bat:**
  - Fly
  - Hit

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
![Jump and Double Jump](url_of_gif)

## Ball Mode, Bombs and Box Explosions
![Ball Mode, Bombs and Box Explosions](url_of_gif)

## Dash Mode
![Dash Mode](url_of_gif)

## Hearts and Coins Pickups
![Hearts and Coins Pickups](url_of_gif)

## Arrows
![Arrows](url_of_gif)

---

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
