using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Actions;
using Monopoly.UnitTests.Helpers;

namespace Monopoly.UnitTests.Actions
{
    [TestClass]
    public class GiveToAllPlayersTest
    {
        private GiveToAllPlayers _target;
        private Player _player;
        private MonopolyGame _game;
        private int _initialCash;
        private const int Amount = 100;

        [TestInitialize]
        public void TestInitialize()
        {
            _game = new MonopolyGame(BoardBuilderHelper.GetBoardBuilder());
            _game.AddPlayer("Car");
            _player = _game.GetPlayers().Single();
            _initialCash = _player.Cash;
            _target = new GiveToAllPlayers(_game, Amount);
        }

        [TestMethod]
        public void GiveToAllPlayersOneOtherPlayerTest()
        {
            _game.AddPlayer("Horse");
            _target.Execute(_player);

            var expected = _initialCash + Amount;
            foreach (var player in _game.GetPlayers().Where(p => p != _player))
                Assert.AreEqual(expected, player.Cash);

            Assert.AreEqual(GetExpectedReducedCash(), _player.Cash);
        }

        private int GetExpectedReducedCash()
        {
            return _initialCash - (Amount*(_game.GetPlayers().Count - 1));
        }

        [TestMethod]
        public void GiveToAllPlayersTwoOtherPlayersTest()
        {
            _game.AddPlayer("Horse");
            _game.AddPlayer("Thimble");
            _target.Execute(_player);

            var expected = _initialCash + Amount;
            foreach (var player in _game.GetPlayers().Where(p => p != _player))
                Assert.AreEqual(expected, player.Cash);

            Assert.AreEqual(GetExpectedReducedCash(), _player.Cash);
        }

        [TestMethod]
        public void ReceiveFromAllPlayersOneOtherPlayerTest()
        {
            _target = new GiveToAllPlayers(_game, -Amount);
            _game.AddPlayer("Horse");
            _target.Execute(_player);

            var expected = _initialCash - Amount;
            foreach (var player in _game.GetPlayers().Where(p => p != _player))
                Assert.AreEqual(expected, player.Cash);

            Assert.AreEqual(GetExpectedAdddCash(), _player.Cash);
        }

        private int GetExpectedAdddCash()
        {
            return _initialCash + (Amount * (_game.GetPlayers().Count - 1));
        }

        [TestMethod]
        public void ReceiveFromAllPlayersTwoOtherPlayersTest()
        {
            _target = new GiveToAllPlayers(_game, -Amount);
            _game.AddPlayer("Horse");
            _game.AddPlayer("Thimble");
            _target.Execute(_player);

            var expected = _initialCash - Amount;
            foreach (var player in _game.GetPlayers().Where(p => p != _player))
                Assert.AreEqual(expected, player.Cash);

            Assert.AreEqual(GetExpectedAdddCash(), _player.Cash);
        }
    }
}
