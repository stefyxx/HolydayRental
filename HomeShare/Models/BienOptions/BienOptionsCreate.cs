using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models.BienOptions
{
    public class BienOptionsCreate
    {
        //bisogna aggiungere il LOGGIN: in teoria se loggato, aggiungo un bene
        //per ora Manca idMembre

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

        [Required]
        public int Pays { get; set; }   //id Pays

        [ScaffoldColumn(false)]
        public IEnumerable<Pays> PaysPossible { get; set; }

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

        //scrivo nel POST che sarà "true"
        [ScaffoldColumn(false)]
        public bool isEnabled { get; set; }

        [Required]
        [DisplayName("Latitude : ")]
        [MaxLength(50)]
        public string Latitude { get; set; }

        [DisplayName("Data di fine : ")]
        public DateTime? DisabledDate { get; set; }

        [Required]
        [DisplayName("Longitude : ")]
        [MaxLength(50)]
        public string Longitude { get; set; }

        //metto oggi
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; }

        //A Miglirare con il LOGGIN
        [Required]
        [DisplayName("membro: ")]
        public int idMembre { get; set; }

        //x ora lo inszrisco alla mano
        public IEnumerable<MembreNomId> listMembre { get; set; }

        //OPTIONS

        public IEnumerable<ONEoptionsForONEbien> optionsScelte { get; set; }  //optionsScelte.Add(opzioneScelta)
        public ONEoptionsForONEbien opzioneScelta { get; set; }
        public bool isSelected { get; set; }
        [DisplayName("Scegliete le vostre opzioni : ")]
        public IEnumerable<Option> listaOptions { get; set; }

        [Required]
        [DisplayName("Valider le formulaire")]
        public bool isValide { get; set; }

    }
}
