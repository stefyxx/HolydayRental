using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HoliDayRental.Models
{
    public class MembreCreate
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idMembre { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Le nom doit comporter au moins 2 caractères")]
        [DisplayName("Nom: ")]
        public string Nom { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Le prénom doit comporter au moins 2 caractères")]
        [DisplayName("Prenom: ")]
        public string Prenom { get; set; }

        //[EmailAddress(ErrorMessage = "L'adresse n'est au bon format.")]
        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(maximumLength: 256, MinimumLength = 2)]
        [DisplayName("Email: ")]
        public string Email { get; set; }

        //id del Pays: non ha FK
        [Required]
        [DisplayName("Pays: ")]
        public int idPays { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("Telephone: ")]
        public string Telephone { get; set; }

        //NBB: NON SONO NULLABILI-> se cancello un 'membre' sarà cancellato dalla DB!
        [DisplayName("Login: ")]
        public string Login { get; set; }

        /*public string Login { get
            { //se Nom e Prenon non sono nulli o sono solo spazi bianchi
                if (string.IsNullOrWhiteSpace(this.Prenom) || string.IsNullOrWhiteSpace(this.Nom)) throw new FormatException();
                //prendo del cognome solo i primi 5 caratteri e se mi chiamo 'DE Castro' prendera xde.ca (dove x é la prima lettera del Prenom)
                return this.Prenom.Substring(0, 1) + this.Nom.Substring(0, 5).Replace(' ', '.');
            } 
        }*/

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        [DisplayName("Password: ")]
        public string Password { get; set; }

        public IEnumerable<Pays> Payses { get; set; }

        [Required]
        public bool conditionAccepted { get; set; }

        [Required]
        public bool isValide { get; set; }
    }
}
