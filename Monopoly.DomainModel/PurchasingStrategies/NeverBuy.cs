using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel.PurchasingStrategies
{
    public class NeverBuy : IPurchasingStrategy
    {
        public bool ShouldPurchase(Player p, PropertySquare s)
        {
            return false;
        }
    }
}
