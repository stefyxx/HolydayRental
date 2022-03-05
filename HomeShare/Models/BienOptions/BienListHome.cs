using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class BienListHome
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
