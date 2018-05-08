using MyWebAPI.EF;
using MyWebAPI.EF.Models;
using MyWebAPI.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private WebApiContext _context;

        public HomeController()
        {
            _context = new WebApiContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddToBasket(int? id)
        {
           
            if (!id.HasValue)
                return Json(new { success = false, responseText = "The id of product is Invalid" }, JsonRequestBehavior.AllowGet);

            var product = _context.Products.SingleOrDefault(p => p.ID == id.Value);
            
            if(product.Amount == 0)
                return Json(new { success = false, responseText = "This product is not available!" }, JsonRequestBehavior.AllowGet);

            if (product == null)
                return Json(new { success = false, responseText = "This product is not available!" }, JsonRequestBehavior.AllowGet);
            if (Session["userBasket"] == null)
                Session["userBasket"] = new List<Product>();

            var list = Session["userBasket"] as List<Product>;
            list.Add(product);
            Session["userBasket"] = list;

            --product.Amount;
            _context.SaveChanges();

            return Json(new { success = true, responseText = "Product added to basket",
                basketItemsCount = list.Count
            }, JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public ViewResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCodeResult UploadImage(HttpPostedFileBase postedFile, int? productId)
        {
            if (!productId.HasValue)
                return new HttpStatusCodeResult(500, "The id was null!");

            var productToUpdate = _context.Products.SingleOrDefault(p => p.ID == productId.Value);

            if (productToUpdate == null)
                return new HttpStatusCodeResult(500, "There is no product with such ID!");
            if(Request.Files == null)
               return new HttpStatusCodeResult(500, "There was not image supported with request!");

            
            if (Request.Files.Count == 0)
                return new HttpStatusCodeResult(500, "There was not image supported with request!");


            var imageStream = Request.Files[0].InputStream;
            using (var memStream = new MemoryStream())
            {
                imageStream.CopyTo(memStream);
                productToUpdate.Image = memStream.ToArray();
            }

            _context.SaveChanges();
           

            return new HttpStatusCodeResult(200);
        }

    }
}
