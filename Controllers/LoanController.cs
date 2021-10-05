using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Library.DAL;
using Library.Models;

namespace Library.Controllers
{
    public class LoanController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Loan
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "title_descent" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_descendent" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var loans = from s in db.Loans
                        select s;

            switch (sortOrder)
            {
                case "name_descendent":
                    loans = loans.OrderByDescending(x => x.Book.Title);
                    break;
                case "Date":
                    loans = loans.OrderBy(x => x.LoanDate);
                    break;
                case "date_descendent":
                    loans = loans.OrderByDescending(x => x.LoanDate);
                    break;
                default:
                    loans = loans.OrderBy(x => x.Book.Title);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                loans = loans.Where(x => x.Book.Title.Contains(searchString));
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(loans.ToPagedList(pageNumber, pageSize));
        }

        // GET: Loan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loan/Create
        public ActionResult Create()
        {

            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: Loan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanID,UserID,BookID,LoanDate,ReturnDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", loan.BookID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", loan.UserID);
            return View(loan);
        }

        // GET: Loan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", loan.BookID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", loan.UserID);
            return View(loan);
        }

        // POST: Loan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanID, UserID, BookID, LoanDate, ReturnDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", loan.BookID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", loan.UserID);
            return View(loan);
        }

        // GET: Loan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loans.Find(id);
            db.Loans.Remove(loan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        LibraryContext db1 = new LibraryContext();


        [ValidateInput(false)]
        public ActionResult LoansGridViewPartial()
        {
            var model = db1.Loans;
            ViewData["Books"] = db1.Books.Select(x => new { x.BookID, x.Title }).ToList();
            ViewData["Users"] = db1.Users.Select(x => new { x.UserID, x.Name  }).ToList();

            return PartialView("_LoansGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]

        public ActionResult LoansGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Library.Models.Loan item)
        {
            var model = db1.Loans;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_LoansGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LoansGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Library.Models.Loan item)
        {
            var model = db1.Loans;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.LoanID == item.LoanID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_LoansGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LoansGridViewPartialDelete(int? LoanID)
        {
            var model = db1.Loans;
            if (LoanID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.LoanID == LoanID);
                    if (item != null)
                        db1.Loans.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_LoansGridViewPartial", model.ToList());
        }

        public ActionResult ComboBox1Partial()
        {
            return PartialView("_ComboBox1Partial");
        }   
    }
}
