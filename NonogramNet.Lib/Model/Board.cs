using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public class Board
    {
        public RulesMatrix TopRules { get; set; }
        public RulesMatrix LeftRules { get; set; }

        private CellState[,] matrix;

        public Board(RulesMatrix topRules, RulesMatrix leftRules)
        {
            this.TopRules = topRules;
            this.LeftRules = leftRules;
            matrix = new CellState[topRules.NumberOfRules, leftRules.NumberOfRules];
        }


    }
}
