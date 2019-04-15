using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public class DefaultDiscount : IDiscount
    {
        IDiscontSize DiscountSize;
        public DefaultDiscount(IDiscontSize s)
        {
            DiscountSize = s;
        }


        public decimal ApplyDiscount(decimal total)
        {
            return (total - (DiscountSize.Size / 100m * total));
        }
    }
}