using System.Collections;
using System.Linq;

namespace Monopoly.DomainModel
{
    public class MonopolyGame
    {
        private const int RoundsTotal = 20;
        private const int PlayersTotal = 2;
        private readonly IList _players = new ArrayList(PlayersTotal);
        private readonly Board _board = new Board(new HardCodedBoardBuilder());
        private readonly IDie[] _dice = { new Die(), new Die() };

        public MonopolyGame()
        {
            _players.Add(new Player("Horse", _dice, _board));
            _players.Add(new Player("Car", _dice, _board));
        }

        public void PlayGame()
        {
            for (var i = 0; i < RoundsTotal; i++)
                PlayRound();
        }

        public IList GetPlayers()
        {
            return _players;
        }

        private void PlayRound()
        {
            foreach (var player in _players.Cast<Player>())
                player.TakeTurn();
        }
    }
}
