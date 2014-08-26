namespace Monopoly
{
    public interface IAction
    {
        void Execute(Player initiator);
    }
}
