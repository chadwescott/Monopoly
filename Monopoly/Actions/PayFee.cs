namespace Monopoly.Actions
{
    public class PayFee : IAction
    {
        private readonly int _fee;

        public PayFee(int fee)
        {
            _fee = fee;
        }

        public void Execute(Player initiator)
        {
            initiator.ReduceCash(_fee);
        }
    }
}
