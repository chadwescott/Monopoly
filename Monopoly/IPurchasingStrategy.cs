using Monopoly.Squares;

namespace Monopoly
{
    /// <summary>
    /// Defines when a player will purchase a property.
    /// </summary>
    public interface IPurchasingStrategy
    {
        bool ShouldPurchase(Player p, PropertySquare s);
    }
}
