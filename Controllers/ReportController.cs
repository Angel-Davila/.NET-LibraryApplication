using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book()
        {
            return View();
        }
#pragma warning disable CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        public ActionResult User()
#pragma warning restore CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        {
            return View();
        }
        public ActionResult Loan()
        {
            return View();
        }
    }
}