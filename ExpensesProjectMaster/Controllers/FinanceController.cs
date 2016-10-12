using ExpensesProjectMaster.Models;
using ExpensesProjectMaster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace ExpensesProjectMaster.Controllers
{
    [Authorize(Roles = "Finance")]
    public class FinanceController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Finance
        public ActionResult ApprovedClaims()
        {
            return View();
        }

        public List<Expense> GetApprovedClaims()
        {
            var expenses = db.Expenses
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .Where(e => e.ApprovalStatus == Status.Approved || e.ApprovalStatus == Status.Purchased)
                .ToList();
            return expenses;
        }
        public ActionResult ReimbursementList()
        {
            var expenses = GetApprovedClaims();
            var reimbursementList = new List<Reimbursement>();
            foreach (var bar in expenses.OfType<Reimbursement>())
            {
                reimbursementList.Add(bar);
            }
            return View(reimbursementList);
        }
        public ActionResult MileageList()
        {
            var expenses = GetApprovedClaims();
            var mileageList = new List<Mileage>();
            foreach (var bar in expenses.OfType<Mileage>())
            {
                mileageList.Add(bar);
            }
            return View(mileageList);
        }
        public ActionResult PerDiemList()
        {
            var expenses = GetApprovedClaims();
            var perdiemList = new List<PerDiem>();
            foreach (var bar in expenses.OfType<PerDiem>())
            {
                perdiemList.Add(bar);
            }
            return View(perdiemList);
        }
        public ActionResult CreditCardList()
        {
            var expenses = GetApprovedClaims();
            var creditCardList = new List<CreditCardRequest>();
            foreach (var bar in expenses.OfType<CreditCardRequest>())
            {
                creditCardList.Add(bar);
            }
            return View(creditCardList);
        }
    }
}