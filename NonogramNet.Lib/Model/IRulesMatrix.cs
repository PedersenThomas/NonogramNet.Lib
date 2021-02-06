namespace NonogramNet.Lib.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRulesMatrix : IEnumerable<IRuleLine>
    {
        public int NumberOfRules { get; }

        public int this[int x, int y] { get; }

        public IRuleLine this[int x] { get; }
    }
}
