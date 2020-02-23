using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using projetASP.Models;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetASP.Controllers
{
    public class EtudiantController : Controller
    {
        // GET: Etudiant
        public ActionResult Index()
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            return View("Home");
        }

        public ActionResult Home()
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            return View();
        }

        public ActionResult Profil()
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            string cne = Session["cne"].ToString();
            ProjetContext db = new ProjetContext();
            var x = db.etudiants.Where(et => et.cne == cne).SingleOrDefault();
            return View(x);
        }

        public ActionResult ModifierPersonel()
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            string cne = Session["cne"].ToString();
            ProjetContext db = new ProjetContext();
            var x = db.etudiants.Where(et => et.cne == cne).SingleOrDefault();
            return View(x);
        }

        [HttpPost]
        public ActionResult ModifierPersonel(Etudiant etudiant)
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            string cne = Session["cne"].ToString();
            ProjetContext db = new ProjetContext();
            var x = db.etudiants.Where(et => et.cne == cne).SingleOrDefault();
            x.nom = etudiant.nom;
            x.prenom = etudiant.prenom;
            x.cne = etudiant.cne;
            x.cin = etudiant.cin;
            x.email = etudiant.email;
            x.password = etudiant.password;
            x.date_naissance = Convert.ToDateTime(etudiant.date_naissance);
            x.filiere = etudiant.filiere;
            x.tele = Convert.ToInt32(etudiant.tele);
            x.address = etudiant.address;
            x.ville = etudiant.ville;
            db.SaveChanges();
            return Redirect(Url.Action("Home", "Etudiant"));
        }

        public ActionResult ModifierScolaire()
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            string cne = Session["cne"].ToString();
            ProjetContext db = new ProjetContext();
            var x = db.etudiants.Where(et => et.cne == cne).SingleOrDefault();
            return View(x);
        }

        [HttpPost]
        public ActionResult ModifierScolaire(string prev_etablissement,string type_diplome,string note)
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            string cne = Session["cne"].ToString();
            ProjetContext db = new ProjetContext();
            var x = db.etudiants.Where(et => et.cne == cne).SingleOrDefault();
            x.prev_etablissement = prev_etablissement;
            x.type_diplome = type_diplome;
            x.note = Convert.ToInt32(note);
            db.SaveChanges();
            return Redirect(Url.Action("Home", "Etudiant"));
        }

        public ActionResult Image()
        {
            if (Session["cne"] == null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Image(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    String extension = Path.GetExtension(file.FileName);
                    string fileName = Session["cne"] + extension;
                    string path = Path.Combine(Server.MapPath("~/Images"),fileName);
                    file.SaveAs(path);
                    string cne = Session["cne"].ToString();
                    ProjetContext db = new ProjetContext();
                    var x = db.etudiants.Where(et => et.cne == cne).SingleOrDefault();
                    x.image = fileName;
                    db.SaveChanges();
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        public ActionResult Pdf()

        {

            List sampleList = new List();
            sampleList.Add("lol");

            return new Rotativa.ViewAsPdf(sampleList)

            {

                PageSize = Rotativa.Options.Size.A4,

                PageOrientation = Rotativa.Options.Orientation.Landscape,

                PageMargins = new Margins(12, 12, 12, 12),// it’s in millimeters

                PageWidth = 180,

                PageHeight = 297
            };
        }
  
public ActionResult Deconnexion()
        {
            Session["nom"] = null;
            Session["prenom"] = null;
            Session["cne"] = null;
            return Redirect(Url.Action("Login", "Auth"));
        }
    }
}