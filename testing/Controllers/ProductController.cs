using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTesting.Models;
using testing.Models;

namespace MVCTesting.Controllers
{
    public class ProductController : Controller
    {
        IProductStore productstore;
        public ProductController(IProductStore productstore)
        {
            this.productstore = productstore;
        }
        public IActionResult Index()
        {
            bool results = productstore.FindProduct(100);
            return View(results);
        }
        public ViewResult ProductPage()
        {
            List<Product>products=productstore.GetAllProducts();
            return View(products);
        }
    }
}