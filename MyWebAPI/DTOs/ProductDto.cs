using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.DTOs
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public byte[] Image { get; set; }
        public ProducerDto Producer { get; set; }
    }
}