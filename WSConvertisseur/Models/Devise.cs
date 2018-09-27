using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSConvertisseur.Models
{
    public class Devise
    {
        public int Id { get; set; }

        [Required]
        public string NomDevise { get; set; }

        public double Taux { get; set; }

        public Devise()
        {

        }

        public Devise(int Id, string NomDevise, double Taux)
        {
            this.Id = Id;
            this.NomDevise = NomDevise;
            this.Taux = Taux;

        }
    }
}
