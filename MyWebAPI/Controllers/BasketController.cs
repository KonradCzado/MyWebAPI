using MyWebAPI.EF.Models;
using MyWebAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebAPI.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Index()
        {
            return View(Session["userBasket"] as List<Product>);
        }

        public JsonResult MakeOrder()
        {
            var userProducts = Session["userBasket"] as List<Product>;
            if (userProducts == null)
                return Json(new { success = false, reponseText = "Basket was empty!" });
            if(userProducts.Count == 0)
                return Json(new { success = false, reponseText = "Basket was empty!" });

            var amountOfBoughtProducts = userProducts.Count;
            OrderProcessor orderProcessor = null;

            if (amountOfBoughtProducts < 10)
                orderProcessor = new OrderProcessor(new ShippingCalculator());
            else
                orderProcessor = new OrderProcessor(new ShippingCalculatorForBigCompanies());

            Order newOrder = new Order();
            newOrder.IsShipped = false;
            newOrder.ShippingType = ShippingType.Ferry;
            newOrder.Products = userProducts;
            newOrder.TotalOrderCost = orderProcessor.GetTotalOrderCost(newOrder);
           

            return Json(new { success = true, responseText = newOrder.TotalOrderCost }, JsonRequestBehavior.AllowGet);

        }
    }
}