using System.Linq;
using Monopoly.DomainModel.PurchasingStrategies;
using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel
{
    public class Player
    {
        private readonly string _name;
        private readonly Board _board;
        private readonly IDie[] _dice;

        private Square _location;
        private IPurchasingStrategy _purchasingStrategy;

        public int Cash { get; private set; }

        public Player(string name, IDie[] dice, Board board)
        {
            _name = name;
            _dice = dice;
            _board = board;
            _location = _board.GetStartSquare();
            _purchasingStrategy = new AlwaysBuy();
        }

        public void TakeTurn()
        {
            foreach (var die in _dice)
                die.Roll();

            var rollTotal = GetRollTotal();
            for (var i = 0; i < rollTotal; i++)
            {
                _location = _board.GetSquare(_location, 1);
                _location.Passed(this);
            }

            _location.LandedOn(this);
        }

        public int GetRollTotal()
        {
            return _dice.Sum(die => die.GetFaceValue());
        }

        public bool RolledDoubles()
        {
            var faceValue = _dice.First().GetFaceValue();
            return _dice.All(d => d.GetFaceValue() == faceValue);
        }

        public Square GetLocation()
        {
            return _location;
        }

        public string GetName()
        {
            return _name;
        }

        public void AttemptPurchase(PropertySquare s)
        {
            var price = s.Price;
            if (Cash < price) return;
            if (!_purchasingStrategy.ShouldPurchase(this, s)) return;
            s.Owner = this;
            ReduceCash(price);
        }

        public void AddCash(int amount)
        {
            Cash += amount;
        }

        public void ReduceCash(int amount)
        {
            Cash -= amount;
        }
    }
}
