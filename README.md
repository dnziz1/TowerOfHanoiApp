# TowerOfHanoiApp

A C# implementation of the Tower of Hanoi puzzle with both console animation and Windows Forms GUI visualisation, following Marcin Jamro's design.

## Features Implemented
- Recursive algorithm implementation
- Real-time visualization:
	- Console visualisation
	- **NEW**: Windows Forms GUI with animated blocks
- Configurable number of disks (1-10 recommended)
- Move counter
- Pause/Resume functionality
- Save and load game state

## GUI Features to Implement
- Animated disc movements between towers
- Color coded discs for distinction between disc sizes
- Controls:
	- Start/Pause/Resume buttons
	- Disc count select dropdown
	- Animation speed control button
- Visual tower representation

## How to Run

## Console Version
1. Open in Visual Studio or any C# IDE.
2. Set 'TowerOfHanoi' as startup project
3. Build the project and run it.
4. Watch the Tower of Hanoi puzzle being solved step-by-step in the console.

## GUI Version (**NEW**)
1. Open in Visual Studio or any C# IDE.
2. Set 'TowerOfHanoi.GUI' as startup project
3. Build the project and run it.
4. Use the controls to configure the discs and watch the animation version.

## Algorithm
Uses the classic recursive approach with three stacks representing the towers.
