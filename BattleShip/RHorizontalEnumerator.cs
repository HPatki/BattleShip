using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class RHorizontalEnumerator : GridEnumerator
    {
        UInt32 m_CurrRow;
        UInt32 m_CurrCol;
        UInt32 m_limit;

        public RHorizontalEnumerator()
        {
            m_limit = m_StartRow + m_BSRows;
            m_CurrCol = 0;
            m_CurrRow = m_StartRow;
            m_FirstTime = true;
        }

        override public bool MoveNext()
        { 
            if (m_FirstTime == true)
            {
                m_FirstTime = false;
            }
            else
                m_CurrCol += 1;
            
            if (m_CurrCol >= m_BSCols)
            {
                m_CurrCol = 0;
                ++m_CurrRow;
                m_FirstTime = true;
            }

           

            if (m_CurrRow >= m_limit || m_CurrRow > m_Container.GetRows())
                return false;

            return true;
        }

        override public void Reset()
        {
            m_limit = m_StartRow + m_BSRows;
            m_CurrCol = 0;
            m_CurrRow = m_StartRow;
            m_FirstTime = true;
        }

        override public object Current 
        {
            get
            {
                   if (m_limit > m_Container.GetRows())
                        throw new Exception();

                    if ((m_StartCol + m_CurrCol > m_Container.GetCols()) || 
                        (null != m_Container.getOccupied(m_CurrRow, m_StartCol + m_CurrCol)))
                        throw new Exception();

                     return ((Grid)m_Container).GetCell(m_CurrRow, (m_StartCol + m_CurrCol));
            }
            
        }
    }
}
