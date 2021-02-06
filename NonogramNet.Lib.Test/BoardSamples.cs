using System.Collections.Generic;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Test
{
    using System.Net.NetworkInformation;

    public static class BoardSamples
    {
        /*
         * XXX_X
         * XX_XX
         * X_X_X
         * X___X
         * _____
         */
        public static IBoard Board1 = Board.MakeBoard(
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
                new List<int> {1, 1},
                new List<int>()
            })
        );

        /*
         * _XX
         * _X_
         * X_X
         */
        public static IBoard Board2 = Board.MakeBoard(
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

        /*
         * XXX
         * _XX
         * X_X
         */
        public static IBoard Board3 = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {1,1},
                new List<int> {2},
                new List<int> {3}
            }),
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {3},
                new List<int> {2},
                new List<int> {1, 1}
            })
        );

        /*
         * X_X
         * __X
         * X__
         */
        public static IBoard Board4 = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {1,1},
                new List<int> {},
                new List<int> {2}
            }),
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {1, 1},
                new List<int> {1},
                new List<int> {1}
            })
        );

        /*
         * X__
         * _XX
         * X__
         */
        public static IBoard Board5 = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {1,1},
                new List<int> {1},
                new List<int> {1}
            }),
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {1},
                new List<int> {2},
                new List<int> {1}
            })
        );


        /*
         */
        public static IBoard Board6 = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {3,3},
                new List<int> {1,1,1,1,2},
                new List<int> {1,1,1,1,3},
                new List<int> {1,1,3,3},
                new List<int> {1,1,3,3},
                new List<int> {1,1,1,1,3},
                new List<int> {1,1,1,1,2},
                new List<int> {3,3},
            }),
            RulesMatrix.MakeRulesMatrix(new List<List<int>>
            {
                new List<int> {6},
                new List<int> {1,1},
                new List<int> {8},
                new List<int> {1,1},
                new List<int> {1,1},
                new List<int> {4},
                new List<int> {2},
                new List<int> {2},
                new List<int> {1,1},
                new List<int> {1,1},
                new List<int> {1,1},
                new List<int> {1,4,1},
                new List<int> {8},
                new List<int> {6},
            })
        );

        /* ___XX
         * _____
         * _____
         * X____
         * X____
         * 
         */
        public static IBoard Board7 = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>> {
                new List<int> {2},
                new List<int>(),
                new List<int>(),
                new List<int> {1},
                new List<int> {1}}),
            RulesMatrix.MakeRulesMatrix(new List<List<int>> {
                new List<int> {2},
                new List<int>(),
                new List<int>(),
                new List<int> {1},
                new List<int> {1}})
            );

        /* ____X
         * ____X
         * _____
         * _____
         * XX___
         * 
         */
        public static IBoard Board7_ManualFlipped = Board.MakeBoard(
            RulesMatrix.MakeRulesMatrix(new List<List<int>> {
                new List<int> {1},
                new List<int> {1},
                new List<int> {},
                new List<int> {},
                new List<int> {2}}),
            RulesMatrix.MakeRulesMatrix(new List<List<int>> {
                new List<int> {1},
                new List<int> {1},
                new List<int> {},
                new List<int> {},
                new List<int> {2}})
            );
    }
}