using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Monopoly.DomainModel.Test.FunctionalTests
{
    [TestClass]
    public class MovePlayerTests
    {
        private Player _player;
        private Board _board;
        private const int StartCash = 1500;

        [TestInitialize]
        public void TestInitialize()
        {
            _board = new Board(new HardCodedBoardBuilder());
            var die = MockRepository.GenerateStub<IDie>();
            die.Stub(s => s.GetFaceValue()).Return(3);
            IDie[] dice = {die};
            _player = new Player("Car", dice, _board);
            _player.AddCash(StartCash);
        }

        /// <summary>
        /// When the player passes go he should collect $200 so this tests starts him on the square before Go and has him
        /// roll a 3 to land on Community Chest, which does nothing right now.
        /// </summary>
        [TestMethod]
        public void PlayerPassesGoTest()
        {
            _player.SetLocation(_board.GetSquare(_player.GetLocation(), 39));
            _player.TakeTurn();
            const int expected = StartCash + 200;
            Assert.AreEqual(expected, _player.Cash);
        }
    }
}
