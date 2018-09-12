using System;


namespace BattleShip
{
    public class Board
    {
        private IGrid m_Grid;
        private BattleShip[] m_shapes;
        private UInt16 m_numShapes;
        private UInt16 m_currNumShapes;

        public Board(UInt16 rows, UInt16 cols, UInt16 numshapes)
        {
            m_Grid = new Grid(rows,cols);
            m_numShapes = numshapes;
            m_shapes = new BattleShip[m_numShapes];
            m_currNumShapes = 0;
        }

        public void AddBattleShip(BattleShip Obj)
        {
            if (m_currNumShapes >= m_numShapes)
                return; //need to handle better
            m_shapes[m_currNumShapes++] = Obj;
        }

        public BattleShip GetBattleShip(UInt16 pos)
        {
            if (pos > m_numShapes)
                return null;
            return m_shapes[pos];
        }

        public Boolean PlaceShip(UInt16 startrow, UInt16 startcol, BattleShip Obj, Orientation orient)
        {
            try
            {
                m_Grid.PlaceShip(startrow, startcol, Obj, orient);
            }
            catch (Exception err)
            {
                return false;
            }

            return true;
        }

        public Boolean Attack(UInt16 row, UInt16 col)
        {
            return m_Grid.Attack(row, col);
        }

        public BattleShip IsOccupied(UInt16 row, UInt16 col)
        {
            return m_Grid.IsOccupied(row, col);
        }

        public Boolean HasLostGame()
        {
            foreach (BattleShip bs in m_shapes)
            {
                if (false == bs.IsDestroyed())
                    return false;
            }

            return true;
        }
    }
}
