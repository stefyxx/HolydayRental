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

        [DisplayName("Titre: ")]
        [DataType(DataType.Text)]
        public string titre { get; set; }

        //[DataType(DataType.ImageUrl)]
        [Required]
        [MaxLength(50)]
        public string Photo { get; set; }

        [DisplayName("Assuré ? : ")]
        public bool AssuranceObligatoire { get; set; }



        [DisplayName("options: ")]
        public IEnumerable<Option> options { get; set; }

        public int idOption { get; set; }
    }
}
