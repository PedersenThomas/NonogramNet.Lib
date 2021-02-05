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
        }

        public CellState this[int x, int y] => throw new NotImplementedException();

        public RulesMatrix TopRules => throw new NotImplementedException();

        public RulesMatrix LeftRules => throw new NotImplementedException();

        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();

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
