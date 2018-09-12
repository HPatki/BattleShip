using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BattleShip;

namespace BattleShipTester
{
    [TestClass]
    public class Attack
    {
        private Board m_newBoard;

        public Attack()
        {
            m_newBoard = new Board(5,5,2);
        }

        [TestMethod]
        public void Attack_WithOneDestroyed()
        {
            m_newBoard.AddBattleShip(new BattleShip.BattleShip(1, 3));
            m_newBoard.AddBattleShip(new BattleShip.BattleShip(1, 1));

            Boolean placed = m_newBoard.PlaceShip(2, 2, m_newBoard.GetBattleShip(0), Orientation.RHORIZONTAL);

            Assert.IsTrue(m_newBoard.Attack(2, 4));
            Assert.IsTrue(m_newBoard.Attack(2, 2));
            Assert.IsTrue(m_newBoard.Attack(2, 3));

            BattleShip.BattleShip ship = m_newBoard.GetBattleShip(0);
            Assert.IsTrue(ship.IsDestroyed());
        }

        [TestMethod]
        public void Attack_WithAllDestroyed()
        {
            m_newBoard.AddBattleShip(new BattleShip.BattleShip(1, 3));
            m_newBoard.AddBattleShip(new BattleShip.BattleShip(1, 1));

            Boolean placed = m_newBoard.PlaceShip(2, 2, m_newBoard.GetBattleShip(0), Orientation.RHORIZONTAL);
            placed = m_newBoard.PlaceShip(0, 2, m_newBoard.GetBattleShip(1), Orientation.DVERTICAL);

            Assert.IsTrue(placed);
            Assert.IsTrue(m_newBoard.Attack(2, 4));
            Assert.IsTrue(m_newBoard.Attack(2, 2));
            Assert.IsTrue(m_newBoard.Attack(2, 3));

            BattleShip.BattleShip ship = m_newBoard.GetBattleShip(0);
            Assert.IsTrue(ship.IsDestroyed());

            Assert.IsTrue(m_newBoard.Attack(0, 2));
            
            ship = m_newBoard.GetBattleShip(1);
            Assert.IsTrue(ship.IsDestroyed());

            Assert.IsTrue(m_newBoard.HasLostGame());
            
        }
    }
}
