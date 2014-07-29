using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel.PurchasingStrategies
{
    public class AlwaysBuy : IPurchasingStrategy
    {
        public bool ShouldPurchase(Player p, PropertySquare s)
        {
            return true;
        }
    }
}
