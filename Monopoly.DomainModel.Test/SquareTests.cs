using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.DomainModel.Squares;

namespace Monopoly.DomainModel.Test
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void SetNextSquareTest()
        {
            var square1 = new RegularSquare("Square1", 0);
            var square2 = new RegularSquare("Square2", 1);
            square1.SetNextSquare(square2);
            square2.SetNextSquare(square1);

            Assert.AreEqual(square2, square1.GetNextSquare());
            Assert.AreEqual(square1, square2.GetNextSquare());
        }
    }
}
