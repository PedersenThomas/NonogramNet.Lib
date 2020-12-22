using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nonogramnet.lib
{
    public class NonFileLoader
    {
        public static NonogramBoard? LoadFile(string path)
        {
            using (Stream stream = File.OpenRead(path))
            {
                return LoadStream(stream);
            }
        }

        // Format: https://github.com/mikix/nonogram-db/blob/master/FORMAT.md
        public static NonogramBoard? LoadStream(Stream stream)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8);

            string title = string.Empty;
            string author = string.Empty;
            int width = -1;
            int height = -1;
            var constrainBuilder = new BoardConstraintBuilder();
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                int index = line.IndexOf(' ');
                if (index <= 0)
                {
                    // unparesable lines are simply ignore.
                    continue;
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
                    ParseConstraint(reader, (row) => constrainBuilder.AddLeft(row));
                }
                else if (string.Equals(key, "columns", StringComparison.OrdinalIgnoreCase))
                {
                    ParseConstraint(reader, (column) => constrainBuilder.AddTop(column));
                }
                else if (string.Equals(key, "goal", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO Goal
                }
            }

            var manifest = new Manifest(title, author);

            var constraints = constrainBuilder.Build();
            return new NonogramBoard(width, height, constraints, manifest);
        }

        private static string ParseString(string line, int headerIndex)
        {
            var value = line.Substring(headerIndex+1);
            return value.Trim('"');
        }

        private static bool TryParseInt(string line, int index, out int value)
        {
            var rawHeight = line.Substring(index);
            return int.TryParse(rawHeight, out value);
        }

        private static void ParseConstraint(StreamReader reader, Action<List<int>> add)
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (String.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                var values = new List<int>();
                var items = line.Split(" ");
                foreach (var item in items)
                {
                    int value = int.Parse(item);
                    add(values);
                }
            }
        }
    }
}
