# BattleShip

This is an Implementation of the popular Game 'BattleShip'. 

The Project is coded in C#, using .NET 4.5 & Visual Studio 2012. Compilation on higher versions of Visual Studio will 
will require an upgrade to the project files (Visual Studio should do this for you).

The project is built as a Library and requires a 'Driver' program. Take a look at the 'Test Cases' to understand how to use the classes.

At a high Level, the project consists of following classes

## Board

This class represents the game board with the Grid and BattleShips. 

The Grid is configurable to any N X N' size ( N & N' have to be between 1 and MAX UINT16). 'M' number of BattleShips can be placed on the board, with value of 'M' between 0 and MAX UINT16. Note that the placement of Battleships is governed by the 'Shape' of the Battleship too. 

The values for N, N' & M have to be provided when the board is created for first time.

Having created the board, proceed to add the 'M' 'BattleShips' to the board. Please refer the notes on class 'BattleShip' for
more details

## Grid

This class represents a 'Battle Field', which is mapped into 'Rows' & 'Columns'. BattleShips can be placed onto the Grid. No two 
BattleShips can occupy the same Position on the Grid. Trying to place this way results in failure.

## BattleShip

A BattleShip takes a 'Rectangular Shape'. It is to be defined by specifying the number of rows and columns that it occupies. The definition is to be provided considering the Battleship to be in Horizontal position extending right-ward. It's as though you are measuring the dimensions with left,top corner as reference point. 

Battleships can be placed on the 'Grid' in different orientations. The presently implemented 'Grid' allows these four

- Horizontal Left 
- Horizontal Right
- Vertically Upwards
- Vertically Downwards

Orientation is always with reference to 'Pivot Point', which is the start position mentioned while placing the Battleship on the board. A Battleship is oriented 'Downward' in horizontal Orientation. It's oriented toward right in Vertical Orientation. As such the four Orientations become

- Horizontal Left, Down
- Horizontal Right, Down
- Vertically Upwards, Right
- Vertically Downwards, Right




