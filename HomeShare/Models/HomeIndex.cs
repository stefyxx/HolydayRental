using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class HomeIndex
    {
        //nel corpo
        public IEnumerable<BienTop> BienListTopList { get; set; }

        //per il carosello
        public IEnumerable<BienEchangeList> BienListDernier5 { get; set; }

        //2 servizi x riempire i 2 precedenti
        public IEnumerable<Pays> Payses { get; set; }
        public IEnumerable<MembreNomId> MembreList { get; set; }

        //NON mi serve la proprietà HomeController perché non c'é un model pre-ingettato nella view: infatti ho return View();



    }
}
