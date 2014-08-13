using Monopoly.Squares;

namespace Monopoly.PurchasingStrategies
{
    public class AlwaysBuy : IPurchasingStrategy
    {
        public bool ShouldPurchase(Player p, PropertySquare s)
        {
            return true;
        }
    }
}
