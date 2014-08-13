using System;

namespace Monopoly.Squares
{
    public class IncomeTaxSquare : Square
    {
        private const int FlatTax = 200;
        private const double TaxRate = .15;

        public IncomeTaxSquare(string name, int index)
            : base(name, index)
        { }

        public override void LandedOn(Player p)
        {
            var cash = p.Cash;
            var percentTax = Math.Round(cash*TaxRate);
            var taxAmount = (int)Math.Min(percentTax, FlatTax);
            p.ReduceCash(taxAmount);
        }
    }
}
