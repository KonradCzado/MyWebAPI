using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWebAPI.EF.Models;
using MyWebAPI.Utilities;

namespace MyWebAPI.Tests
{
    [TestClass]
    
    public class OrderProcessorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsAlreadyShipped_ThrowsException()
        {
            var orderProcessor = new OrderProcessor(new ShippingCalculator());

            orderProcessor.GetTotalOrderCost(new Order()
            {
                IsShipped = true
            });
        }

        [TestMethod]
        public void Calculator_NormalOrder_ReturnsNormalPrice()
        {
            var orderProcessor = new OrderProcessor(new ShippingCalculator());

            decimal cost = orderProcessor.GetTotalOrderCost(new Order()
            {
                Products = new List<Product>()
                {
                   new Product()
                   {
                       Price = 10M
                   },
                   new Product()
                   {
                       Price = 30M
                   }
               }
            });

            Assert.AreEqual(40M, cost);
        }

        [TestMethod]
        public void Calculator_Large_ReturnsPriceWith5PercentDiscount()
        {
            var orderProcessor = new OrderProcessor(new ShippingCalculatorForBigCompanies());

            decimal cost = orderProcessor.GetTotalOrderCost(new Order()
            {
                Products = new List<Product>()
                {
                   new Product()
                   {
                       Price = 10M
                   },
                   new Product()
                   {
                       Price = 30M
                   }
               }
            });

            Assert.AreEqual(40M * 0.95M, cost);
        }


    }
}
