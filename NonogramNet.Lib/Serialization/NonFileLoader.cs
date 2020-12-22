﻿namespace NonogramNet.Lib.Serialization
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
            using var reader = new StreamReader(stream, Encoding.UTF8);

            var title = string.Empty;
            var author = string.Empty;
            var width = -1;
            var height = -1;
            RulesMatrix topRules = null;
            RulesMatrix leftRules = null;
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if(string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var index = line.IndexOf(' ');
                if (index < 0)
                {
                    index = line.Length;
                }

                var key = line.Substring(0, index);
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

            var board = Board.MakeBoard(topRules, leftRules);
            var fileObject = new NonogramFile(title, author, board);

            return fileObject;
        }

        private static string ParseString(string line, int headerIndex)
        {
            var value = line.Substring(headerIndex + 1);
            return value.Trim('"');
        }

        private static bool TryParseInt(string line, int index, out int value)
        {
            var rawHeight = line.Substring(index);
            return int.TryParse(rawHeight, out value);
        }

        private static RulesMatrix ParseConstraint(StreamReader reader)
        {
            var rules = new List<List<int>>();
            while (true)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var values = new List<int>();
                var items = line.Split(",");
                foreach (var item in items)
                {
                    var value = int.Parse(item);
                    values.Add(value);
                }
                rules.Add(values);
            }

            return RulesMatrix.MakeRulesMatrix(rules);
        }
    }
}