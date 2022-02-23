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


    }
}
