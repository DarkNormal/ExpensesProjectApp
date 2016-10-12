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
    public class MileageController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mileage
        public ActionResult Index()
        {
            var employee = db.Employees.Where(e => e.Email.Equals(User.Identity.Name)).FirstOrDefault();
            var expenses = db.Expenses.Include(e => e.Employee).Include(e => e.Project).Where(e => e.EmployeeID.Equals(employee.EmployeeID)).ToList();
            var mileageList = new List<Mileage>();
            foreach (var bar in expenses.OfType<Mileage>())
            {
                mileageList.Add(bar);
            }
            return View(mileageList);
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

        // GET: Mileage/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.ProjectNo = new SelectList(db.Projects, "ProjectID", "Name");
            return View("Create");
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
            return RedirectToAction("ExpensesTabs", "Expenses");
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
