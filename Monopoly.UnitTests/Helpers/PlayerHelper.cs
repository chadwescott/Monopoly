namespace Monopoly.UnitTests.Helpers
{
    public static class PlayerHelper
    {
        public static Player CreatePlayer(string name, Board board)
        {
            var die = new Die();
            IDie[] dice = { die };
            return new Player(name, dice, board);
        }
    }
}
