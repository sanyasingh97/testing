﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace MVCTesting.Models
{
    public interface IProductStore
    {
        bool FindProduct(int id);
        Product FindProduct(string title, int price);
        List<Product> GetAllProducts();
    }
    public class ProductServices : IProductStore
    {
        ProductStore store;
        public ProductServices()
        {
            store = new ProductStore();
        }
        public bool FindProduct(int id)
        {
            Product product = store.Products.SingleOrDefault(c => c.ProductId.Equals(id));
            if (product == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Product FindProduct(string title, int price)
        {
            Product product = store.Products.SingleOrDefault(c => c.Title.Equals(title)&& c.Price.Equals(price));
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return store.Products;
        }
    }
}
