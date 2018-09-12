# BattleShip

This is an Implementation of the popular Game 'BattleShip'.

The Project is coded in C#, using .NET 4.5 & Visual Studio 2012. Compilation on higher versions of Visual Studio will 
will require an upgrade to the project files (Visual Studio should do this for you).

At a high Level, the project consists of following classes

## Board

This class represents the game board with the Grid and BattleShips. 

The Grid is configurable to any N X N size ( N has to be between 1 and MAX UINT16). The Board hold (theoretically) 'M' number
of BattleShips, value of 'M' between 0 and MAX UINT16. These values are to be provided when the board is created first time.

Having created the board, proceed to add the 'M' 'BattleShips' to the board. Please refer the notes on class 'BattleShip' for
more details

## Grid

This class represents a 'Battle Field', which is mapped into 'Rows' & 'Columns'. BattleShips can be placed onto the Grid. No two 
BattleShips can occupy the same Position on the Grid. Trying to place this way results in failure.

## BattleShip
