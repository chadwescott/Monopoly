using Monopoly.Squares;

namespace Monopoly.PurchasingStrategies
{
    public class NeverBuy : IPurchasingStrategy
    {
        public bool ShouldPurchase(Player p, PropertySquare s)
        {
            return false;
        }
    }
}
