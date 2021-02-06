namespace NonogramNet.Lib.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Model;

    public class NonFileLoader
    {
        public static NonogramFile? LoadFile(string path)
        {
            using (Stream stream = File.OpenRead(path))
            {
                return LoadStream(stream);
            }
        }

        // Format: https://github.com/mikix/nonogram-db/blob/master/FORMAT.md
        public static NonogramFile? LoadStream(Stream stream)
        {
            using StreamReader? reader = new StreamReader(stream, Encoding.UTF8);

            string? title = string.Empty;
            string? author = string.Empty;
            int width = -1;
            int height = -1;
            RulesMatrix? topRules = null;
            RulesMatrix? leftRules = null;
            while (true)
            {
                string? line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if(string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                int index = line.IndexOf(' ');
                if (index < 0)
                {
                    index = line.Length;
                }

                string? key = line.Substring(0, index);
                if (string.Equals(key, "title", StringComparison.OrdinalIgnoreCase))
                {
                    title = ParseString(line, index);
                }
                else if (string.Equals(key, "author", StringComparison.OrdinalIgnoreCase))
                {
                    author = ParseString(line, index);
                }
                else if (string.Equals(key, "by", StringComparison.OrdinalIgnoreCase))
                {
                    author = ParseString(line, index);
                }
                else if (string.Equals(key, "width", StringComparison.OrdinalIgnoreCase))
                {
                    TryParseInt(line, index, out width);
                }
                else if (string.Equals(key, "height", StringComparison.OrdinalIgnoreCase))
                {
                    TryParseInt(line, index, out height);
                }
                else if (string.Equals(key, "rows", StringComparison.OrdinalIgnoreCase))
                {
                    leftRules = ParseConstraint(reader);
                }
                else if (string.Equals(key, "columns", StringComparison.OrdinalIgnoreCase))
                {
                    topRules = ParseConstraint(reader);
                }
                else if (string.Equals(key, "goal", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO Goal
                }
            }

            if(topRules == null)
            {
                throw new ArgumentNullException(nameof(topRules), "There were no columns section in the file. (Internally known as TopRules)");
            }

            if (leftRules == null)
            {
                throw new ArgumentNullException(nameof(leftRules), "There were no rows section in the file. (Internally known as LeftRules)");
            }
            Board? board = Board.MakeBoard(topRules, leftRules);
            NonogramFile? fileObject = new NonogramFile(title, author, board);

            return fileObject;
        }

        private static string ParseString(string line, int headerIndex)
        {
            string? value = line.Substring(headerIndex + 1);
            return value.Trim('"');
        }

        private static bool TryParseInt(string line, int index, out int value)
        {
            string? rawHeight = line.Substring(index);
            return int.TryParse(rawHeight, out value);
        }

        private static RulesMatrix ParseConstraint(StreamReader reader)
        {
            List<List<int>>? rules = new List<List<int>>();
            while (true)
            {
                string? line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                List<int>? values = new List<int>();
                string[]? items = line.Split(",");
                foreach (string? item in items)
                {
                    int value = int.Parse(item);
                    values.Add(value);
                }
                rules.Add(values);
            }

            return RulesMatrix.MakeRulesMatrix(rules);
        }
    }
}