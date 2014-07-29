namespace Monopoly.DomainModel.Squares
{
    public abstract class PropertySquare : Square
    {
        public PropertyGroup Group { get; private set; }
        public int Price { get; private set; }

        public Player Owner { get; set; }

        protected PropertySquare(string name, int index, PropertyGroup @group, int price)
            : base(name, index)
        {
            Group = @group;
            Group.AddProperty(this);
            Price = price;
        }

        public override void LandedOn(Player p)
        {
            if (Owner == null)
                p.AttemptPurchase(this);
            else if (Owner != p)
                PayRent(p);
        }

        private void PayRent(Player p)
        {
            var amount = GetRentAmount(p);
            Owner.AddCash(amount);
            p.ReduceCash(amount);
        }

        protected abstract int GetRentAmount(Player p);
    }
}
