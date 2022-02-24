using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class BienDelete
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien { get; set; }

        public string Photo { get; set; }


        [DisplayName("Le bien: ")]
        public string titre { get; set; }

        [ScaffoldColumn(false)]
        public int idPays { get; set; }

        //public int idPays { get { return this.Pays.idPays; } }

        public Pays Pays { get; set; }

        [DisplayName("Ville: ")]
        public string Ville { get; set; }

        [DisplayName("Adresse: ")]
        public string Rue { get; set; }

        public string Numero { get; set; }

        public string CodePostal { get; set; }

        [DisplayName("Par personnes max: ")]
        public int NombrePerson { get; set; }


        //in futuro voglio che controlli che il Membre é bel LOGGATO x eseguire Delete
        [DisplayName("Du propriétaire: ")]
        public MembreNomId membre { get; set; }

        [ScaffoldColumn(false)]
        public int idMembre { get; set; }

        //public int idMembre { get { return this.membre.idMembre; } }
        //il faut le recuperer!!

        [DisplayName("Valider le formulaire")]
        public bool isValide { get; set; }
    }
}
