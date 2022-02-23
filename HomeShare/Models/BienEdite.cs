using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class BienEdite
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien { get; set; }

        [Required]
        [DisplayName("Titre: ")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Le titre doit comporter au moins 2 caractères")]
        [DataType(DataType.Text)]
        public string titre { get; set; }

        [Required]
        //[DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required]
        [DisplayName("Description petit: ")]
        [StringLength(maximumLength: 300, MinimumLength = 2, ErrorMessage = "Le titre doit comporter au moins 2 caractères")]
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
        [Required]
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
        [MaxLength(6)]
        [DataType(DataType.Text)]
        public string CodePostal { get; set; }

        [Required]
        [DisplayName("Assuré ? : ")]
        public bool AssuranceObligatoire { get; set; }

        [Required]
        [DisplayName("Le votre bien est toujour louable ? : ")]
        public bool isEnabled { get; set; }

        [Required]
        [DisplayName("Latitude : ")]
        public string Latitude { get; set; }

        [DisplayName("Data di fine : ")]
        [DataType(DataType.Date)]
        public DateTime? DisabledDate { get; set; }

        [Required]
        [DisplayName("Longitude : ")]
        public string Longitude { get; set; }

        [Required]
        public bool isValide { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateCreation { get; set; }

        //creare un select per questo anche
        [ScaffoldColumn(false)]
        public int idMembre { get; set; }

        //extra:
        [ScaffoldColumn(false)]
        public IEnumerable<Pays> PaysPossible { get; set; }


    }
}
