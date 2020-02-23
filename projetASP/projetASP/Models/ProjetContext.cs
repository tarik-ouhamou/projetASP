using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projetASP.Models
{
    public class ProjetContext:DbContext
    {
        public ProjetContext() : base("name=ProjetContext")
        {

        }

        public DbSet<Etudiant> etudiants { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}