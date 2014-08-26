using System.Linq;

namespace Monopoly.Actions
{
    public class GiveToAllPlayers : IAction
    {
        private readonly MonopolyGame _game;
        private readonly int _amount;

        public GiveToAllPlayers(MonopolyGame game, int amount)
        {
            _game = game;
            _amount = amount;
        }

        public void Execute(Player initiator)
        {
            foreach (var player in _game.GetPlayers().Where(player => player != initiator))
            {
                player.AddCash(_amount);
                initiator.ReduceCash(_amount);
            }
        }
    }
}
