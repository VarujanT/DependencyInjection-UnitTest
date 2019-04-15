using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public class Library
    {
        ITotalValueCalculator calc;
        public Library(ITotalValueCalculator clc)
        {
            calc = clc;
        }

        public IEnumerable<Book> Books { set; get; }

        public decimal TotalPrice()
        {
            return calc.SumOfPrice(Books);
        }
    }
}