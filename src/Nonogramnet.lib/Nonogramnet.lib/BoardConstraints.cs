using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Nonogramnet.lib
{
    public struct BoardConstraints
    {
        public static BoardConstraints Empty = new BoardConstraints(ImmutableArray<ImmutableArray<int>>.Empty, ImmutableArray<ImmutableArray<int>>.Empty);

        private ImmutableArray<ImmutableArray<int>> Top;
        private ImmutableArray<ImmutableArray<int>> Left;

        public BoardConstraints(ImmutableArray<ImmutableArray<int>> top, ImmutableArray<ImmutableArray<int>> left)
        {
            this.Top = top;
            this.Left = left;
        }


    }
}
