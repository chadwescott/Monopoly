using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.DomainModel.Squares;
using Rhino.Mocks;

namespace Monopoly.DomainModel.Test.Squares
{
    [TestClass]
    public class BuildableSquareTests
    {
        private Player _roller;
        private Player _owner;
        private BuildableSquare _parkPlace;
        private BuildableSquare _boardwalk;

        [TestInitialize]
        public void TestInitialize()
        {
            var group = new PropertyGroup();
            _parkPlace = new BuildableSquare("Park Place", 0, group, 350, 200, 200, 400, 600, 1000, 1500, 1800);
            _boardwalk = new BuildableSquare("Boardwalk", 0, group, 400, 200, 300, 600, 800, 1200, 1600, 2000);

            IDie[] dice = { new Die(), new Die() };
            var board = MockRepository.GenerateStub<Board>();
            _roller = new Player("Roller", dice, board);
            _roller.AddCash(2000);
            _owner = new Player("Owner", dice, board);
            _owner.AddCash(2000);
        }

        [TestMethod]
        public void CanBuildNoOwnerTest()
        {
            Assert.IsFalse(_parkPlace.CanBuild());
            Assert.IsFalse(_boardwalk.CanBuild());
        }

        [TestMethod]
        public void CanBuildPropertyOwnedAndNotOwnedTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            Assert.IsFalse(_parkPlace.CanBuild());
            Assert.IsFalse(_boardwalk.CanBuild());
        }

        [TestMethod]
        public void CanBuildPropertyOwnedByTwoDifferentPlayersTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _roller.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_roller, _boardwalk.Owner);
            Assert.IsFalse(_parkPlace.CanBuild());
            Assert.IsFalse(_boardwalk.CanBuild());
        }

        [TestMethod]
        public void CanBuildAllPropertyOwnedBySamePlayerEnoughMoneyTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            Assert.IsTrue(_parkPlace.CanBuild());
            Assert.IsTrue(_boardwalk.CanBuild());
        }

        [TestMethod]
        public void CanBuildAllPropertyOwnedBySamePlayerNotEnoughMoneyTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            _owner.ReduceCash(_owner.Cash);
            Assert.IsFalse(_parkPlace.CanBuild());
            Assert.IsFalse(_boardwalk.CanBuild());
        }

        [TestMethod]
        public void CanBuildDevelopedToMaximumTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            Assert.AreEqual(DevelopmentLevel.EmptyLot, _parkPlace.GetDevelopmentLevel());
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            Assert.IsFalse(_parkPlace.CanBuild());
            Assert.IsTrue(_boardwalk.CanBuild());
        }

        [TestMethod]
        public void BuildOneHouseTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            Assert.AreEqual(DevelopmentLevel.EmptyLot, _parkPlace.GetDevelopmentLevel());
            _parkPlace.Develop();
            Assert.AreEqual(DevelopmentLevel.OneHouse, _parkPlace.GetDevelopmentLevel());
            Assert.AreEqual(1050, _owner.Cash);
        }

        [TestMethod]
        public void BuildTwoHousesTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            Assert.AreEqual(DevelopmentLevel.EmptyLot, _parkPlace.GetDevelopmentLevel());
            _parkPlace.Develop();
            _parkPlace.Develop();
            Assert.AreEqual(DevelopmentLevel.TwoHouses, _parkPlace.GetDevelopmentLevel());
            Assert.AreEqual(850, _owner.Cash);
        }

        [TestMethod]
        public void BuildThreeHousesTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            Assert.AreEqual(DevelopmentLevel.EmptyLot, _parkPlace.GetDevelopmentLevel());
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            Assert.AreEqual(DevelopmentLevel.ThreeHouses, _parkPlace.GetDevelopmentLevel());
            Assert.AreEqual(650, _owner.Cash);
        }

        [TestMethod]
        public void BuildFourHousesTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            Assert.AreEqual(DevelopmentLevel.EmptyLot, _parkPlace.GetDevelopmentLevel());
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            Assert.AreEqual(DevelopmentLevel.FourHouses, _parkPlace.GetDevelopmentLevel());
            Assert.AreEqual(450, _owner.Cash);
        }

        [TestMethod]
        public void BuildHotelTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            Assert.AreEqual(DevelopmentLevel.EmptyLot, _parkPlace.GetDevelopmentLevel());
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            Assert.AreEqual(DevelopmentLevel.Hotel, _parkPlace.GetDevelopmentLevel());
            Assert.AreEqual(250, _owner.Cash);
        }

        [TestMethod]
        public void LandOnEmptyLotTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _parkPlace.LandedOn(_roller);
            Assert.AreEqual(1800, _roller.Cash);
        }

        [TestMethod]
        public void LandOnOneHouseTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            _parkPlace.Develop();
            _parkPlace.LandedOn(_roller);
            Assert.AreEqual(1600, _roller.Cash);
        }

        [TestMethod]
        public void LandOnTwoHousesTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.LandedOn(_roller);
            Assert.AreEqual(1400, _roller.Cash);
        }

        [TestMethod]
        public void LandOnThreeHousesTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.LandedOn(_roller);
            Assert.AreEqual(1000, _roller.Cash);
        }

        [TestMethod]
        public void LandOnFourHousesTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.LandedOn(_roller);
            Assert.AreEqual(500, _roller.Cash);
        }

        [TestMethod]
        public void LandOnHotelTest()
        {
            _owner.AttemptPurchase(_parkPlace);
            Assert.AreEqual(_owner, _parkPlace.Owner);
            _owner.AttemptPurchase(_boardwalk);
            Assert.AreEqual(_owner, _boardwalk.Owner);
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.Develop();
            _parkPlace.LandedOn(_roller);
            Assert.AreEqual(200, _roller.Cash);
        }
    }
}
