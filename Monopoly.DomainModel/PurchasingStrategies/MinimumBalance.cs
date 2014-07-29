using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel.PurchasingStrategies
{
    /// <summary>
    /// A player will purchase a property as long as they would be left with a certain amount of money.
    /// </summary>
    public class MinimumBalance : IPurchasingStrategy
    {
        private readonly int _threshold;

        public MinimumBalance(int threshhold)
        {
            _threshold = threshhold;
        }

        public bool ShouldPurchase(Player p, PropertySquare s)
        {
            var cash = p.Cash;
            var price = s.Price;

            return cash - price >= _threshold;
        }
    }
}
