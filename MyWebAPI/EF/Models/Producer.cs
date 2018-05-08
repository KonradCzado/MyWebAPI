using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.EF.Models
{
    public class Producer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ISet<Product> Products { get; set; } = new HashSet<Product>();
    }
}