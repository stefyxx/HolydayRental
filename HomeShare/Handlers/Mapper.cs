using HoliDayRental.Models;
using HoliDayRental.Models.BienOptions;
using HoliDayRental.Models.Membre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Handlers
{
    public static class Mapper
    {
        #region Bien
        public static BienLastFive ToLastFiveBien(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienLastFive
            {
                idBien = bien.idBien,
                titre= bien.titre,
                Photo = bien.Photo,
                AssuranceObligatoire = bien.AssuranceObligatoire
            };
        }

        public static BienEchangeDetails ToDetailsBien(this HolidayRental.BLL.Models.BienAvecNomPAYS bien)
        {
            if (bien is null) return null;
            return new BienEchangeDetails
            {
                idBien = bien.idBien,
                titre = bien.titre,
                Photo = bien.Photo,
                DescLong = bien.DescLong,
                NombrePerson = bien.NombrePerson,
                libellePays = bien.PaysLibelle,
                Ville =bien.Ville,
                Rue =bien.Rue,
                Numero = bien.Numero,
                CodePostal= bien.CodePostal,
                AssuranceObligatoire =bien.AssuranceObligatoire,
                Latitude=bien.Latitude,
                Longitude=bien.Longitude
            };
        }
         public static BienEchangeDetails ToDetBienSansPay(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienEchangeDetails
            {
                idBien = bien.idBien,
                titre = bien.titre,
                Photo = bien.Photo,
                DescLong = bien.DescLong,
                NombrePerson = bien.NombrePerson,
                Pays = bien.Pays,
                Ville = bien.Ville,
                Rue = bien.Rue,
                Numero = bien.Numero,
                CodePostal = bien.CodePostal,
                AssuranceObligatoire = bien.AssuranceObligatoire,
                Latitude = bien.Latitude,
                Longitude = bien.Longitude
            };
        }

        public static BienEdite ToEditeBien(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienEdite
            {
                idBien = bien.idBien,
                titre = bien.titre,
                Photo = bien.Photo,
                DescCourte = bien.DescCourte,
                DescLong = bien.DescLong,
                NombrePerson = bien.NombrePerson,
                Pays = bien.Pays,
                Ville = bien.Ville,
                Rue = bien.Rue,
                Numero = bien.Numero,
                CodePostal = bien.CodePostal,
                AssuranceObligatoire = bien.AssuranceObligatoire,
                DisabledDate =bien.DisabledDate,
                Latitude = bien.Latitude,
                Longitude = bien.Longitude,
                isEnabled = bien.isEnabled,
                //NON sono da Update! ma sono da recuperare se non voglio errori in BLL->DAL
                DateCreation = bien.DateCreation,
                idMembre= bien.idMembre
            };
        }

        public static BienDelete ToDeleteBien(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienDelete
            {
                idBien= bien.idBien,
                Photo =bien.Photo,
                titre =bien.titre,
                Ville=bien.Ville,
                Rue = bien.Rue,
                Numero= bien.Numero,
                CodePostal =bien.CodePostal,
                NombrePerson=bien.NombrePerson,
                idMembre =bien.idMembre,
                idPays=bien.Pays
            };
        }

        public static BienAvecPAYS ToListBienPAYS(this HolidayRental.BLL.Models.BienAvecNomPAYS bien)
        {
            if (bien is null) return null;
            return new BienAvecPAYS
            {
                idBien = bien.idBien,
                titre = bien.titre,
                DescCourte = bien.DescCourte,
                NombrePerson = bien.NombrePerson,
                libellePays = bien.PaysLibelle,
                Photo = bien.Photo
            };
        }

        public static BienListHome TOPbien(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienListHome
            {
                idBien = bien.idBien,
                titre = bien.titre,
                Photo = bien.Photo,
                CodePostal = bien.CodePostal,
                Ville = bien.Ville,
                Pays = bien.Pays,
                DescCourte = bien.DescCourte
            };
        }
        public static ONEoptionsForONEbien ToOptionsForONEbien(this HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien bop)
        {
            if (bop is null) return null;
            return new ONEoptionsForONEbien
            {
                idBien = bop.idBien,
                idOption = bop.idOption,
                Libelle = bop.Libelle,
                Valeur = bop.Valeur
            };
        }

        public static BienOptionsDetails ToBienDet(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienOptionsDetails
            {
                idBien = bien.idBien,
                Photo = bien.Photo,
                DescCourte = bien.DescCourte,
                DescLong = bien.DescLong,
                NombrePerson = bien.NombrePerson,
                idPays = bien.Pays,
                Ville = bien.Ville,
                Rue = bien.Rue,
                Numero = bien.Numero,
                CodePostal = bien.CodePostal,
                AssuranceObligatoire = bien.AssuranceObligatoire,
            };
        }

        public static BienForMembreList ToBienFORmembre(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienForMembreList
            {
                idBien = bien.idBien,
                titre = bien.titre,
                DescCourte = bien.DescCourte,
                DateCreation = bien.DateCreation
            };
        }

        #endregion
        public static Pays ToPays(this HolidayRental.BLL.Models.Pays p)
        {
            if (p is null) return null;
            return new Pays
            {
                idPays = p.idPays,
                Libelle = p.Libelle
            };
        }

        public static Option ToOption(this HolidayRental.BLL.Models.Options p)
        {
            if (p is null) return null;
            return new Option
            {
                idOption = p.idOption,
                Libelle = p.Libelle
            };
        }


        #region Membre
        public static MembreNomId ToLabeMembre(this HolidayRental.BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new MembreNomId
            {
                idMembre = m.idMembre,
                Nom = m.Nom,
                Prenom = m.Prenom,
                idPays = m.Pays
            };
        }

        public static MembreDetails ToDetailsMembre (this HolidayRental.BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new MembreDetails
            {
                idMembre=m.idMembre,
                Nom=m.Nom,
                Prenom=m.Prenom,
                Email =m.Email,
                Telephone =m.Telephone,
                idPays =m.Pays
            };

        }

        public static MembreCreate ToMembre(this HolidayRental.BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new MembreCreate
            {
                idMembre = m.idMembre,
                Nom = m.Nom,
                Prenom = m.Prenom,
                Email = m.Email,
                Telephone = m.Telephone,
                idPays = m.Pays,
                Password =m.Password
            };
        }

        public static MembreEdit ToEditMembre(this HolidayRental.BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new MembreEdit
            {
                idMembre = m.idMembre,
                Nom = m.Nom,
                Prenom = m.Prenom,
                Email = m.Email,
                Telephone = m.Telephone,
                idPays = m.Pays,
                Password = m.Password
            };

            }
        #endregion
    }
}
