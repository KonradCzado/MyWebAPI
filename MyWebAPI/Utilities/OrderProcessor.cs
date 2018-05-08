using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebAPI.EF.Models;

namespace MyWebAPI.Utilities
{
    public class OrderProcessor
    {
        private readonly IShippingCalculator _calculator;


        public OrderProcessor(IShippingCalculator shippingCalculator)
        {
            _calculator = shippingCalculator;
        }

        public decimal GetTotalOrderCost(Order order)
        {
            if (order.IsShipped)
                throw new InvalidOperationException("The order is already processed!");

           return  _calculator.CalculateShipping(order);
        }
    }
}