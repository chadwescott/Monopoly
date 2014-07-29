using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.DomainModel.Squares;
using Monopoly.DomainModel.Test.Helpers;

namespace Monopoly.DomainModel.Test.Squares
{
    [TestClass]
    public class IncomeTaxSquareTests
    {
        private Player _player;
        private readonly IncomeTaxSquare _fixture = new IncomeTaxSquare("IncomeTax", 0);

        [TestInitialize]
        public void TestInitialize()
        {
            var dice = new[] { new Die(), new Die() };
            var board = BoardHelper.GetBoard();

            _player = new Player("Car", dice, board);
            Assert.AreEqual(0, _player.Cash);
        }

        [TestMethod]
        public void FlatTaxTest()
        {
            const int cash = 5000;
            _player.AddCash(cash);
            Assert.AreEqual(cash, _player.Cash);
            _fixture.LandedOn(_player);
            Assert.AreEqual(cash - 200, _player.Cash);
        }

        [TestMethod]
        public void PercentTaxTest()
        {
            const int cash = 1000;
            const int taxAmount = 150;
            _player.AddCash(cash);
            Assert.AreEqual(cash, _player.Cash);
            _fixture.LandedOn(_player);
            Assert.AreEqual(cash - taxAmount, _player.Cash);
        }
    }
}
