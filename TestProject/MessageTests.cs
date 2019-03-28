using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTesting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestClass]
    public class MessageTests
    {
        static Mock<IMessage> mockmailclass;
        static IMessage obj;
        static MessagingService service;

        [ClassInitialize]
        public static void ClassInt(TestContext context)
        {
            mockmailclass = new Mock<IMessage>();
            obj= mockmailclass.Object;
            service = new MessagingService(obj);
        }

        [TestMethod]
        public void MessageTest1()
        {
            mockmailclass.SetupProperty(c => c.sender, "abc@abc.com");
            mockmailclass.SetupProperty(c => c.reciever, "xyz@xyz.com");
            mockmailclass.SetupProperty(c => c.message, "Hello Friend");

            mockmailclass.Setup(c => c.SendMessage()).Returns(true);
            mockmailclass.Setup(c => c.SendMessage(It.IsAny<string>(),It.IsAny<string>(),It.IsAny<string>()));

            bool result = service.SendMessage();
            Assert.IsTrue(result);
            result = service.SendMessage("a", "b", "hello");
            Assert.IsFalse(result);
            Assert.AreEqual(service.message.message, "Hello Friend");
            Assert.AreEqual(service.message.sender, "abc@abc.com");

            mockmailclass.Verify(c => c.SendMessage());
        }
    }
}
