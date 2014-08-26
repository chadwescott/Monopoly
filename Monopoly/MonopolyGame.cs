using System.Collections.Generic;

namespace Monopoly
{
    public class MonopolyGame
    {
        private const int RoundsTotal = 20;
        private readonly IList<Player> _players = new List<Player>();
        private readonly Board _board;
        private readonly IDie[] _dice = { new Die(), new Die() };

        public MonopolyGame(IBoardBuilder builder)
        {
            _board = new Board(builder);
        }

        public void AddPlayer(string name)
        {
            _players.Add(new Player(name, _dice, _board));
        }

        public void PlayGame()
        {
            for (var i = 0; i < RoundsTotal; i++)
                PlayRound();
        }

        public IList<Player> GetPlayers()
        {
            return _players;
        }

        private void PlayRound()
        {
            foreach (var player in _players)
                player.TakeTurn();
        }
    }
}
