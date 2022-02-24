using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreCreate
    {
        public int idMembre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        //id del Pays: non ha FK
        public int idPays { get; set; }
        public string Telephone { get; set; }

        //NBB: NON SONO NULLABILI-> se cancello un 'membre' sarà cancelllato dalla DB!
        public string Login { get; set; }
        public string Password { get; set; }

        public IEnumerable<Pays> Payses { get; set; }
        public bool isValide { get; set; }
    }
}
