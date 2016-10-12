using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpensesProjectMaster.Controllers;
using System.Web.Mvc;

namespace ExpensesProjectMaster.Tests
{
    [TestClass]
    public class SubmitClaimsTest
    {
        [TestMethod]
        public void SubmitInvalidClaim()
        {
            //var expensesController = new ExpensesController();
            //expensesController.
            //var result 
        }
        [TestMethod]
        public void TestHomeView()
        {
            var controller = new HomeController();
            var result = controller.FAQS() as ViewResult;
            Assert.AreEqual("FAQS", result.ViewName);
        }
    }
}
