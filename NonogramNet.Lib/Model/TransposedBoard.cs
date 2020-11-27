using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public class TransposedBoard : IBoard
    {
        private readonly IBoard _board;

        public TransposedBoard(IBoard board)
        {
            _board = board;
        }

        public RulesMatrix TopRules => this._board.LeftRules;
        public RulesMatrix LeftRules => this._board.TopRules;
        public int Width => this._board.Height;
        public int Height => this._board.Width;

        public CellState this[int x, int y] => this._board[y, x];

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
