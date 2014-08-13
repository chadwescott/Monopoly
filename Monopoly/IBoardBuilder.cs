using Monopoly.Squares;

namespace Monopoly
{
    public interface IBoardBuilder
    {
        int BoardSize { get; }
        RailroadSquare[] GetRailroadSquares();
        Square[] BuildSquares();
    }
}
