using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class UVerticalEnumerator : GridEnumerator
    {
        UInt32 m_CurrRow;
        UInt32 m_CurrCol;
        Int32 m_limit;

        public UVerticalEnumerator()
        {
            m_limit = (Int32)(m_StartRow - m_BSCols + 1); //+1 to compensate for zero based indexes
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
            
            if (m_CurrCol >= m_BSRows)
            {
                m_CurrCol = 0;
                --m_CurrRow;
                m_FirstTime = true;
            }

            

            if (m_CurrRow <= m_limit || m_CurrRow < 0)
                return false;

            return true;
        }

        override public void Reset()
        {
            m_limit = (Int32)(m_StartRow - m_BSCols);
            m_CurrCol = 0;
            m_CurrRow = m_StartRow;
            m_FirstTime = true;
        }

        override public object Current 
        {
            get
            {
                   if ((Int32)m_limit < 0)
                        throw new Exception();

                   if ((m_StartCol + m_CurrCol > m_Container.GetCols()) || (null != m_Container.getOccupied(m_CurrRow, m_StartCol + m_CurrCol)))
                        throw new Exception();

                   return ((Grid)m_Container).GetCell(m_CurrRow, (m_StartCol + m_CurrCol));
            }
            
        }
    }
}
