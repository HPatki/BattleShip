using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BattleShip;

namespace BattleShipTester
{
    [TestClass]
    public class PlaceShips
    {
        private Board m_newBoard;

        public PlaceShips()
        {
            m_newBoard = new Board(10, 10, 1);
        }

        [TestMethod]
        public void Test_PlaceShips()
        {
            BattleShip.BattleShip shp = null;
            
            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));
            
            m_newBoard.PlaceShip(1, 1, shp, Orientation.RHORIZONTAL);

            shp = m_newBoard.IsOccupied(1, 1);

            Assert.IsNotNull(shp);
        }

        [TestMethod]
        public void Test_WrongPlaceShipLH()
        {
            BattleShip.BattleShip shp = null;

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            Boolean placed = m_newBoard.PlaceShip(0, 0, shp, Orientation.LHORIZONTAL);

            Assert.IsFalse(placed);
        }

        [TestMethod]
        public void Test_WrongPlaceShipRH()
        {
            BattleShip.BattleShip shp = null;

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            Boolean placed = m_newBoard.PlaceShip(0, 9, shp, Orientation.RHORIZONTAL);

            Assert.IsFalse(placed);
        }

        [TestMethod]
        public void Test_WrongPlaceShipUV()
        {
            BattleShip.BattleShip shp = null;

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            Boolean placed = m_newBoard.PlaceShip(0, 0, shp, Orientation.UVERTICAL);

            Assert.IsFalse(placed);
        }

        [TestMethod]
        public void Test_WrongPlaceShipDV()
        {
            BattleShip.BattleShip shp = null;

            m_newBoard.AddBattleShip(shp = new BattleShip.BattleShip(1, 2));

            Boolean placed = m_newBoard.PlaceShip(9, 0, shp, Orientation.DVERTICAL);

            Assert.IsFalse(placed);
        }
    }
}
