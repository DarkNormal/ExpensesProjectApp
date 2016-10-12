using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpensesProjectMaster.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyExpenses()
        {
            ViewBag.Message = "You have loaded expenses!";
            return View();
        }

        public ActionResult MyCCHistory()
        {
            ViewBag.Message = "You have loaded YOUR CC HISTORY";
            return View();
        }

        public ActionResult FAQS()
        {
            ViewBag.Message = "Yolo";
            return View("FAQS");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}