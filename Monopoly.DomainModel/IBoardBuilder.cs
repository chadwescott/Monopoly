using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel
{
    public interface IBoardBuilder
    {
        int BoardSize { get; }
        RailroadSquare[] GetRailroadSquares();
        Square[] BuildSquares();
    }
}
