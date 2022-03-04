using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class BienTop
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idBien { get; set; }

        [DataType(DataType.Text)]
        public string titre { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        public string CodePostal { get; set; }

        public string Ville { get; set; }


        public int Pays { get; set; }

        public Pays payses { get; set; }

        public string DescCourte { get; set; }

    }
}
