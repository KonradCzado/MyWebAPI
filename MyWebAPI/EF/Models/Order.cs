using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MyWebAPI.Utilities;

namespace MyWebAPI.EF.Models
{
    public class Order
    {
        public int ID { get; set; }

        [NotMapped]
        public ShippingType ShippingType{ get; set; }

        public bool IsShipped { get; set; }
        public decimal TotalOrderCost { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        
    }
}