using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Product> Products { get; set; }
    }
}