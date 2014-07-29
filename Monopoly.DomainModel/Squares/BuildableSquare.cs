using System.Collections.Generic;
using System.Linq;

namespace Monopoly.DomainModel.Squares
{
    public class BuildableSquare : PropertySquare
    {
        private readonly int _developmentCost;
        private readonly Dictionary<DevelopmentLevel, int> _rentDictionary;

        private DevelopmentLevel _developmentLevel = DevelopmentLevel.EmptyLot;

        public DevelopmentLevel Delopment { get { return _developmentLevel; } }

        public BuildableSquare(string name, int index, PropertyGroup @group, int price, int developmentCost, int baseRent,
            int oneHouseRent, int twoHouseRent, int threeHouseRent, int fourHouseRent, int hotelRent)
            : base(name, index, @group, price)
        {
            _developmentCost = developmentCost;
            _rentDictionary = new Dictionary<DevelopmentLevel, int>
            {
                {DevelopmentLevel.EmptyLot, baseRent},
                {DevelopmentLevel.OneHouse, oneHouseRent},
                {DevelopmentLevel.TwoHouses, twoHouseRent},
                {DevelopmentLevel.ThreeHouses, threeHouseRent},
                {DevelopmentLevel.FourHouses, fourHouseRent},
                {DevelopmentLevel.Hotel, hotelRent}
            };
        }

        public bool CanBuild()
        {
            return Owner != null
                && Group.GetMembers().All(m => m.Owner == Owner)
                && Owner.Cash >= _developmentCost
                && _developmentLevel != DevelopmentLevel.Hotel;
        }

        public void Develop()
        {
            Owner.ReduceCash(_developmentCost);
            _developmentLevel++;
        }

        public int GetDevelopmentCost()
        {
            return _developmentCost;
        }

        public DevelopmentLevel GetDevelopmentLevel()
        {
            return _developmentLevel;
        }

        protected override int GetRentAmount(Player p)
        {
            return _rentDictionary[_developmentLevel];
        }
    }
}
