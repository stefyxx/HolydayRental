using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Models
{
    public class AvisMembreBien
    {
        public int idAvis { get; set; }

        //da 0 a 10 : MVC
        public int note { get; set; }
        public string messsage { get; set; }
        public int idMembre { get; set; }
        public int idBien { get; set; }
        public DateTime DateAvis { get; set; }
        public bool Approuve { get; set; }

    }
}
