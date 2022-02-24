using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class BienEchangeList
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien { get; set; }

        [DisplayName("Titre: ")]
        public string titre { get; set; }

        [DisplayName("Description: ")]
        public string DescCourte { get; set; }

        [DisplayName("Combien de personnes max: ")]
        public int NombrePerson { get; set; }

        [ScaffoldColumn(false)]
        public int Pays { get; set; }

        [DisplayName("Pays européen: ")]
        public string PaysLibelle { get; set; }
        //public string PaysLibelle { get { return this.Payses.Libelle; } }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }
    }
}
