using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetASP.Models
{
    public class Etudiant
    {
        public int id { get; set; }
        [Required]
        public string cin { get; set; }
        [Required]
        public string cne { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public DateTime date_naissance { get; set; }
        public string filiere { get; set; }
        public int tele { get; set; }
        public string address { get; set; }
        public string ville { get; set; }
        public string prev_etablissement { get; set; }
        public string type_diplome { get; set; }
        public int note { get; set; }

    }
}