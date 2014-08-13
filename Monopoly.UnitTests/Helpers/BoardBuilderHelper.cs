using Monopoly.Squares;
using Rhino.Mocks;

namespace Monopoly.UnitTests.Helpers
{
    public static class BoardBuilderHelper
    {
        public static IBoardBuilder GetBoardBuilder()
        {
            var boardBuilder = MockRepository.GenerateStub<IBoardBuilder>();
            boardBuilder.Stub(s => s.BoardSize).Return(40);
            boardBuilder.Stub(s => s.BuildSquares()).Return(BuildSquares());
            return boardBuilder;
        }

        private static Square[] BuildSquares()
        {
            var squares = new Square[40];
            for (var i = 1; i <= 40; i++)
                squares[i - 1] = new RegularSquare("Square " + i, i - 1);
            return squares;
        }
    }
}
