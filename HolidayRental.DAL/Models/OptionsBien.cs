using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Models
{
    public class OptionsBien
    {
        // legata a OptionsBien et BienEchange

        //PK composte: idOption + idBien
        public int idOption { get; set; }
        public int idBein { get; set; }

        //es: chiean admis -> "oui" opp. "petit chien"
        public string Valeur { get; set; }
    }
}
