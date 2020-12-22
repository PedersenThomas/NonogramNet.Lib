using System;
using System.Collections.Generic;
using System.Text;

namespace Nonogramnet.lib
{
    public class Manifest
    {
        public string Title { get; }
        public string Author { get; }

        public Manifest(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
