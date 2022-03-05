



using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class BienLastFive
    {
        [Key]
        public int idBien { get; set; }
       
        public string titre { get; set; }

        public string Photo { get; set; }

        public bool AssuranceObligatoire { get; set; }
    }
}
