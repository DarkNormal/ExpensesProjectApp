using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpensesProjectMaster.Controllers;
using System.Web.Mvc;

namespace ExpensesProjectMaster.Tests
{
    /// <summary>
    /// Summary description for HomeControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
       public void TestHomeView()
        {
            var controller = new HomeController();
            var result = controller.FAQS() as ViewResult;
            Assert.AreEqual("FAQS", result.ViewName);
        }
    }
}
