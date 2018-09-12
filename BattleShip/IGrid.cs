using System;

namespace BattleShip
{
    interface IGrid
    {
        void PlaceShip (UInt16 startrow, UInt16 startcol, BattleShip ship, Orientation orient);

        Boolean Attack(UInt16 row, UInt16 col);

        BattleShip IsOccupied(Int32 row, Int32 col);
        
    }
}
