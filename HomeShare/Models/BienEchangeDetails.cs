using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class BienEchangeDetails
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien { get; set; }

        [DisplayName("Titre: ")]
        public string titre { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [DisplayName("Description: ")]
        public string DescLong { get; set; }

        [DisplayName("Combien de personnes max: ")]
        public int NombrePerson { get; set; }

        [ScaffoldColumn(false)]
        public int Pays { get; set; } //id Pays

        [DisplayName("Pays: ")]
        public string libellePays { get; set; }

        [DisplayName("Ville: ")]
        public string Ville { get; set; }

        [DisplayName("Adresse: ")]
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string CodePostal { get; set; }

        [DisplayName("Il faut l'assurance: ")]
        public bool AssuranceObligatoire { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
