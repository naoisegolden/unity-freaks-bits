# PAC 4

Author: Naoise Golden Santos <naoise@uoc.edu>

Video: https://youtu.be/deSMFQ9jOF0

## Requirements

* Pantalla con logo corporativo (puede ser el de la UOC o el de vuestra propia compañía ficticia).
* Pantalla de título.
* Pantalla de menú principal (con menú de opciones).
* Dos pantallas de juego (con su UI correspondiente).
* Pantalla de créditos.

## Game instruction

Follow the instructions in the level tutorials.

## Implementation

Pixel Perfect Camera. Pixels Per Unit set at 32 throughout the game.

Touch controls with Joystick Pack package from Unity Asset Store and custom button.

Player script informs Game script when it dies, so that the logic of the player dying (animations) and the side effects are separated.

The enemies patrol based on `RigidBody 2D` and collisions with the world.

Particle system for dust effect on jumping and landing.

Generic `Killer` tag converts any game object with a collider into a trap or an enemy.

Use of Platform Effector 2D for jump-through platforms.

Use of interfaces. For example, the `IDisappearable` behavior used in collectibles, player and NPC (minion).

Gracefully fails if `Disappear` component is not present. Uses `RequireComponent` to inform.

Use of struct, class, queues and `System.Serializable` to allow dynamic game object fields for the dialog logic. Implemented `Deconstruct` in struct for syntactic sugar. Any amount of dialogue and characters can be created directly in the Dialogue Manager component.

Implemented scene transitions.

Implemented camera shake (when player dies) with Cinemachine Impulse source and listeners.

Uses `Action` to distribute logic as side effects: events like `Die` or `Pause` define in `Game.cs` the logic that affects the whole game and in `Player.cs` or `GameMenuManager.cs` the logic that only affects their game objects.

## Next steps

* Add more and better sound effects and music.
* Add more traps, enemies, platforms and minions.
* Add more levels.
* Add level map scene.
* Fix bugs and typos in game tutorial.
* Improve current maps.

## Resources

* Thaleah font: https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059
* Gotham Black font: https://fontsgeek.com/fonts/Gotham-Black
* Player and world sprites: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360
* Enemies sprites: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-2-155418
* UI sprites: https://assetstore.unity.com/packages/2d/gui/icons/simple-free-pixel-art-styled-ui-pack-165012
* Joystick Pack: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
* Sound effects pack: https://phoenix1291.itch.io/sound-effects-pack-2
* Music: https://jonathan-so.itch.io/creatorpack
