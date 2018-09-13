using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace BattleShipTester
{
    [TestClass]
    public class Various
    {
        private Board m_newBoard;

        public Various()
        {
            m_newBoard = new Board(10, 10, 5);
        }

        [TestMethod]
        public void Test_Multiple_1()
        {
            BattleShip.BattleShip shp = null;

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(2, 4));

            Boolean placed = m_newBoard.PlaceShip(2, 5, shp, Orientation.DVERTICAL);

            Assert.IsTrue(placed);

            shp = m_newBoard.IsOccupied(5, 6);

            Assert.IsNotNull(shp);

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(2, 4));

            placed = m_newBoard.PlaceShip(5, 4, shp, Orientation.RHORIZONTAL);

            Assert.IsFalse(placed);

            placed = m_newBoard.PlaceShip(5, 1, shp, Orientation.RHORIZONTAL);

            Assert.IsTrue(placed);

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 7));

            placed = m_newBoard.PlaceShip(1, 7, shp, Orientation.LHORIZONTAL);

            Assert.IsTrue(placed);

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            placed = m_newBoard.PlaceShip(0, 8, shp, Orientation.UVERTICAL);

            Assert.IsFalse(placed);

            placed = m_newBoard.PlaceShip(1, 4, shp, Orientation.UVERTICAL);

            Assert.IsFalse(placed);

            placed = m_newBoard.PlaceShip(1, 8, shp, Orientation.UVERTICAL);

            Assert.IsTrue(placed);

        }

        [TestMethod]
        public void Test_Multiple_2()
        {
            BattleShip.BattleShip shp = null;

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            Boolean placed = m_newBoard.PlaceShip(1, 8, shp, Orientation.UVERTICAL);

            Assert.IsTrue(placed);

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            placed = m_newBoard.PlaceShip(8, 8, shp, Orientation.DVERTICAL);

            Assert.IsTrue(placed);

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            placed = m_newBoard.PlaceShip(8, 1, shp, Orientation.LHORIZONTAL);

            Assert.IsTrue(placed);

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            placed = m_newBoard.PlaceShip(7, 8, shp, Orientation.RHORIZONTAL);

            Assert.IsTrue(placed);

        }
    }
}
