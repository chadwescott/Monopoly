using System.Linq;

namespace Monopoly.Squares
{
    public class UtilitySquare : PropertySquare
    {
        public UtilitySquare(string name, int index, PropertyGroup @group, int price)
            : base(name, index, @group, price)
        { }

        protected override int GetRentAmount(Player p)
        {
            var rollTotal = p.GetRollTotal();
            var utilitiesOwned = Group.GetMembers().Count(r => r.Owner == Owner);
            var multiplier = utilitiesOwned == 1 ? 4 : 10;
            var amount = rollTotal*multiplier;
            return amount;
        }
    }
}
