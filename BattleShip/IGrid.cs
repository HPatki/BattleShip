using System;

namespace BattleShip
{
    public interface IGrid
    {
        void PlaceShip (UInt16 startrow, UInt16 startcol, BattleShip ship, Orientation orient);

        Boolean Attack(UInt16 row, UInt16 col);

        BattleShip IsOccupied(UInt16 row, UInt16 col);

        UInt16 GetCols();

        UInt16 GetRows();   
    }
}
