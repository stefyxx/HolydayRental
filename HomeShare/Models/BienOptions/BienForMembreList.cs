using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models.BienOptions
{
    public class BienForMembreList
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien {get;set;}

        [DisplayName("Titre di bien")]
        public string titre { get; set; }

        [DisplayName("Description Courte")]
        public string DescCourte { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date de création")]
        public DateTime DateCreation { get; set; }

        MembreNomId Membre { get; set; }

    }
}
