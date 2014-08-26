using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Actions;
using Monopoly.UnitTests.Helpers;

namespace Monopoly.UnitTests.Actions
{
    [TestClass]
    public class PayFeeTest
    {
        private PayFee _target;
        private Player _player;
        private Board _board;

        [TestInitialize]
        public void TestInitialize()
        {
            _board = BoardHelper.GetBoard();
            _player = PlayerHelper.CreatePlayer("Car", _board);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            const int amount = 50;
            var expected = _player.Cash - amount;
            _target = new PayFee(amount);
            _target.Execute(_player);
            Assert.AreEqual(expected, _player.Cash);
        }
    }
}
