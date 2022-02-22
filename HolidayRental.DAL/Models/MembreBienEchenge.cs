using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Models
{
    public class MembreBienEchenge
    {
        //PK composte: int idMember + int idBien + dateTime DateDebEchenge +dateTime DateFinEchenge

        public int idMembre { get; set; }
        public int idBien { get; set; }
        public DateTime DateDebEchenge { get; set; } //inizio affitto
        public DateTime DateFinEchenge { get; set; } // fine affitto

        //NBB: PUO' ESSRE NULL
        // qui' memorizzo se al momento dello scambio aveva o no l'assurance
        //(cosi' se dopo l'ho cambiata in BienEchange, almeno ho uno storico)
        public bool? Assurance { get; set; }

        //io proprietario decido se accetto o no il cambio
        public bool Valide { get; set; }
    }
}
