using Rhino.Mocks;

namespace Monopoly.DomainModel.Test.Helpers
{
    public static class BoardHelper
    {
        public static Board GetBoard()
        {
            return MockRepository.GenerateStub<Board>(BoardBuilderHelper.GetBoardBuilder());
        }
    }
}
