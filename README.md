# PAC 4

Author: Naoise Golden Santos <naoise@uoc.edu>

Video: https://youtu.be/ePDfZ_g3zg4

## Requirements

* Pantalla con logo corporativo.
* Pantalla de título.
* Pantalla de menú principal (con menú de opciones). NOTA: en este caso, la implementación no es de una pantalla extra, sino de un modal que se al pausar el juego. Se ha decidido así para mantener la simplicidad del juego en el que se inspira.
* Dos pantallas de juego (con su UI correspondiente). NOTA: se han implementado 3.
* Pantalla de créditos.

## Game instructions

Follow the instructions in the level tutorials.

## Description

The game is a 2D platformer for mobile devices, inspired by [Thomas K. Young's](http://www.thomaskyoung.com/) Dadish.

The logo, title and story are based on a friends' podcast, [Freaks & Bits](https://twitter.com/FreaksBits). Magí, one of the hosts, does a section with "the curtain rises" jokes about videogames. More often than not, he uses jokes from Twitter followers or friends, who he calls his "minions".

In this game, the player (Magí) needs to find his way through to the minions so they can tell him the jokes.

---

El joc es un plataformes 2D per a mòbil, insipirat en el joc Dadish de [Thomas K. Young](http://www.thomaskyoung.com/).

El logo, títol i història estàn basats en el podcast d'uns amics, [Freaks & Bits](https://twitter.com/FreaksBits). En Magí, un dels presentadors, té una secció anomenada "Videojocs de paraules" on explica acudits de tipus "s'obre el teló" combinats amb jocs de paraules. Sovint, fa servir acudits explicats per seguidors del programa a Twitter o per amistats, a qui anomenen "minions".

En aquest joc, el protagonista (en Magí) ha de passar proves per trobar el minion perquè li expliqui un joc de paraules.

## Implementation

Touch controls with Joystick Pack package from Unity Asset Store and custom button.

Player script informs Game script when it dies, so that the logic of the player dying (animations) and the side effects are separated.

Player, minion, enemies and collectibles have animations and state machines. Animations and state machines are also used in the dialog box, game menu, splash logo and final credits.

The enemies patrol based on collisions with the world.

Particle system for dust effect on jumping and landing.

Generic `Killer` tag converts any game object with a collider into a trap or an enemy.

Use of Platform Effector 2D for jump-through platforms.

Use of custom interfaces. For example, the `IDisappearable` behavior used in collectibles, player and NPC (minion).

Use of struct, class, queues and `System.Serializable` to allow dynamic game object fields for the dialog logic. Implemented `Deconstruct` in struct for syntactic sugar. Any amount of dialogue and characters can be created directly in the Dialogue Manager component.

Implemented scene transitions.

I used Cinemachine for the camera to follow the player. I implemented first [the code from the material provided](https://gitlab.com/uoc_vg/prog2d/ed.2021-2/modulo-2/-/blob/master/docs/Soluciones.md#reto-6), but once I did this, I wanted to add a bit more of complexity and Cinemachine was the perfect choice. 

Cinemachine not only tracks the game object you tell it, but also allows to define "damping" so that the camera movement is smoother, and boundary limits to which confine the camera movement.

Pixel Perfect Camera. Pixels Per Unit set at 32 throughout the game.

Implemented camera shake (when player dies) with Cinemachine Impulse source and listeners.

Uses `Action` to distribute logic as side effects: events like `Die` or `Pause` define in `Game.cs` the logic that affects the whole game and in `Player.cs` or `GameMenuManager.cs` the logic that only affects their game objects.

I use a struct `GameData` to encapsulate all game data. In the future, this can be used to persist the completed levels, bonus points, and implement checkpoints.

Reusable class `Disappearable` contains the basic logic for game object that disappear: Player, Minion and Collectibles. 
Gracefully fails if `Disappear` component is not present, so "disappearable" objects don't break if there is no disappear animation linked.

Uses `RequireComponent` to inform which dependencies each script has.

Game objects that trigger an effect when the Player collisions contain their own logic: the Player doesn't need to be aware of all the game objects it can interact with. For example, `Collectible` contains the logic to animate and disappear, and calls an Action set in the `Game.cs` to execute side effects like updating the game date. This avoids hard dependency between game objects and allows the game to expand.

The aspect ratio of the viewport and the build are based on a handheld in landscape mode. The only build configured is for iPhone, and it's been tested on an iPhone 7.

In general, the code follows the ["single-responsibility principle"](https://en.wikipedia.org/wiki/Single-responsibility_principle) and the ["interface segregation principle"](https://en.wikipedia.org/wiki/Interface_segregation_principle), both part of the SOLID principles.

## Next steps

* Add more and better sound effects and music.
* Add more traps, enemies, platforms and minions.
* Add more levels.
* Improve current levels.
* Add level map.
* Implement checkpoints.
* Fix bugs and typos in game tutorial.
* Figure out what is the purpose of the bonus collectibles.
* Persist game data.

## Resources

* Thaleah font: https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059
* Gotham Black font: https://fontsgeek.com/fonts/Gotham-Black
* Player and world sprites: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360
* Enemies sprites: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-2-155418
* UI sprites: https://assetstore.unity.com/packages/2d/gui/icons/simple-free-pixel-art-styled-ui-pack-165012
* Joystick Pack: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
* Sound effects pack: https://phoenix1291.itch.io/sound-effects-pack-2
* Music: https://jonathan-so.itch.io/creatorpack
