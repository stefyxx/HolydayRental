using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Models
{
    public class Membre
    {
        public int idMembre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        
        //id del Pays: non ha FK
        public int Pays { get; set; }
        public string Telephone { get; set; }

        //NBB: NON SONO NULLABILI-> se cancello un 'membre' sarà cancelllato dalla DB!
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
