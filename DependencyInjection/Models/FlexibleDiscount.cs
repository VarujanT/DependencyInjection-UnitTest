using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public class FlexibleDiscount : IDiscount
    {
        public decimal ApplyDiscount(decimal total)
        {
            return (total > 100) ? (total - (50m / 100m * total)) : (total - 5);
        }
    }
}