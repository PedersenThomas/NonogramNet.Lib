using System.Collections.Generic;

namespace NonogramNet.Lib.Model
{
    public interface IRuleLine : IEnumerable<int>
    {
        public int Count { get; }

        public int this[int x] { get; }
    }
}
