using HoliDayRental.Models.BienOptions;
using System.Collections.Generic;


namespace HoliDayRental.Models
{
    public class HomeIndex
    {
        //nel corpo
        public IEnumerable<BienListHome> BienList { get; set; }

        //per il carosello
        public IEnumerable<BienOptionsDetails> BienMeilleurs15Avis { get; set; }

        //nel piede
        public IEnumerable<BienLastFive> BiensDerniers5 { get; set; }


        //NON mi serve la proprietà HomeController perché non c'é un model pre-ingettato nella view: infatti ho return View();
    }
}
