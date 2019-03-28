using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using testing.Controllers;
using testing.Models;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        static HomeController controller;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            controller = new HomeController();
            context.WriteLine("HomeController Instance Created");
        }
        [TestMethod]
        public void TestForIndexAction()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            IActionResult result = controller.Index();
            ViewResult view = (ViewResult)result;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("HomeTests")]
        public void TestForContact()
        {
            //Arrange
            //Act
            IActionResult result = controller.Contact();
            ViewResult view = (ViewResult)result;
            string teststring = "Your contact page.";
            string data=(string)view.ViewData["Message"];
            //
            Assert.AreEqual(teststring, data);
        }
        [TestMethod]
        [TestCategory("HomeTests")]
        public void TestForAllProducts()
        {
            //Arrange
            //Act
            ViewResult result=(ViewResult)controller.GetProducts();
            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(List<Product>));
        }
        [TestMethod]
        [TestCategory("GetproductTests")]
           public void GetProductIfTest()
        {
            //Arrange
            //Act
            ViewResult result=(ViewResult)controller.GetProduct(100);
            //Assert
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Product));
            Product product = (Product)result.Model;
            Assert.AreEqual(product.Title, "Pen");
        }

        [TestMethod]
        [TestCategory("GetproductTests")]
        public void GetProductElseTest()
        {
            ViewResult result = (ViewResult)controller.GetProduct(105);
            Assert.IsNull(result.Model);
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        [TestCategory("GetproductTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void ProductPageTest()
        {
            ViewResult result = controller.ProductPage(99);
        }
        [TestMethod]
        [DataRow(100)]
        [DataRow(101)]
        [DataRow(102)]
        public void IndividualProductTest(int id)
        {

            ViewResult result = (ViewResult)controller.GetProduct(id);
            Assert.IsInstanceOfType(result.Model, typeof(Product));
        }
     
        [ClassCleanup]
        public static void ClassCleanUp()
        {

        }

    }
}





