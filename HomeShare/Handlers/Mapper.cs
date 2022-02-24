using HoliDayRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Handlers
{
    public static class Mapper
    {
        public static BienEchangeList ToListBien(this HolidayRental.BLL.Models.BienEchange bien)
        {
            if (bien is null) return null;
            return new BienEchangeList
            {
                idBien = bien.idBien,
                titre= bien.titre,
                DescCourte = bien.DescCourte,
                NombrePerson = bien.NombrePerson,
                Pays = bien.Pays,
                Photo = bien.Photo
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
                //controllare che non sie nullo
                DateCreation = bien.DateCreation,
                idMembre= bien.idMembre
            };

        }

        public static Pays ToPays(this HolidayRental.BLL.Models.Pays p)
        {
            if (p is null) return null;
            return new Pays
            {
                idPays = p.idPays,
                Libelle = p.Libelle
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

        public static MembreNomId ToLabeMembre(this HolidayRental.BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new MembreNomId
            {
                idMembre=m.idMembre,
                Nom=m.Nom,
                Prenom =m.Prenom
            };
        }

        public static MembreLista ToListMembre(this HolidayRental.BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new MembreLista
            {
                idMembre = m.idMembre,
                idPays= m.Pays,
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
                Login=m.Login,
                Password =m.Password
            };
        }
    }
}
