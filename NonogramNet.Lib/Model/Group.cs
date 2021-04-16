namespace NonogramNet.Lib.Model
{
    using System.Diagnostics;

    [DebuggerDisplay("Index:{StartIndex} Count:{Count}, State:{State}")]
    public struct Group
    {
        public CellState State { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }

        public Group(CellState State, int StartIndex, int Count)
        {
            this.State = State;
            this.StartIndex = StartIndex;
            this.Count = Count;
        }
    }
}