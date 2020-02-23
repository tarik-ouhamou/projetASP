using projetASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetASP.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Etudiant etudiant)
        {
            ProjetContext db = new ProjetContext();
            var x=db.etudiants.Where(et => et.cne == etudiant.cne && et.cin == etudiant.cin && et.password == etudiant.password).SingleOrDefault();
            if (x != null)
            {
                Session["cne"] = etudiant.cne;
                Session["nom"] = etudiant.nom;
                Session["prenom"] = etudiant.prenom;
                return Redirect(Url.Action("Home", "Etudiant"));
            }
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Etudiant etudiant)
        {
            ProjetContext db = new ProjetContext();
            db.etudiants.Add(etudiant);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Home()
        {
            return View();
        }

    }
}