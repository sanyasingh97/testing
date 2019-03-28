using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testing.Models;

namespace testing.Controllers
{
    public class HomeController : Controller
    {
        ProductStore store;
        public HomeController()
        {
            store = new ProductStore();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult GetProducts()
        {
            List<Product>ListOfProducts=store.Products;
            return View(ListOfProducts);
        }
        public IActionResult GetProduct(int Id)
        {
            List<Product> ListOfProducts = store.Products;
            Product product = ListOfProducts.SingleOrDefault(c => c.ProductId.Equals(Id));
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return View("Index");
            }
        }
        public ViewResult ProductPage(int id)
        {
            List<Product> ListOfProducts = store.Products;
            Product product = ListOfProducts.SingleOrDefault(c => c.ProductId.Equals(id));
            if(product is null)
            {
                throw new NullReferenceException("Product must not be null");
            }
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
