using AutoMapper;
using MyWebAPI.DTOs;
using MyWebAPI.EF;
using MyWebAPI.EF.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly WebApiContext _context;

        public ProductsController()
        {
            _context = new WebApiContext();
           
        }


       

        public IHttpActionResult GetProducts()
        {
            var productsDtos = _context.Products
                .Include(p => p.Producer)
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productsDtos);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ID == id);

            if (product == null)
                return BadRequest();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.ID = product.ID;

            return Created(new Uri(Request.RequestUri.ToString()), (Mapper.Map<Product, ProductDto>(product)));
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productToUpdate = _context.Products.SingleOrDefault(p => p.ID == id);

            if (productToUpdate == null)
                return BadRequest();

            Mapper.Map<ProductDto, Product>(productDto, productToUpdate);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productToRemove = _context.Products.SingleOrDefault(p => p.ID == id);
            if (productToRemove == null)
                return BadRequest();

            _context.Products.Remove(productToRemove);
            _context.SaveChanges();

            return Ok();
        }


      


    }
}
