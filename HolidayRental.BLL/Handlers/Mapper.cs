using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.BLL.Handlers
{
    public static class Mapper
    {
        public static HolidayRental.BLL.Models.Membre ToBLL(this HolidayRental.DAL.Models.Membre m)
        {
            if (m is null) return null;
            return new HolidayRental.BLL.Models.Membre
            {
                idMembre = m.idMembre,
                Nom = m.Nom,
                Prenom = m.Prenom,
                Email = m.Email,
                Pays = m.Pays,
                Telephone = m.Telephone,
                Login = m.Login,
                Password = m.Password
            };
        }

        public static HolidayRental.DAL.Models.Membre ToDAL(this HolidayRental.BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new HolidayRental.DAL.Models.Membre
            {
                idMembre = m.idMembre,
                Nom = m.Nom,
                Prenom = m.Prenom,
                Email = m.Email,
                Pays = m.Pays,
                Telephone = m.Telephone,
                Login = m.Login,
                Password = m.Password
            };
        }

        public static HolidayRental.BLL.Models.BienEchange ToBLL(this HolidayRental.DAL.Models.BienEchange m)
        {
            if (m is null) return null;
            return new HolidayRental.BLL.Models.BienEchange
            {
                idBien = m.idBien,
                titre = m.titre,
                DescCourte = m.DescCourte,
                DescLong = m.DescLong,
                NombrePerson = m.NombrePerson,
                Pays = m.Pays,
                Ville = m.Ville,
                Rue = m.Rue,
                Numero = m.Numero,
                CodePostal = m.CodePostal,
                Photo = m.Photo,
                AssuranceObligatoire = m.AssuranceObligatoire,
                isEnabled = m.isEnabled,
                DisabledDate = (m.DisabledDate is null)?null:(DateTime?)m.DisabledDate,
                Latitude = m.Latitude,
                Longitude =m.Longitude,
                idMembre = m.idMembre,
                DateCreation =m.DateCreation
            };
        }
        public static HolidayRental.DAL.Models.BienEchange ToDAL(this HolidayRental.BLL.Models.BienEchange m)
        {
            if (m is null) return null;
            return new HolidayRental.DAL.Models.BienEchange
            {
                idBien = m.idBien,
                titre = m.titre,
                DescCourte = m.DescCourte,
                DescLong = m.DescLong,
                NombrePerson = m.NombrePerson,
                Pays = m.Pays,
                Ville = m.Ville,
                Rue = m.Rue,
                Numero = m.Numero,
                CodePostal = m.CodePostal,
                Photo = m.Photo,
                AssuranceObligatoire = m.AssuranceObligatoire,
                isEnabled = m.isEnabled,
                DisabledDate = (m.DisabledDate is null) ? null : (DateTime?)m.DisabledDate,
                Latitude = m.Latitude,
                Longitude = m.Longitude,
                idMembre = m.idMembre,
                DateCreation = m.DateCreation
            };
        }

        public static HolidayRental.BLL.Models.Pays ToBLL(this HolidayRental.DAL.Models.Pays m)
        {
            if (m is null) return null;
            return new HolidayRental.BLL.Models.Pays
            {
                idPays = m.idPays,
                Libelle = m.Libelle
            };
        }

        // implementare ToDALL(Pays) all'occorrenza

        public static HolidayRental.BLL.Models.BienAvecNomPAYS ToBLL(this HolidayRental.DAL.Models.BienAvecNomPAYS m)
        {
            if (m is null) return null;
            return new HolidayRental.BLL.Models.BienAvecNomPAYS
            {
                idBien = m.idBien,
                titre = m.titre,
                DescCourte = m.DescCourte,
                DescLong = m.DescLong,
                NombrePerson = m.NombrePerson,
                PaysLibelle = m.Pays,
                Ville = m.Ville,
                Rue = m.Rue,
                Numero = m.Numero,
                CodePostal = m.CodePostal,
                Photo = m.Photo,
                AssuranceObligatoire = m.AssuranceObligatoire,
                isEnabled = m.isEnabled,
                DisabledDate = (m.DisabledDate is null) ? null : (DateTime?)m.DisabledDate,
                Latitude = m.Latitude,
                Longitude = m.Longitude,
                idMembre = m.idMembre,
                DateCreation = m.DateCreation
            };
        }
    }
}
