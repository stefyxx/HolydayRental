using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class HomeIndex
    {
        public IEnumerable<BienEchangeList> BienList { get; set; }
        public IEnumerable<Pays> Payses { get; set; }
        public IEnumerable<MembreNomId> MembreList { get; set; }

        //mi serve la proprietà HomeController
        //public ConnectionForm Connection { get; set; }

    }
}
