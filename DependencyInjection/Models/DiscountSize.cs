using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public class DiscountSize : IDiscontSize
    {
        public decimal Size { get; set; }
    }
}