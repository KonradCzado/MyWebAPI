using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.EF.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ProducerID { get; set; }
        public byte[] Image { get; set; }
        //nie uzylem wirtual, gdyz przy ladowaniu do bazy zrobilo by n + 1 zapytan
        //1 zapytanie o protukty i n o producenta kazdego produktu
        public Producer Producer { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}