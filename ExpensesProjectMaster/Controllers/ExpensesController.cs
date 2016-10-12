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
    [Authorize]
    public class ExpensesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: Expenses
        public ActionResult Index()
        {
            var employee = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault();
            if (employee != null)
            {
                ViewBag.AlertMessage = TempData["AlertMsg"] as string;
                var expenses = db.Expenses.Include(e => e.Employee).Include(e => e.Project).Where(e => e.EmployeeID.Equals(employee.EmployeeID)).ToList();
                var reimbursementList = new List<Reimbursement>();
                foreach (var bar in expenses.OfType<Reimbursement>())
                {
                    reimbursementList.Add(bar);
                }
                return View(reimbursementList.ToList());
            }
            else return View("Login", "Account");
        }
        // GET: Expenses/CreditCardList
        public ActionResult CreditCardList()
        {
            var employee = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault();
            if (employee != null)
            {
                //ViewBag.AlertMessage = TempData["AlertMsg"] as string;
                var expenses = db.Expenses.Include(e => e.Employee).Include(e => e.Project).Where(e => e.EmployeeID.Equals(employee.EmployeeID)).ToList();
                var creditCardList = new List<CreditCardRequest>();
                foreach (var bar in expenses.OfType<CreditCardRequest>())
                {
                    creditCardList.Add(bar);
                }
                return View(creditCardList.ToList());
            }
            else return View("Login", "Account");
        }

        public ActionResult ExpensesTabs()
        {
            return View();
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {

            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name");
            return View();
        }
        //GET: Expenses/CreateCreditCardRequest
        public ActionResult CreateCreditCardRequest()
        {
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name");
            return View("SubmitCCRequest");
        }
        //POST: Expenses/CreateReimbursement
        [HttpPost]
        public ActionResult CreateCreditCardRequest([Bind(Include ="CreditCardRequestID,Currency,ActualAmount,Category,Rechargeable,Comment,ProjectNo")] CreditCardRequest ccreq)
        {
            ccreq.ApprovalStatus = Status.Pending;
            ccreq.EmployeeID = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault().EmployeeID;
            if (ModelState.IsValid)
            {
                db.Expenses.Add(ccreq);
                db.SaveChanges();
                TempData["AlertMsg"] = "Success";
                return RedirectToAction("ExpensesTabs");
            }
            return View("SubmitCCRequest", ccreq);
        }
        // GET: Expenses/CreateReimbursement
        public ActionResult CreateReimbursement()
        {

            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name");
            return PartialView();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReimbursement([Bind(Include = "EmployeeID,ExpenseID,DateOfExpense,ActualAmount,Currency,Comment,Category,Rechargeable,ProjectNo")] Reimbursement expense)
        {
            expense.ApprovalStatus = Status.Pending;
            expense.EmployeeID = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault().EmployeeID;
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                TempData["AlertMsg"] = "Success";
                return RedirectToAction("ExpensesTabs");
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name", expense.ProjectNo);
            return View("CreateReimbursement", expense);
        }

        // POST: PerDiem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePerDiem([Bind(Include = "EmployeeID,FromDate,ToDate,Location,Currency,Rate,ActualAmount,Comment,ProjectNo,Rechargeable,")] PerDiem expense)
        {
            expense.ApprovalStatus = Status.Pending;
            expense.Rate = 39;
            var numDays = (expense.ToDate - expense.FromDate).TotalDays;
            expense.ActualAmount = ((decimal)(39 * numDays));
            expense.EmployeeID = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault().EmployeeID;
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                TempData["AlertMsg"] = "Success";
                return RedirectToAction("ExpensesTabs");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", expense.EmployeeID);
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name", expense.ProjectNo);
            return View("Create", "PerDiem", expense);
        }
        // POST: Mileage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMileage([Bind(Include = "EmployeeID,DateOfExpense,Currency,Rate,ActualAmount,Distance,FromLocation,ToLocation,Comment,ProjectNo,Rechargeable,")] Mileage expense)
        {
            expense.ApprovalStatus = Status.Pending;
            expense.Rate = 0.4M;
            expense.ActualAmount = expense.Distance * expense.Rate;
            expense.EmployeeID = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault().EmployeeID;
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("ExpensesTabs");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", expense.EmployeeID);
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name", expense.ProjectNo);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", expense.EmployeeID);
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name", expense.ProjectNo);
            return View(expense);
        }
        [HttpPost]
        public ActionResult UpdateStatus(List<int> selectedExpenses, int status)
        {
            //int status is for the Status enum
            //0 is approved
            //1 is rejected
            //2 is pending
            if (selectedExpenses != null && selectedExpenses.Count >= 1)
            {
                var expenses = db.Expenses
                    .Where(t => selectedExpenses.Contains(t.ExpenseID))
                    .ToList();
                foreach (var e in expenses)
                {
                    e.ApprovalStatus = (Status)status;
                }
                db.SaveChanges();
                var result = new { success = true, status = status };
                return Json(result);
            }
            else return Json("fail");
        }
        [HttpPost]
        public ActionResult UpdateSingleStatus(int selectedExpenseID, int status)
        {
            //int status is for the Status enum
            //0 is approved
            //1 is rejected
            //2 is pending
            var expense = db.Expenses.Find(selectedExpenseID);
            expense.ApprovalStatus = (Status)status;
            db.SaveChanges();
            var result = new { success = true, status = status };
            return Json(result);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseID,ActualAmount,Currency,Category,Rechargeable,Comment,ApprovalStatus,EmployeeID,ProjectNo")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", expense.EmployeeID);
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name", expense.ProjectNo);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
            db.SaveChanges();
            //TempData["AlertMsg"] = "Deleted";
            return RedirectToAction("ExpensesTabs");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
