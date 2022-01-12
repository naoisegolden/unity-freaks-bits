# PAC 4

Author: Naoise Golden Santos <naoise@uoc.edu>

## Implementation

Pixel Perfect Camera.

Pixels Per Unit set at 32.

Touch controls with Joystick Pack package from Unity Asset Store and custom button.

Player script informs Game script when it dies, so that the logic of the player dying (animations) and the side effects are separated.

Enemy patrols.

Particle system for dust effect on jumping and landing.

Generic `Killer` tag converts any game object with a collider into a trap or an enemy.

Use of interfaces for the IDisappearable behavior in collectibles, player and NPC.

Gracefully fails if `Disappear` component is not present. Uses `RequireComponent` to inform.

Use of struct, class, queues and `System.Serializable` to allow dynamic game object fields for the dialog logic. Implemented `Deconstruct` in struct for syntactic sugar. Any amount of dialogue and characters can be created directly in the Dialogue Manager component.

Implemented scene transitions.

## Resources

* Free Pixel Font - Thaleah: https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059
* Player and world: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360
* Enemies: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-2-155418
* Joystick Pack: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
