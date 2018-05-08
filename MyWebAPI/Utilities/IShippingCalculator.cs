using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebAPI.EF.Models;

namespace MyWebAPI.Utilities
{
    public interface IShippingCalculator
    {
        decimal GetShippingPrice(ShippingType shippingType);
        decimal CalculateShipping(Order order);
    }
}
