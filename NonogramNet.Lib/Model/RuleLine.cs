namespace NonogramNet.Lib.Model
{
    using System.Collections;
    using System.Collections.Generic;

    public class RuleLine : IRuleLine
    {
        private readonly IList<int> rawLine;

        public RuleLine(IList<int> rawLine)
        {
            this.rawLine = rawLine;
        }

        public int this[int x] => this.rawLine[x];

        public int Count => this.rawLine.Count;

        public IEnumerator<int> GetEnumerator()
        {
            return this.rawLine.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.rawLine.GetEnumerator();
        }
    }
}
