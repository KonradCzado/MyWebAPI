using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebAPI.EF.Models;

namespace MyWebAPI.Utilities
{
    public class ShippingCalculatorForBigCompanies : IShippingCalculator
    {


        public ShippingType ShippingType { get; set; }

        public decimal CalculateShipping(Order order)
        {
            return order.Products.Sum(p => p.Price * 0.95M); // Big Companies are getting 5% discount
                                                             //because they are ordering much more products
        }

        public decimal GetShippingPrice(ShippingType shippingType)
        {
            if (ShippingType == ShippingType.Ferry)
                return 0.00M;
            else
                return 10.00M;
        }
    }
}