using ExpensesProjectMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ExpensesProjectMaster.Models.Entities;

namespace ExpensesProjectMaster.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult PendingClaims()
        {
            return View();
        }
        public ActionResult PendingClaimsPartial()
        {
            var expenses = db.Expenses.Include(e => e.Employee).Include(e => e.Project).Where(e => e.ApprovalStatus == Models.Entities.Status.Pending);
            return PartialView("PendingClaimsPartial", expenses);
        }
        public List<Expense> GetPendingClaims()
        {
            var expenses = db.Expenses.Include(e => e.Employee).Include(e => e.Project).Where(e => e.ApprovalStatus == Models.Entities.Status.Pending).ToList();
            return expenses;
        }
        public ActionResult PendingReimbursementClaimsPartial()
        {
            var expenses = GetPendingClaims();
            var reimbursementList = new List<Reimbursement>();
            foreach (var bar in expenses.OfType<Reimbursement>())
            {
                reimbursementList.Add(bar);
            }
            return View("PendingReimbursementClaimsPartial", reimbursementList);
        }
        public ActionResult PendingMileageClaimsPartial()
        {
            var expenses = GetPendingClaims();
            var mileageList = new List<Mileage>();
            foreach (var bar in expenses.OfType<Mileage>())
            {
                mileageList.Add(bar);
            }
            return View("PendingMileageClaimsPartial", mileageList);
        }
        public ActionResult PendingPerDiemClaimsPartial()
        {
            var expenses = GetPendingClaims();
            var perdiemList = new List<PerDiem>();
            foreach (var bar in expenses.OfType<PerDiem>())
            {
                perdiemList.Add(bar);
            }
            return View("PendingPerDiemClaimsPartial", perdiemList);
        }
        public ActionResult PendingCreditCardClaimsPartial()
        {
            var expenses = GetPendingClaims();
            var creditCardList = new List<CreditCardRequest>();
            foreach (var bar in expenses.OfType<CreditCardRequest>())
            {
                creditCardList.Add(bar);
            }
            return View(creditCardList);
        }

        public ActionResult ViewAllExpenses()
        {
            return View();
        }
    }
}