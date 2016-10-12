using ExpensesProjectMaster.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpensesProjectMaster.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public BaseController()
        {
            string welcomeMessage = "Welcome ";
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (user != null)
            {
                var employee = db.Employees.Where(e => e.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                welcomeMessage += employee.FirstName;
                ViewBag.WelcomeMessage = welcomeMessage;
            }
            else
            {
                ViewBag.WelcomeMessage = "Log in";
            }

            
        }
    }
}