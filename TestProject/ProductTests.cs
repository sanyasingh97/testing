using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTesting.Controllers;
using MVCTesting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void IndexTestMethod()
        {
            //Arrange
            Mock<IProductStore> productstoremock = new Mock<IProductStore>();
            IProductStore mockedclassobj = productstoremock.Object;
            productstoremock.Setup(c => c.FindProduct(It.IsAny<int>())).Returns(true);
            ProductController controller = new ProductController(mockedclassobj);

            ViewResult result=(ViewResult)controller.Index();
            Assert.IsTrue((bool)result.Model);
            productstoremock.Verify(c => c.FindProduct(100));
        }
    }
}
