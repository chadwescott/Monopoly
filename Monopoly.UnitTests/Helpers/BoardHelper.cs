using Rhino.Mocks;

namespace Monopoly.UnitTests.Helpers
{
    public static class BoardHelper
    {
        public static Board GetBoard()
        {
            return MockRepository.GenerateStub<Board>(BoardBuilderHelper.GetBoardBuilder());
        }
    }
}
