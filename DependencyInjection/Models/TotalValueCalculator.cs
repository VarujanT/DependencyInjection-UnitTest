using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public class TotalValueCalculator : ITotalValueCalculator
    {
        IDiscount discount;
        public TotalValueCalculator(IDiscount disc)
        {
            discount = disc;
        }
        public decimal SumOfPrice(IEnumerable<Book> books)
        {
            return discount.ApplyDiscount(books.Sum(x => x.Price));
        }
    }
}