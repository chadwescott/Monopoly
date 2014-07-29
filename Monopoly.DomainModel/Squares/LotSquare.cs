namespace Monopoly.DomainModel.Squares
{
    public class LotSquare : PropertySquare
    {
        public LotSquare(string name, int index, PropertyGroup @group, int price)
            : base(name, index, @group, price)
        { }

        protected override int GetRentAmount(Player p)
        {
            throw new System.NotImplementedException();
        }
    }
}
