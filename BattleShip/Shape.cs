using System;

namespace BattleShip
{
    /* The default orientation of shape is always horizontal left downward. Rows and cols
     * are when the shape is default oriented
     */
    public class BattleShip
    {
        private Int16 m_rows;
        private Int16 m_cols;
        private Int16 m_CellsIntact;
       
        public Int16 Rows
        {
            get { return m_rows;}

        }

        public Int16 Cols
        {
            get { return m_cols; }
        }

        public BattleShip(Int16 rows, Int16 cols)
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

        public Int16 GetIntactCells()
        {
            return m_CellsIntact;
        }

        public Boolean IsDestroyed ()
        {
            return (0 == m_CellsIntact) ? true : false;
        }

    }
}
