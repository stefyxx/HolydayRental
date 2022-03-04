using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models.BienOptions
{
    public class ONEoptionsForONEbien
    {
        public int idBien { get; set; }
        public int idOption { get; set; }
        public string Libelle { get; set; }
        public string Valeur { get; set; }
    }
}
