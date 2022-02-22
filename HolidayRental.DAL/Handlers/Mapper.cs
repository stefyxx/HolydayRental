using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HolidayRental.DAL.Handlers
{
    public class Mapper
    {
        public static Membre ToMembre(IDataRecord record)
        {
            if (record is null) return null;
            return new Membre
            {
                idMembre = (int)record[nameof(Membre.idMembre)],
                Nom = (string)record[nameof(Membre.Nom)],
                Prenom = (string)record[nameof(Membre.Prenom)],
                Email = (string)record[nameof(Membre.Email)],
                Pays = (int)record[nameof(Membre.Pays)],
                Telephone = (string)record[nameof(Membre.Telephone)],
                Login = (string)record[nameof(Membre.Login)],
                Password = (string)record[nameof(Membre.Password)]
            };
        }

        public static BienEchange ToBienEchange(IDataRecord record)
        {
            if (record is null) return null;
            return new BienEchange
            {
                idBien = (int)record[nameof(BienEchange.idBien)],
                titre = (string)record[nameof(BienEchange.titre)],
                DescCourte = (string)record[nameof(BienEchange.DescCourte)],
                DescLong = (string)record[nameof(BienEchange.DescLong)],
                NombrePerson = (string)record[nameof(BienEchange.NombrePerson)],
                Pays = (int)record[nameof(Membre.Pays)],
                Ville = (string)record[nameof(BienEchange.Ville)],
                Rue = (string)record[nameof(BienEchange.Rue)],
                Numero = (string)record[nameof(BienEchange.Numero)],
                CodePostal = (string)record[nameof(BienEchange.CodePostal)],
                Photo = (string)record[nameof(BienEchange.Photo)],
                AssuranceObligatoire = (bool)record[nameof(BienEchange.AssuranceObligatoire)],
                isEnabled = (bool)record[nameof(BienEchange.isEnabled)],
                //DisabledDate = (DateTime?)record[nameof(BienEchange.DisabledDate)],
                DisabledDate = (record[nameof(BienEchange.DisabledDate)] == DBNull.Value)? null : (DateTime?)record[nameof(BienEchange.DisabledDate)],

                Latitude = (string)record[nameof(BienEchange.Latitude)],
                Longitude = (string)record[nameof(BienEchange.Longitude)],
                idMembre = (int)record[nameof(BienEchange.idMembre)],
                DateCreation = (DateTime)record[nameof(BienEchange.DateCreation)]
            };
        }
    }
}
