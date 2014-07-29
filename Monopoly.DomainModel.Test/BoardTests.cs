using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.DomainModel.Test.Helpers;

namespace Monopoly.DomainModel.Test
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void GetSquareTest()
        {
            var fixture = BoardHelper.GetBoard();
            var startSquare = fixture.GetStartSquare();
            var squares = new ArrayList(40);
            squares.Add(startSquare);
            var currentSquare = startSquare;

            for (var i = 0; i < 39; i++)
            {
                Assert.AreEqual(i, currentSquare.GetIndex());
                var nextSquare = fixture.GetSquare(currentSquare, 1);
                Assert.AreEqual(nextSquare, currentSquare.GetNextSquare());
                squares.Add(nextSquare);
                currentSquare = nextSquare;
            }

            var lastSquare = (Square) squares[39];
            Assert.AreEqual(startSquare, lastSquare.GetNextSquare());
        }
    }
}
