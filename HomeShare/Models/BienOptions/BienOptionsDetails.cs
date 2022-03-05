using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HoliDayRental.Models.BienOptions
{
    public class BienOptionsDetails
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien { get; set; }

        [DisplayName("Titre: ")]
        public string DescCourte { get; set; }

        public string Photo { get; set; }

        public string DescLong { get; set; }

        [DisplayName("Max n° de personnes: ")]
        public int NombrePerson { get; set; }

        [DisplayName("Adresse: ")]
        public int idPays { get; set; }
        public Pays payses { get; set; } //a recuperare in action

        public string Ville { get; set; }

        public string Rue { get; set; }

        public string Numero { get; set; }

        public string CodePostal { get; set; }

        public bool AssuranceObligatoire { get; set; }

        //lista di opzioni con Libelle et Valeur -> sp_
        [DisplayName("Options : ")]
        public IEnumerable<ONEoptionsForONEbien> options { get; set; }

        //per Home, piccola parola sotto la foto
        public string mot { get; set; }
    }
}
