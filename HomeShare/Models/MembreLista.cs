using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreLista
    {
        /* bisogna che il n° di telefono e la mail siano visibili solo dopo aver pagato l'affitto 
         *  FINIRE MAPPER
         */
        [ScaffoldColumn(false)]
        [Key]
        public int idMembre { get; set; }

        [DisplayName("Nom")]
        public string Nom { get; set; }

        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        //[ScaffoldColumn(false)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int idPays { get; set; }

        [DisplayName("Pays")]
        public string NomPays { get { return this.Pays.Libelle; } }

        [DisplayName("Téléphone")]
        public string Telephone { get; set; }

        //extra:
        //[ScaffoldColumn(false)]
        public Pays Pays { get; set; }
    }
}
