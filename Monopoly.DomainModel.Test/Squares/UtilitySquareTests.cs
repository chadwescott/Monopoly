using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.DomainModel.Squares;
using Monopoly.DomainModel.Test.Helpers;
using Rhino.Mocks;

namespace Monopoly.DomainModel.Test.Squares
{
    [TestClass]
    public class UtilitySquareTests
    {
        private Player _roller;
        private Player _owner;
        private UtilitySquare _electric;
        private UtilitySquare _water;

        [TestInitialize]
        public void TestInitialize()
        {
            var group = new PropertyGroup();
            _electric = new UtilitySquare("Electric Company", 0, group, 150);
            _water = new UtilitySquare("Water Works", 1, group, 150);

            var die = MockRepository.GenerateStub<IDie>();
            die.Stub(s => s.GetFaceValue()).Return(1);
            var dice = new[] { die, die };
            var board = BoardHelper.GetBoard();
            _roller = new Player("Roller", dice, board);
            _roller.AddCash(2000);
            _owner = new Player("Owner", dice, board);
            _owner.AddCash(2000);
        }

        [TestMethod]
        public void UtilitySquarePayRentOneUtilityTest()
        {
            _owner.AttemptPurchase(_electric);
            Assert.AreEqual(_electric.Owner, _owner);
            var rollTotal = _roller.GetRollTotal();
            Assert.AreEqual(2, rollTotal);
            _electric.LandedOn(_roller);
            Assert.AreEqual(1992, _roller.Cash);
        }

        [TestMethod]
        public void UtilitySquarePayRentTwoUtilityTest()
        {
            _owner.AttemptPurchase(_electric);
            Assert.AreEqual(_electric.Owner, _owner);
            _owner.AttemptPurchase(_water);
            Assert.AreEqual(_water.Owner, _owner);
            var rollTotal = _roller.GetRollTotal();
            Assert.AreEqual(2, rollTotal);
            _electric.LandedOn(_roller);
            Assert.AreEqual(1980, _roller.Cash);
        }
    }
}
