using projetASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetASP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            ProjetContext db = new ProjetContext();
            var x = db.admins.Where(a => a.username == admin.username && a.password == admin.password).SingleOrDefault();
            if (x!=null)
            {
                return RedirectToAction("Home");
            }
            return RedirectToAction("Login");
        }

        public ActionResult Home()
        {
            ProjetContext db = new ProjetContext();
            ViewBag.e = new SelectList(db.etudiants, "email", "nom");
            return View();
        }

        [HttpPost]
        public ActionResult Home(string x)
        {
            ViewData["info"] = x;
            return View("Test");
        }
    }
}