namespace NonogramNet.Lib.Model
{
    using System.Collections.Generic;

    public interface IBoard
    {
        public IRulesMatrix TopRules { get; }

        public IRulesMatrix LeftRules { get; }
        public int Width { get; }

        public int Height { get; }

        public CellState this[int x, int y] { get; }

        IBoard ApplyChange(BoardChange change);

        IBoard ApplyChanges(IEnumerable<BoardChange> changes);

        IBoard ApplyChanges(params BoardChange[] changes);
    }
}