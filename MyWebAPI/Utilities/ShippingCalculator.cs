using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebAPI.EF.Models;

namespace MyWebAPI.Utilities
{
    public class ShippingCalculator : IShippingCalculator
    {
        public ShippingType ShippingType { get; set; }

        public decimal GetShippingPrice(ShippingType shippingType)
        {
            if (shippingType == ShippingType.Ferry)
                return 19.99M;
            else
                return 9.99M;
        }

        public decimal CalculateShipping(Order order)
        {
            return order.Products.Sum(o => o.Price);
        }
    }

    
}