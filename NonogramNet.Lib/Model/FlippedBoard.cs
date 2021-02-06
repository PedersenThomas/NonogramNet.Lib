using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public class FlippedBoard : IBoard
    {
        private readonly IBoard board;


        public FlippedBoard(IBoard board)
        {
            this.board = board;
            this.TopRules = new FlippedRuleMatrix(board.TopRules);
            this.LeftRules = new FlippedRuleMatrix(board.LeftRules);
        }

        public CellState this[int x, int y] => this.board[this.board.Width - x - 1, this.board.Height - y - 1];

        public IRulesMatrix TopRules { get; }

        public IRulesMatrix LeftRules { get; }

        public int Width => this.board.Width;

        public int Height => this.board.Height;

        public IBoard ApplyChange(BoardChange change)
        {
            throw new NotImplementedException();
        }

        public IBoard ApplyChanges(IEnumerable<BoardChange> changes)
        {
            throw new NotImplementedException();
        }

        public IBoard ApplyChanges(params BoardChange[] changes)
        {
            throw new NotImplementedException();
        }
    }
}
