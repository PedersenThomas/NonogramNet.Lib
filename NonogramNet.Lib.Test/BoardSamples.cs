using System.Collections.Generic;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Test
{
    public static class BoardSamples
    {
        /*
         * XXX_X
         * XX_XX
         * X_X_X
         * X___X
         * _____
         */
        public static Board Board1 = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {4},
                new List<int> {2},
                new List<int> {1, 1},
                new List<int> {1},
                new List<int> {4}
            }),
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {3, 1},
                new List<int> {2, 2},
                new List<int> {1, 1, 1},
                new List<int> {1, 1}
            })
        );

        /*
         * _XX
         * _X_
         * X_X
         */
        public static Board Board2 = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {1},
                new List<int> {2},
                new List<int> {1, 1}
            }),
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {2},
                new List<int> {1},
                new List<int> {1, 1}
            })
        );
    }
}