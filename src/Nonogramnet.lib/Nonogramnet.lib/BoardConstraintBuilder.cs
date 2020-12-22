using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Nonogramnet.lib
{
    class BoardConstraintBuilder
    {
        private List<List<int>> Top;
        private List<List<int>> Left;

        public BoardConstraintBuilder()
        {
            Top = new List<List<int>>();
            Left = new List<List<int>>();
        }


        public void AddTop(List<int> column)
        {
            this.Top.Add(column);
        }

        public void AddLeft(List<int> row)
        {
            this.Left.Add(row);
        }

        public BoardConstraints Build()
        {
            var topBuilder = ImmutableArray.CreateBuilder<ImmutableArray<int>>();
            foreach (List<int> topColumn in Top)
            {
                topBuilder.Add(ImmutableArray.Create(topColumn.ToArray()));
            }

            var leftBuilder = ImmutableArray.CreateBuilder<ImmutableArray<int>>();
            foreach (List<int> leftRow in Left)
            {
                leftBuilder.Add(ImmutableArray.Create(leftRow.ToArray()));
            }

            return new BoardConstraints(topBuilder.ToImmutable(), leftBuilder.ToImmutable());
        }
    }
}
