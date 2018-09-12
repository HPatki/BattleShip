using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BattleShip;

namespace BattleShipTester
{
    [TestClass]
    public class OverlapPlacement
    {
        private Board m_newBoard;

        public OverlapPlacement()
        {
            m_newBoard = new Board(5,5,2);
        }

        [TestMethod]
        public void Test_OverlapAcrossColumns()
        {
                m_newBoard.AddBattleShip (new BattleShip.BattleShip(1,3));
                m_newBoard.AddBattleShip(new BattleShip.BattleShip(1, 1));

                Boolean placed = m_newBoard.PlaceShip(2, 2, m_newBoard.GetBattleShip(0), Orientation.RHORIZONTAL);

                Assert.IsTrue(placed);

                placed = m_newBoard.PlaceShip(0, 2, m_newBoard.GetBattleShip(1), Orientation.DVERTICAL);

                Assert.IsTrue(placed);
        }
    }
}
