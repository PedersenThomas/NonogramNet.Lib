using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Nonogramnet.lib.test
{
    public class FileparserTest
    {
        [Fact]
        public void ParseExampleFile()
        {
            var loadedBoard = NonFileLoader.LoadFile("TestBoards/example.non");

            Assert.Equal("Demo Puzzle from Front Page", loadedBoard.Manifest.Title);
        }
    }
}
