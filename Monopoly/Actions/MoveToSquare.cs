namespace Monopoly.Actions
{
    public class MoveToSquare : IAction
    {
        private readonly Square _target;

        public MoveToSquare(Square target)
        {
            _target = target;
        }

        public void Execute(Player initiator)
        {
            initiator.SetLocation(_target);
        }
    }
}
