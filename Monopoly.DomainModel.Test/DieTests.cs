using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monopoly.DomainModel.Test
{
    [TestClass]
    public class DieTests
    {
        private readonly Die _fixture = new Die();
        private const int RollsMax = 100;

        [TestMethod]
        public void DiceRollTest()
        {
            for (var i = 0; i < RollsMax; i++)
            {
                _fixture.Roll();
                var faceValue = _fixture.GetFaceValue();
                Assert.IsTrue(faceValue > 0 && faceValue < 7);
            }
        }
    }
}
