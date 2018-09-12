using System;
using System.Collections;

namespace BattleShip
{
    internal abstract class GridEnumerator : IEnumerator
    {
        protected static Grid m_Container;
        protected static UInt32 m_StartRow;
        protected static UInt32 m_StartCol;
        protected static UInt32 m_BSCols;
        protected static UInt32 m_BSRows;
        protected static Boolean m_FirstTime;

        public abstract bool MoveNext();

        public abstract void Reset();

        public abstract object Current { get; }

        public static GridEnumerator GetEnumerator (Grid container, UInt32 startrow, UInt32 startcol, UInt32 BSRows, UInt32 BSCols, Orientation orient)
        {
            m_Container = container;
            m_StartRow = startrow;
            m_StartCol = startcol;
            m_BSRows = BSRows;
            m_BSCols = BSCols;

            if (Orientation.UVERTICAL == orient)
                return new UVerticalEnumerator();
            else if (Orientation.DVERTICAL == orient)
                return new DVerticalEnumerator();
            else if (Orientation.LHORIZONTAL == orient)
                return new LHorizontalEnumerator();
            else if (Orientation.RHORIZONTAL == orient)
                return new RHorizontalEnumerator();
            else
                throw new Exception();
            
        }
    }
}
