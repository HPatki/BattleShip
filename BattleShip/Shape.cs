using System;

namespace BattleShip
{
    /* The default orientation of shape is always horizontal left downward. Rows and cols
     * are when the shape is default oriented
     */
    public class BattleShip
    {
        private UInt16 m_rows;
        private UInt16 m_cols;
        private UInt16 m_CellsIntact;
       
        public UInt16 Rows
        {
            get { return m_rows;}

        }

        public UInt16 Cols
        {
            get { return m_cols; }
        }

        public BattleShip(UInt16 rows, UInt16 cols)
        {
            m_rows = rows;
            m_cols = cols;
            m_CellsIntact = 0;
        }

        public void AddCell ()
        {
            m_CellsIntact += 1;
        }

        public void DelCell()
        {
            m_CellsIntact -= 1;
        }

        public UInt16 GetIntactCells()
        {
            return m_CellsIntact;
        }

        public Boolean IsDestroyed ()
        {
            return (0 == m_CellsIntact) ? true : false;
        }

    }
}
