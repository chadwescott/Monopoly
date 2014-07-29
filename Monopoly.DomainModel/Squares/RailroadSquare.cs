using System;
using System.Linq;

namespace Monopoly.DomainModel.Squares
{
    public class RailroadSquare : PropertySquare
    {
        public RailroadSquare(string name, int index, PropertyGroup @group, int price)
            : base(name, index, @group, price)
        { }

        protected override int GetRentAmount(Player p)
        {
            var railroadsOwned = Group.GetMembers().Count(r => r.Owner == Owner);
            var amount = (int)Math.Pow(2, railroadsOwned - 1) * 25;
            return amount;
        }
    }
}
