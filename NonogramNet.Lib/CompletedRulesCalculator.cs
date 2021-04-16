using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib
{
    /* Given a Board, it calculates, which rules are certainly completed.
     */
    public class CompletedRulesCalculator
    {
        public CompletedBoardRules CalculateForBoard(IBoard board)
        {
            var topCompleted = this.CalculateVerticalMarker(board);
            var leftCompleted = this.CalculateVerticalMarker(new TransposedBoard(board));

            return new CompletedBoardRules(topCompleted, leftCompleted);
        }

        private List<List<CompletedRuleMarker>> CalculateVerticalMarker(IBoard board)
        {
            var resultMatrix = new List<List<CompletedRuleMarker>>();

            for (int x = 0; x < board.Width; x++)
            {
                bool lineIsCompleted = false;
                bool markersNeedSorting = true;
                int currentRuleIndex = 0;
                var markerList = new List<CompletedRuleMarker>();
                resultMatrix.Add(markerList);
                var verticalGroup = SimpleGrouper.GroupVertical(board, x);
                IRuleLine rulesLine = board.TopRules[x];

                if(verticalGroup.SatisfiesRuleLine(rulesLine))
                {
                    foreach (Group group in verticalGroup.FilledGroups)
                    {
                        markerList.Add(new CompletedRuleMarker(currentRuleIndex, group.StartIndex));
                        currentRuleIndex += 1;
                    }
                    // Every rule in the line is completed, so continue to the next.
                    continue;
                }

                // Going from top to bottom.
                foreach (var group in verticalGroup.Groups)
                {
                    switch (group.State)
                    {
                        case CellState.None:
                            // TODO, even though a "None" is found, it is possible in some cases to find rules that with certainty can be marked as satisfied.
                            lineIsCompleted = true;
                            break;
                        case CellState.Filled:
                            if(group.Count == rulesLine[currentRuleIndex])
                            {
                                markerList.Add(new CompletedRuleMarker(currentRuleIndex, group.StartIndex));
                                currentRuleIndex += 1;
                                if(currentRuleIndex >= rulesLine.Count)
                                {
                                    lineIsCompleted = true;
                                }
                            }
                            break;
                        case CellState.Blocked:
                            break;
                        default:
                            break;
                    }
                    if(lineIsCompleted)
                    {
                        break;
                    }
                }

                // Going bottom-up
                lineIsCompleted = false;
                currentRuleIndex = rulesLine.Count - 1;
                foreach (var group in ((IEnumerable<Group>)verticalGroup.Groups).Reverse())
                {
                    switch (group.State)
                    {
                        case CellState.None:
                            // TODO, even though a "None" is found, it is possible in some cases to find rules that with certainty can be marked as satisfied.
                            lineIsCompleted = true;
                            break;
                        case CellState.Filled:
                            if (group.Count == rulesLine[currentRuleIndex])
                            {
                                markerList.Add(new CompletedRuleMarker(currentRuleIndex, group.StartIndex));
                                currentRuleIndex -= 1;
                                markersNeedSorting = true;
                                if (currentRuleIndex <= 0)
                                {
                                    lineIsCompleted = true;
                                }
                            }
                            break;
                        case CellState.Blocked:
                            break;
                        default:
                            break;
                    }
                    if (lineIsCompleted)
                    {
                        break;
                    }
                }

                if (markersNeedSorting)
                {
                    markerList.Sort();
                }
            }

            return resultMatrix;
        }
    }
}
