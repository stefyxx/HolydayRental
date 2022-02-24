using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreDetails
    {
        //email, n°, nome, cognome

        [ScaffoldColumn(false)]
        [Key]
        public int idMembre { get; set; }
        [DisplayName("Nom")]
        public string Nom { get; set; }

        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Téléphone")]
        public string Telephone { get; set; }

        [ScaffoldColumn(false)]
        public int idPays { get; set; } //id Pays

        [DisplayName("Pays: ")]
        public string NomPays { get { return this.Pays.Libelle; } }
        public Pays Pays { get; set; }
    }
}
