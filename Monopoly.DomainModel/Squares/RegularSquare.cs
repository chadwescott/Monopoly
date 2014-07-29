namespace Monopoly.DomainModel.Squares
{
    public class RegularSquare : Square
    {
        public RegularSquare(string name, int index)
            : base(name, index)
        { }

        public override void LandedOn(Player p)
        { }
    }
}
