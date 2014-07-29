using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.DomainModel.Squares;
using Rhino.Mocks;

namespace Monopoly.DomainModel.Test.Squares
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
            var board = MockRepository.GenerateStub<Board>();

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
