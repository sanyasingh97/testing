using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
    public class ProductStore
    {
        public List<Product> Products { get; set; }
        public ProductStore()
        {
            Products = new List<Product>()
            {
                new Product() { ProductId=100, Title="Pen",Price=1200 },
                new Product() {ProductId=101, Title="Eraser",Price=200 },
                 new Product(){ProductId = 102, Title = "Pencil",Price = 800 }
            };
        }
    }

}
