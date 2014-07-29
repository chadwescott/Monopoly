using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel
{
    internal class HardCodedBoardBuilder : IBoardBuilder
    {
        public int BoardSize
        {
            get { return 40; }
        }

        public Square[] BuildSquares()
        {
            var squares = new Square[BoardSize];

            var railroadGroup = new PropertyGroup();
            var utilityGroup = new PropertyGroup();
            var indigoGroup = new PropertyGroup();
            var skyBlueGroup = new PropertyGroup();
            var darkOrchidGroup = new PropertyGroup();
            var orangeGroup = new PropertyGroup();
            var redGroup = new PropertyGroup();
            var yellowGroup = new PropertyGroup();
            var greenGroup = new PropertyGroup();
            var blueGroup = new PropertyGroup();

            squares[0] = new GoSquare("Go", 0);
            squares[1] = new BuildableSquare("Mediterranean Avenue", 1, indigoGroup, 60, 50, 0, 0, 0, 0, 0, 0);
            squares[2] = new RegularSquare("Community Chest", 2);
            squares[3] = new BuildableSquare("Baltic Avenue", 3, indigoGroup, 60, 50, 0, 0, 0, 0, 0, 0);
            squares[4] = new IncomeTaxSquare("Income Tax", 4);
            squares[5] = new RailroadSquare("Reading Railroad", 5, railroadGroup, 200);
            squares[6] = new BuildableSquare("Oriental Avenue", 6, skyBlueGroup, 100, 0, 0, 0, 0, 0, 0, 0);
            squares[7] = new RegularSquare("Chance", 7);
            squares[8] = new BuildableSquare("Vermont Avenue", 8, skyBlueGroup, 100, 0, 0, 0, 0, 0, 0, 0);
            squares[9] = new BuildableSquare("Connecticut Avenue", 9, skyBlueGroup, 120, 0, 0, 0, 0, 0, 0, 0);
            squares[10] = new RegularSquare("In Jail/Just Visiting", 10);
            squares[11] = new BuildableSquare("St. Charles Place", 11, darkOrchidGroup, 140, 100, 0, 0, 0, 0, 0, 0);
            squares[12] = new UtilitySquare("Electric Company", 12, utilityGroup, 150);
            squares[13] = new BuildableSquare("States Avenue", 13, darkOrchidGroup, 140, 100, 0, 0, 0, 0, 0, 0);
            squares[14] = new BuildableSquare("Virginia Avenue", 14, darkOrchidGroup, 160, 100, 0, 0, 0, 0, 0, 0);
            squares[15] = new RailroadSquare("Pennsylvania Railroad", 15, railroadGroup, 200);
            squares[16] = new BuildableSquare("St. James Place", 16, orangeGroup, 180, 100, 0, 0, 0, 0, 0, 0);
            squares[17] = new RegularSquare("Community Chest", 17);
            squares[18] = new BuildableSquare("Tennessee Avenue", 18, orangeGroup, 180, 100, 0, 0, 0, 0, 0, 0);
            squares[19] = new BuildableSquare("New York Avenue", 19, orangeGroup, 200, 100, 0, 0, 0, 0, 0, 0);
            squares[20] = new RegularSquare("Free Parking", 20);
            squares[21] = new BuildableSquare("Kentucky Avenue", 21, redGroup, 220, 150, 0, 0, 0, 0, 0, 0);
            squares[22] = new RegularSquare("Chance", 22);
            squares[23] = new BuildableSquare("Indiana Avenue", 23, redGroup, 220, 150, 0, 0, 0, 0, 0, 0);
            squares[24] = new BuildableSquare("Illinois Avenue", 24, redGroup, 240, 150, 0, 0, 0, 0, 0, 0);
            squares[25] = new RailroadSquare("B&O Railroad", 25, railroadGroup, 200);
            squares[26] = new BuildableSquare("Atlantic Avenue", 26, yellowGroup, 260, 150, 0, 0, 0, 0, 0, 0);
            squares[27] = new BuildableSquare("Ventnor Avenue", 27, yellowGroup, 260, 150, 0, 0, 0, 0, 0, 0);
            squares[28] = new UtilitySquare("Water Works", 28, utilityGroup, 150);
            squares[29] = new BuildableSquare("Marvin Gardens", 29, yellowGroup, 280, 150, 0, 0, 0, 0, 0, 0);
            squares[30] = new RegularSquare("Go To Jail", 30);
            squares[31] = new BuildableSquare("Pacific Avenue", 31, greenGroup, 300, 200, 0, 0, 0, 0, 0, 0);
            squares[32] = new BuildableSquare("North Carolina Avenue", 32, greenGroup, 300, 200, 0, 0, 0, 0, 0, 0);
            squares[33] = new RegularSquare("Community Chest", 33);
            squares[34] = new BuildableSquare("Pennsylvania Avenue", 34, greenGroup, 320, 200, 0, 0, 0, 0, 0, 0);
            squares[35] = new RailroadSquare("Short Line", 35, railroadGroup, 200);
            squares[36] = new RegularSquare("Chance", 36);
            squares[37] = new BuildableSquare("Park Place", 37, blueGroup, 350, 200, 0, 0, 0, 0, 0, 0);
            squares[38] = new LuxuryTaxSquare("Luxury Tax", 38);
            squares[39] = new BuildableSquare("Boardwalk", 39, blueGroup, 400, 200, 0, 0, 0, 0, 0, 0);

            return squares;
        }
    }
}
