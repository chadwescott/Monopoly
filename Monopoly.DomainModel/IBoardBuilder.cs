namespace Monopoly.DomainModel
{
    public interface IBoardBuilder
    {
        int BoardSize { get; }
        Square[] BuildSquares();
    }
}
