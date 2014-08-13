namespace Monopoly.Squares
{
    public class LuxuryTaxSquare : Square
    {
        private const int FlatTax = 150;

        public LuxuryTaxSquare(string name, int index)
            : base(name, index)
        { }

        public override void LandedOn(Player p)
        {
            p.ReduceCash(FlatTax);
        }
    }
}
