using System.Collections;
using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel
{
    public class Board
    {
        private const int Size = 40;
        private readonly ArrayList _squares = new ArrayList(Size);

        public Board()
        {
            BuildSquares();
            LinkSquares();
        }

        public Square GetSquare(Square start, int distance)
        {
            var endIndex = (start.GetIndex() + distance) % Size;
            return (Square) _squares[endIndex];
        }

        public Square GetStartSquare()
        {
            return (Square) _squares[0];
        }

        private void BuildSquares()
        {
            for (var i = 1; i <= Size; i++)
                Build(i);
        }

        private void Build(int i)
        {
            var s = new RegularSquare("Square " + i, i - 1);
            _squares.Add(s);
        }

        private void LinkSquares()
        {
            for (var i = 0; i < (Size - 1); i++)
                Link(i);
            var first = GetStartSquare();
            var last = (Square) _squares[Size - 1];
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
