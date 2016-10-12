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

namespace ExpensesProjectMaster.Controllers
{
    [Authorize]
    public class PerDiemController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerDiem
        public ActionResult Index()
        {
            var employee = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault();
            ViewBag.AlertMessage = TempData["AlertMsg"] as string;
            var perDiem = db.Expenses.Include(e => e.Employee).Include(e => e.Project).Where(e => e.EmployeeID.Equals(employee.EmployeeID)).ToList();
            var perDiemList = new List<PerDiem>();
            foreach (var bar in perDiem.OfType<PerDiem>())
            {
                perDiemList.Add(bar);
            }
            return View(perDiemList.ToList());
        }


        //// GET: Expenses/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expense expense = db.Expenses.Find(id);
        //    if (expense == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expense);
        //}

        // GET: PerDiem/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name");
            return View();
        }

        // POST: PerDiem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FromDate,ToDate,Location,Currency,Rate,ActualAmount,Comment,ProjectNo,Rechargeable,")] PerDiem expense)
        {
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

        //// GET: Expenses/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expense expense = db.Expenses.Find(id);
        //    if (expense == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", expense.EmployeeID);
        //    ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name", expense.ProjectNo);
        //    return View(expense);
        //}

        //// POST: Expenses/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ExpenseID,ActualAmount,Currency,Category,Rechargeable,Comment,ApprovalStatus,EmployeeID,ProjectNo")] Expense expense)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(expense).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", expense.EmployeeID);
        //    ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name", expense.ProjectNo);
        //    return View(expense);
        //}

        //// GET: Expenses/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expense expense = db.Expenses.Find(id);
        //    if (expense == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expense);
        //}

        //// POST: Expenses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Expense expense = db.Expenses.Find(id);
        //    db.Expenses.Remove(expense);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
