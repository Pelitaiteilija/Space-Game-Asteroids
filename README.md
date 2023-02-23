# Space Game: Asteroids
 
 ![Asteroids game screenshot](./GitDocs/asteroids_game.png)

 
 An asteroids clone, potentially with some progression elements down the line. 

 If you're interested in the development process, you can also check the [version history](version_history.md) page.

  # Project goals

 This project is a practice project where I learn what's new in Unity since 2016 or so. Some of my personal learning goals were: 

 1. Learning about Scriptable Objects
 1. Becoming more familiar with the C# event system
 1. Learning about writing C# tests for a Unity project
 1. Learning about new programming patterns 
 1. Learning new and recommended UI workflows 
 1. Learning new and recommended Input workflows
 1. Learning about other new and recommended Unity workflows, systems and changes
 1. Becoming more familiar with selecting the most suitable programming patterns for Unity projects
 1. Becoming more familiar with using Git version control with Unity projects


## Scriptable Objects

This is the first project where I used Scriptable Objects. I generated new base Scriptable Object classes, and use them to hold information about various game objects, such as player-controlled ship's basic stats, and stats of different types of weapons and asteroids.

I also use some of the features explained in the Unite 2017 talk [Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk).

### Runtime Sets

![Runtime Set Subscriber script](./GitDocs/runtime_set_subscriber.png)

	I'm using Runtime Sets as a type of decoupled runtime lists of objects that exist in the game, which can be defined and renamed by designers (without writing extra code), and can be easily plugged in to multiple components of different objects without causing extra dependencies. 
	
	When an object is made to use a specific runtime set, it's added to a list of objects of that set, which can be later referenced on other scripts and components. For example, it can be used to keep track of the number of asteroids on the screen, but also types of specific asteroids (e.g. metal asteroids) on the screen. 

I also use Scriptable Objects in the event system, described below. 

## C# Event System

This is the first project where I designed its event system architecture myself; earlier, I've only been the 3D artist or at most a support programmer on projects using C# events. 

Instead of default Unity events, I ended up mostly using event "channels" based on Scriptable Objects, which make it easy to make modular, extendable and with automatically managed dependencies. 

### Scriptable Object Event System

Events are assets in the asset folder that can be added to GameObjects, and which can be used to call specific functions of the game object's components by using Unity's built-in event system.

![ScriptableObject events as assets](./GitDocs/events.png)

A simple script called Game Event Listener can be attached to any Game Object, and it can be made to listen to any of the predefined event assets.

![Game Event listener component](./GitDocs/game_event_listener.png)

Here's a piece of code that raises an event when there are no asteroids left on the screen. When this event is raised, all GameObjects react to the event. 

```csharp
void Update() {
	if(asteroidSet.Count == 0) {
		spawnAsteroidsEvent.Raise();
	}
}
```

This way, game objects can be decoupled from each other. Even if two game objects don't initially exist in the same scene, they can both interact with the same event system. Once they're brought to the same scene, they automatically start interacting with each other. 

## C# Tests

![Image of diceroll tests](./GitDocs/unity_tests_thumbnail.png)

I learned about writing basic tests for Unity using Unity's Test Framework package and TestRunner. 

### Diceroll tests

I wrote a few different tests for the DiceRoll helper class which takes a string and outputs a random number based on the parameters defined by the string, using the tabletop RPG diceroll notation. 

https://user-images.githubusercontent.com/122605754/220905766-7dea428b-daa6-4e8b-8b08-635d1b7b954a.mp4

For example, "1d6" generates a random number from 1 to 6 (inclusive), and 2d6 generates two numbers 1-6 and sums them together, giving a total range or results from 2 to 12, with 7 being the most common result.

The tests check that the string is interpreted correctly, that the generated random numbers are within the expected minimum and maximum range, and perform a simple repeated result test which outputs a representation of the relative likelyhood of the various results (as a Gaussian curve).
