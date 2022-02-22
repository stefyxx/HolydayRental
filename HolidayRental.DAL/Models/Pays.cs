using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Models
{
    public class Pays
    {
        //NB: in DB c'é FK solo su BienEchange e non su Membre (giusto non c'é un controllo su Membre
        //lo faroo' io con il mio select che prende direttamente da tab Pays

        //sono solo Europa ;)

        public int idPays { get; set; }
        public string Libelle { get; set; }
    }
}
