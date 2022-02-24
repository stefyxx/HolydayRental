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
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Le titre doit comporter au moins 2 caractères")]
        [DataType(DataType.Text)]
        public string titre { get; set; }

        //[DataType(DataType.ImageUrl)]
        [Required]
        [MaxLength(50)]
        public string Photo { get; set; }

        [Required]
        [DisplayName("Description petit: ")]
        [StringLength(maximumLength: 150, MinimumLength = 2, ErrorMessage = "Le titre doit comporter au moins 2 caractères")]
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
        [MaxLength(50)]
        public string Ville { get; set; }

        [Required]
        [DisplayName("Adresse: ")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Rue { get; set; }

        [Required]
        [DisplayName("Numero: ")]
        [DataType(DataType.Text)]
        [MaxLength(5)]
        public string Numero { get; set; }

        [Required]
        [DisplayName("zip: ")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string CodePostal { get; set; }

        [Required]
        [DisplayName("Assuré ? : ")]
        public bool AssuranceObligatoire { get; set; }

        [Required]
        [DisplayName("Le votre bien est toujour louable ? : ")]
        public bool isEnabled { get; set; }

        [DisplayName("Data di fine : ")]
        [DataType(DataType.Date)]
        public DateTime? DisabledDate { get; set; }

        [Required]
        [DisplayName("Latitude : ")]
        [MaxLength(50)]
        public string Latitude { get; set; }


        [Required]
        [DisplayName("Longitude : ")]
        [MaxLength(50)]
        public string Longitude { get; set; }

        [Required]
        public bool isValide { get; set; }

        //da recuperare se non voglio un errore in BLL->DAL perché sono NOT NULL
        [ScaffoldColumn(false)]
        public DateTime DateCreation { get; set; }

        [ScaffoldColumn(false)]
        public int idMembre { get; set; }

        //extra: faro' io il select
        [ScaffoldColumn(false)]
        public IEnumerable<Pays> PaysPossible { get; set; }


    }
}
