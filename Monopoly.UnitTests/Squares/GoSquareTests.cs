using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Squares;
using Monopoly.UnitTests.Helpers;

namespace Monopoly.UnitTests.Squares
{
    [TestClass]
    public class GoSquareTests
    {
        private Player _player;
        private readonly GoSquare _fixture = new GoSquare("GoSquare", 0);

        [TestInitialize]
        public void TestInitialize()
        {
            var dice = new[] { new Die(), new Die() };
            var board = BoardHelper.GetBoard();

            _player = new Player("Car", dice, board);
        }

        [TestMethod]
        public void PassedGoTest()
        {
            var cashBefore = _player.Cash;
            _fixture.Passed(_player);
            Assert.AreEqual(cashBefore + _fixture.Salary, _player.Cash);
        }
    }
}
