using System;
using System.Collections;
using System.Collections.Generic;

namespace BattleShip
{
    internal class Grid : IGrid, IEnumerable
    {
        public class Cell
        {
            private Int32 m_val;

            public Int32 Val
            {
                get { return m_val; }
                set { m_val = value; }
            }
        }

        private Cell[,] m_rowscols;
        private UInt16 m_rows, m_cols;
        private List<BattleShip> m_shapes;
        private List<Cell> m_scratchPad;
        private Orientation m_scratchOrientation;
        private UInt32 m_ScratchStartRow, m_ScratchStartCol, m_ScratchBSCols, m_ScratchBSRows;

        public Grid(UInt16 rows, UInt16 cols)
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

        public void PlaceShip(UInt16 startrow, UInt16 startcol, BattleShip ship, Orientation orient)
        {
            //check if the object overlaps some other
            if (startrow < 0 || startrow >= m_rows)
                throw new Exception();
            if (startcol < 0 || startcol >= m_cols)
                throw new Exception();

            m_scratchPad.Clear();

            m_ScratchStartRow = startrow;
            m_ScratchStartCol = startcol;
            m_ScratchBSRows = ship.Rows;
            m_ScratchBSCols = ship.Cols;
            m_scratchOrientation = orient;

            GridEnumerator itor = GetEnumerator();

            //this loop could throw exception 
            foreach (Cell one in this)
            {
                m_scratchPad.Add(one);
            }

            foreach (Cell one in m_scratchPad)
            {
                one.Val = m_shapes.Count+1;
                ship.AddCell();
            }

            m_shapes.Add(ship);
        }

        public Boolean Attack(UInt16 row, UInt16 col)
        {
            BattleShip shp = IsOccupied(row, col);
            if (null != shp)
            {
                shp.DelCell();
                return true;
            }
            return false;
        }

        internal BattleShip getOccupied(UInt32 row, UInt32 col)
        {
            if (row < 0 || row > m_rows || col < 0 || col > m_cols)
                return null;
            if (0 == m_rowscols[row, col].Val)
                return null;
            else
                return m_shapes[m_rowscols[row, col].Val - 1];
        }

        public BattleShip IsOccupied(UInt16 row, UInt16 col)
        {
            return getOccupied(row, col);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public GridEnumerator GetEnumerator()
        {
            return GridEnumerator.GetEnumerator(this, m_ScratchStartRow, m_ScratchStartCol, m_ScratchBSRows, m_ScratchBSCols, m_scratchOrientation);
        }

        public UInt16 GetCols ()
        {
            return m_cols;
        }

        public UInt16 GetRows()
        {
            return m_rows;
        }

        public Cell GetCell(UInt32 row, UInt32 col)
        {
            return m_rowscols[row, col];
        }
    }
}
