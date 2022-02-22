using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Models
{
    public class Options
    {
        //posso creare delle nuove options dentro l' MVC
        // legata a OptionsBien
        public int idOption { get; set; }
        public string Libelle { get; set; }
    }
}
