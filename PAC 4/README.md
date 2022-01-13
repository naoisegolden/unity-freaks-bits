# PAC 4

Author: Naoise Golden Santos <naoise@uoc.edu>

## Requirements

* Pantalla con logo corporativo (puede ser el de la UOC o el de vuestra propia compañía ficticia).
* Pantalla de título.
* Pantalla de menú principal (con menú de opciones).
* Dos pantallas de juego (con su UI correspondiente).
* Pantalla de créditos.

## Implementation

Pixel Perfect Camera.

Pixels Per Unit set at 32.

Touch controls with Joystick Pack package from Unity Asset Store and custom button.

Player script informs Game script when it dies, so that the logic of the player dying (animations) and the side effects are separated.

Enemy patrols.

Particle system for dust effect on jumping and landing.

Generic `Killer` tag converts any game object with a collider into a trap or an enemy.

Use of interfaces. For example, the `IDisappearable` behavior used in collectibles, player and NPC (minion).

Gracefully fails if `Disappear` component is not present. Uses `RequireComponent` to inform.

Use of struct, class, queues and `System.Serializable` to allow dynamic game object fields for the dialog logic. Implemented `Deconstruct` in struct for syntactic sugar. Any amount of dialogue and characters can be created directly in the Dialogue Manager component.

Implemented scene transitions.

Implemented camera shake (when player dies) with Cinemachine Impulse source and listeners.

Uses `Action` to distribute logic as side effects: events like `Die` or `Pause` define in `Game.cs` the logic that affects the whole game and in `Player.cs` or `GameMenuManager.cs` the logic that only affects their game objects.

## Resources

* Thaleah font: https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059
* Gotham Black font: https://fontsgeek.com/fonts/Gotham-Black
* Player and world sprites: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360
* Enemies sprites: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-2-155418
* UI sprites: https://assetstore.unity.com/packages/2d/gui/icons/simple-free-pixel-art-styled-ui-pack-165012
* Joystick Pack: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
