

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models.Membre
{
    public class MembreEdit : MembreNomId
    {
        [Required]
        [DisplayName("Cambio Email:")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Téléphone")]
        public string Telephone { get; set; }

        [Required]
        [DisplayName("Cambio Login:")]
        public string Login { get; set; }

        [DisplayName("Cambia Password: ")]
        public string Password { get; set; }

        public IEnumerable<Pays> Payses { get; set; }
        

    }
}
