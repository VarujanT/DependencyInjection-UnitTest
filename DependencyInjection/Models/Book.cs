using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public enum BookCategory { None, Gexarvetakan, Programming, Scientific }
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public BookCategory Category { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return Author + "\t" + Title + "\t" + Category + "\t" + Price.ToString("C");
        }
    }
}