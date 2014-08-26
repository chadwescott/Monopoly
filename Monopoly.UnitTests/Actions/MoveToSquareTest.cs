using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Actions;
using Monopoly.UnitTests.Helpers;

namespace Monopoly.UnitTests.Actions
{
    [TestClass]
    public class MoveToSquareTest
    {
        private MoveToSquare _target;
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
            var startSquare = _board.GetStartSquare();
            Assert.AreEqual(startSquare, _player.GetLocation());
            var expected = _board.GetSquare(startSquare, 1);
            _target = new MoveToSquare(expected);
            _target.Execute(_player);
            Assert.AreEqual(expected, _player.GetLocation());
        }
    }
}
