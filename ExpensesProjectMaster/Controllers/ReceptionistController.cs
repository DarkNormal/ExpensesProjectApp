using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpensesProjectMaster.Models.Entities;
using ExpensesProjectMaster.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExpensesProjectMaster.Controllers
{
    [Authorize(Roles = "Receptionist")]
    public class ReceptionistController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Receptionist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ApprovedCreditCardRequests()
        {
            var ccRequests = db.Expenses.Include(e => e.Employee).Include(e => e.Project).Where(e => e.ApprovalStatus == Models.Entities.Status.Approved);
            var ccRequestList = new List<CreditCardRequest>();
            foreach (var bar in ccRequests.OfType<CreditCardRequest>())
            {
                ccRequestList.Add(bar);
            }
            return View(ccRequestList);
        }
    }
}