using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreNomId
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idMembre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
