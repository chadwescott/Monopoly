using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.DomainModel.Squares;
using Monopoly.DomainModel.Test.Helpers;

namespace Monopoly.DomainModel.Test.Squares
{
    [TestClass]
    public class RailroadSquareTests
    {
        private Player _roller;
        private Player _owner;
        private RailroadSquare _reading;
        private RailroadSquare _penn;
        private RailroadSquare _bo;
        private RailroadSquare _short;

        [TestInitialize]
        public void TestInitialize()
        {
            var group = new PropertyGroup();
            _reading = new RailroadSquare("Reading Railroad", 0, group, 200);
            _penn = new RailroadSquare("Pennsylvania Railroad", 1, group, 200);
            _bo = new RailroadSquare("B&O Railroad", 2, group, 200);
            _short = new RailroadSquare("Short Line Railroad", 3, group, 200);

            var dice = new[] { new Die(), new Die() };
            var board = BoardHelper.GetBoard();
            _roller = new Player("Roller", dice, board);
            _roller.AddCash(2000);
            _owner = new Player("Owner", dice, board);
            _owner.AddCash(2000);
        }

        [TestMethod]
        public void RailroadSquarePayRentOneRailroadTest()
        {
            _owner.AttemptPurchase(_reading);
            Assert.AreEqual(_reading.Owner, _owner);
            _reading.LandedOn(_roller);
            Assert.AreEqual(1975, _roller.Cash);
        }

        [TestMethod]
        public void RailroadSquarePayRentTwoRailroadTest()
        {
            _owner.AttemptPurchase(_reading);
            _owner.AttemptPurchase(_penn);
            Assert.AreEqual(_reading.Owner, _owner);
            _reading.LandedOn(_roller);
            Assert.AreEqual(1950, _roller.Cash);
        }

        [TestMethod]
        public void RailroadSquarePayRentThreeRailroadTest()
        {
            _owner.AttemptPurchase(_reading);
            _owner.AttemptPurchase(_penn);
            _owner.AttemptPurchase(_bo);
            Assert.AreEqual(_reading.Owner, _owner);
            _reading.LandedOn(_roller);
            Assert.AreEqual(1900, _roller.Cash);
        }

        [TestMethod]
        public void RailroadSquarePayRentFourRailroadTest()
        {
            _owner.AttemptPurchase(_reading);
            _owner.AttemptPurchase(_penn);
            _owner.AttemptPurchase(_bo);
            _owner.AttemptPurchase(_short);
            Assert.AreEqual(_reading.Owner, _owner);
            _reading.LandedOn(_roller);
            Assert.AreEqual(1800, _roller.Cash);
        }
    }
}
