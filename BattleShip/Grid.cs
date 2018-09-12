using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Grid
    {
        private class Cell
        {
            private Int32 m_val;

            public Int32 Val
            {
                get { return m_val; }
                set { m_val = value; }
            }
        }

        private Cell[,] m_rowscols;
        private Int16 m_rows, m_cols;
        private List<BattleShip> m_shapes;
        private List<Cell> m_scratchPad;

        public Grid(Int16 rows, Int16 cols)
        {
            m_rows = rows;
            m_cols = cols;
            m_rowscols = new Cell[m_rows,m_cols];
            for (int row = 0; row < m_rows; ++row)
                for (int col = 0; col < m_cols; ++col)
                    m_rowscols[row, col] = new Cell();
            m_shapes = new List<BattleShip>();
            m_scratchPad = new List<Cell>();
        }

        public void PlaceShip (Int16 startrow, Int16 startcol, BattleShip ship, Orientation orient)
        {
            m_scratchPad.Clear();

            //check if the object overlaps some other
            if (startrow < 0 || startrow >= m_rows)
                throw new Exception();
            if (startcol < 0 || startcol >= m_cols)
                throw new Exception();
            
            if (Orientation.UVERTICAL == orient)
            {
                Int32 limit = startrow - ship.Cols;

                if ( limit < 0)
                    throw new Exception();

                for (Int32 currRow = startrow; currRow > limit && currRow > 0; --currRow)
                {
                    for (Int16 col =0; col<ship.Rows; ++col)
                    {
                        if ((startcol+col > m_cols) || (null!=IsOccupied(currRow,startcol+col)))
                            throw new Exception();

                        m_scratchPad.Add(m_rowscols[currRow,startcol+col]);
                    }
                }
            }
            else if (Orientation.DVERTICAL == orient)
            {
                Int32 limit = startrow + ship.Cols;

                if ( limit > m_rows)
                    throw new Exception();

                for (Int16 currRow = startrow; currRow < limit && currRow < m_rows; ++currRow)
                {
                    for (Int16 col = 0; col < ship.Rows; ++col)
                    {
                        if ((startcol + col > m_cols) || (null != IsOccupied(currRow, startcol + col)))
                            throw new Exception();

                        m_scratchPad.Add(m_rowscols[currRow, startcol + col]);
                    }
                }
            }
            else if (Orientation.LHORIZONTAL == orient)
            {
                Int32 limit = startrow + ship.Rows;

                if (limit > m_rows)
                    throw new Exception();

                for (Int16 currRow = startrow; currRow < limit && currRow < m_rows; ++currRow)
                {
                    for (Int16 col = 0; col < ship.Cols; ++col)
                    {
                        if ((startcol - col < 0) || (null != IsOccupied(currRow, startcol - col)))
                            throw new Exception();

                        m_scratchPad.Add(m_rowscols[currRow, startcol + col]);
                    }
                }

            }
            else if (Orientation.RHORIZONTAL == orient)
            {
                Int32 limit = startrow + ship.Rows;

                if (limit > m_rows)
                    throw new Exception();

                for (Int16 currRow = startrow; currRow < limit && currRow < m_rows; ++currRow)
                {
                    for (Int16 col = 0; col < ship.Cols; ++col)
                    {
                        if ((startcol + col > m_cols) || (null != IsOccupied(currRow, startcol + col)))
                            throw new Exception();

                        m_scratchPad.Add(m_rowscols[currRow, startcol + col]);
                       
                    }
                }
            }


            foreach (Cell one in m_scratchPad)
            {
                one.Val = m_shapes.Count+1;
                ship.AddCell();
            }

            m_shapes.Add(ship);
        }

        public Boolean Attack(Int16 row, Int16 col)
        {
            BattleShip shp = IsOccupied(row, col);
            if (null != shp)
            {
                shp.DelCell();
                return true;
            }
            return false;
        }

        public BattleShip IsOccupied(Int32 row, Int32 col)
        {
            if (row < 0 || row > m_rows || col < 0 || col > m_cols)
                return null;
            if (0 == m_rowscols[row, col].Val)
                return null;
            else
                return m_shapes[m_rowscols[row, col].Val-1];
        }
    }
}
