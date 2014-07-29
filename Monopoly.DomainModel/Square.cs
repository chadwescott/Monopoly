namespace Monopoly.DomainModel
{
    public abstract class Square
    {
        private readonly string _name;
        private readonly int _index;

        private Square _nextSquare;

        protected Square(string name, int index)
        {
            _name = name;
            _index = index;
        }

        public void SetNextSquare(Square square)
        {
            _nextSquare = square;
        }

        public Square GetNextSquare()
        {
            return _nextSquare;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetIndex()
        {
            return _index;
        }

        public virtual void LandedOn(Player p)
        { }

        public virtual void Passed(Player p)
        { }
    }
}
