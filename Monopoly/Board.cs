using System.Collections;

namespace Monopoly
{
    public class Board
    {
        private readonly int _size;
        private readonly ArrayList _squares;

        public Board(IBoardBuilder builder)
        {
            _size = builder.BoardSize;
            _squares = new ArrayList(_size);
            BuildSquares(builder);
            LinkSquares();
        }

        public Square GetSquare(Square start, int distance)
        {
            var endIndex = (start.GetIndex() + distance) % _size;
            return (Square) _squares[endIndex];
        }

        public Square GetStartSquare()
        {
            return (Square) _squares[0];
        }

        private void BuildSquares(IBoardBuilder builder)
        {
            _squares.AddRange(builder.BuildSquares());
        }

        private void LinkSquares()
        {
            for (var i = 0; i < (_size - 1); i++)
                Link(i);
            var first = GetStartSquare();
            var last = (Square) _squares[_size - 1];
            last.SetNextSquare(first);
        }

        private void Link(int i)
        {
            var current = (Square) _squares[i];
            var next = (Square) _squares[i + 1];
            current.SetNextSquare(next);
        }
    }
}
