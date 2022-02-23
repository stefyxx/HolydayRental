using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.BLL.Handlers
{
    public static class Mapper
    {
        public static BLL.Models.Membre ToBLL(this DAL.Models.Membre m)
        {
            if (m is null) return null;
            return new Models.Membre
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

        public static DAL.Models.Membre ToDAL(this BLL.Models.Membre m)
        {
            if (m is null) return null;
            return new DAL.Models.Membre
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

        public static BLL.Models.BienEchange ToBLL(this DAL.Models.BienEchange m)
        {
            if (m is null) return null;
            return new Models.BienEchange
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
        public static DAL.Models.BienEchange ToDAL(this BLL.Models.BienEchange m)
        {
            if (m is null) return null;
            return new DAL.Models.BienEchange
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

        public static BLL.Models.Pays ToBLL(this DAL.Models.Pays m)
        {
            if (m is null) return null;
            return new Models.Pays
            {
                idPays = m.idPays,
                Libelle = m.Libelle
            };
        }

        // implementare ToDALL(Pays) all'occorrenza
    }
}
