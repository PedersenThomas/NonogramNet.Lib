namespace NonogramNet.Lib.Test.Serialization
{
    using System.Collections.Generic;
    using Lib.Serialization;
    using Model;
    using Xunit;

    public class NonFileLoaderTest
    {
        [Fact]
        public void SampleBoard1()
        {
            var loadedBoard = NonFileLoader.LoadFile("TestBoards/Example1.non");

            Assert.Equal("Demo Puzzle from Front Page", loadedBoard.Title);
            Assert.Equal("Jan Wolter", loadedBoard.Author);

            var expectedTopRules = RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {2, 1},
                new List<int> {2, 1, 3},
                new List<int> {7},
                new List<int> {1, 3},
                new List<int> {2, 1}
            });
            Assert.Equal(expectedTopRules, loadedBoard.Board.TopRules);

            var expectedLeftRules = RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {2},
                new List<int> {2, 1},
                new List<int> {1, 1},
                new List<int> {3},
                new List<int> {1, 1},
                new List<int> {1, 1},
                new List<int> {2},
                new List<int> {1, 1},
                new List<int> {1, 2},
                new List<int> {2}
            });
            Assert.Equal(expectedLeftRules, loadedBoard.Board.LeftRules);
        }
    }
}