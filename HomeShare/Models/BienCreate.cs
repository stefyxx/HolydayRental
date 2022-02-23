using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class BienCreate
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien { get; set; }

        [Required]
        [DisplayName("Titre: ")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Le titre doit comporter au moins 2 caractères")]
        [DataType(DataType.Text)]
        public string titre { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required]
        [DisplayName("Description petit: ")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Le titre doit comporter au moins 2 caractères")]
        [DataType(DataType.Text)]
        public string DescCourte { get; set; }

        [Required]
        [DisplayName("Description complete: ")]
        [MinLength(2, ErrorMessage = "Le titre doit comporter au moins 2 caractères")]
        [DataType(DataType.MultilineText)]
        public string DescLong { get; set; }

        [Required]
        [DisplayName("Combien de personnes max: ")]
        public int NombrePerson { get; set; }

        //[ScaffoldColumn(false)]
        public int Pays { get; set; }   //id Pays


        [Required]
        [DisplayName("Ville: ")]
        [DataType(DataType.Text)]
        public string Ville { get; set; }

        [Required]
        [DisplayName("Adresse: ")]
        [DataType(DataType.Text)]
        public string Rue { get; set; }

        [Required]
        [DisplayName("Numero: ")]
        [DataType(DataType.Text)]
        public string Numero { get; set; }

        [Required]
        [DisplayName("zip: ")]
        [DataType(DataType.Text)]
        public string CodePostal { get; set; }
        public string libellePays { get; set; }

        [Required]
        [DisplayName("Assuré ? : ")]
        public bool AssuranceObligatoire { get; set; }

        //scrivo nel POST che sarà "true"
        public bool isEnabled { get; set; }

        [Required]
        [DisplayName("Latitude : ")]
        public string Latitude { get; set; }

        [Required]
        [DisplayName("Longitude : ")]
        public string Longitude { get; set; }

        [Required]
        public bool isValide { get; set; }

        //metto oggi
        public DateTime DateCreation { get; set; }

        //creare un select per questo anche
        public int idMembre { get; set; }

        //extra:

        public IEnumerable<Pays> PaysPossible { get; set; }
        public IEnumerable<MembreNomId> listMembre { get; set; }

    }
}
