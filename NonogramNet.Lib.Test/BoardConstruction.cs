using System;
using System.Collections.Generic;
using System.Data;
using NonogramNet.Lib.Model;
using Xunit;

namespace NonogramNet.Lib.Test
{
    public class BoardConstruction
    {
        [Fact]
        public void BoardNoMatrix()
        {
            /*
             * x_x
             * xx_
             */

            var topRules = RulesMatrix.MakeRulesMatrix(new List<List<int>>()
            {
                new List<int>() {2},
                new List<int>() {1},
                new List<int>() {1}
            });

            var leftRules = RulesMatrix.MakeRulesMatrix(new List<List<int>>()
            {
                new List<int>(){1,1},
                new List<int>(){2}
            });
            var board = Board.MakeBoard(topRules, leftRules);
        }

        [Fact]
        public void BoardWithMatrix()
        {
            /*
             * x_x
             * xx_
             */

            var topRules = RulesMatrix.MakeRulesMatrix(new List<List<int>>()
            {
                new List<int>() {2},
                new List<int>() {1},
                new List<int>() {1}
            });

            var leftRules = RulesMatrix.MakeRulesMatrix(new List<List<int>>()
            {
                new List<int>(){1,1},
                new List<int>(){2}
            });

            CellState[,] matrix = new CellState[3,2];
            matrix[2, 1] = CellState.Blocked;
            var board = Board.MakeBoard(topRules, leftRules, matrix);
            Assert.NotNull(board);
            Assert.Equal(matrix[2, 1], board[2,1]);
        }

        [Fact]
        public void NullRules()
        {
            Assert.Throws<ArgumentNullException>(() => Board.MakeBoard(null, null));
        }
    }
}
