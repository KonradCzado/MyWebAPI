using MyWebAPI.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyWebAPI.EF
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() : base("WebApiConnection")
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}