using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Models
{
    public class OptionsBienWithLabel_forONEBien
    {
        public int idBien { get; set; }
        public int idOption { get; set; }
        public string Libelle { get; set; }
        public string Valeur { get; set; }
    }
}
