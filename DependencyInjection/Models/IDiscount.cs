using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal total);
    }
}
