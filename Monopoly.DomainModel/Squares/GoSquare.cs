namespace Monopoly.DomainModel.Squares
{
    public class GoSquare : Square
    {
        public int Salary { get { return 200; } }

        public GoSquare(string name, int index)
            : base(name, index)
        { }

        public override void Passed(Player p)
        {
            p.AddCash(Salary);
        }
    }
}
