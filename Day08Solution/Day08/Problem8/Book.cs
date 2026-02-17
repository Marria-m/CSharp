using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Problem8
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        // default constructor
        public Book() : this("Unknown Title", "Unknown Author") { }

        // Title only
        public Book(string title) : this(title, "Unknown Author") { }

        // Both
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return "\"" + Title + "\" by " + Author;
        }
    }
}
