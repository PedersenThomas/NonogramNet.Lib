using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib
{
    using System.Linq;
    using Model;

    public static class HashsetUtilities
    {
        public static IEnumerable<BoardChange> Transpose(this IEnumerable<BoardChange> changes)
        {
            return changes.Select(c => c.Transpose());
        }
        public static IEnumerable<BoardChange> Flip(this IEnumerable<BoardChange> changes, int width, int height)
        {
            return changes.Select(c => c.Flipped(width, height));
        }
    }
}
