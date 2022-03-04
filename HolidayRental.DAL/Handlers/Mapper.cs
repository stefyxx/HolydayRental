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
                //Password = (string)record[nameof(Membre.Password)]
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
                NombrePerson = (int)record[nameof(BienEchange.NombrePerson)],
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

        public static AvisMembreBien toAvis(IDataRecord record)
        {
            if (record is null) return null;
            return new AvisMembreBien
            {
                idAvis = (int)record[nameof(AvisMembreBien.idAvis)],
                note = (int)record[nameof(AvisMembreBien.note)],
                message = (string)record[nameof(AvisMembreBien.message)],
                idMembre = (int)record[nameof(AvisMembreBien.idMembre)],
                idBien = (int)record[nameof(AvisMembreBien.idBien)],
                DateAvis = (DateTime)record[nameof(AvisMembreBien.DateAvis)],
                Approuve = (bool)record[nameof(AvisMembreBien.Approuve)]

            };
        }

        public static Pays toPays(IDataRecord record)
        {
            if (record is null) return null;
            return new Pays
            {
                idPays = (int)record[nameof(Pays.idPays)],
                Libelle = (string)record[nameof(Pays.Libelle)],
            };
        }

        public static Options toOptions(IDataRecord record)
        {
            if (record is null) return null;
            return new Options
            {
                idOption = (int)record[nameof(Options.idOption)],
                Libelle = (string)record[nameof(Options.Libelle)],
            };
        }

        public static OptionsBien toOptionsBien(IDataRecord record)
        {
            if (record is null) return null;
            return new OptionsBien
            {
                idOption = (int)record[nameof(OptionsBien.idOption)],
                idBien = (int)record[nameof(OptionsBien.idBien)],
                Valeur = (string)record[nameof(OptionsBien.Valeur)],
            };
        }

        public static BienAvecNomPAYS ToBienAvecNomPAYS(IDataRecord record)
        {
            if (record is null) return null;
            return new BienAvecNomPAYS
            {
                idBien = (int)record[nameof(BienAvecNomPAYS.idBien)],
                titre = (string)record[nameof(BienAvecNomPAYS.titre)],
                DescCourte = (string)record[nameof(BienAvecNomPAYS.DescCourte)],
                DescLong = (string)record[nameof(BienAvecNomPAYS.DescLong)],
                NombrePerson = (int)record[nameof(BienAvecNomPAYS.NombrePerson)],
                Pays = (string)record[nameof(BienAvecNomPAYS.Pays)],
                Ville = (string)record[nameof(BienAvecNomPAYS.Ville)],
                Rue = (string)record[nameof(BienAvecNomPAYS.Rue)],
                Numero = (string)record[nameof(BienAvecNomPAYS.Numero)],
                CodePostal = (string)record[nameof(BienAvecNomPAYS.CodePostal)],
                Photo = (string)record[nameof(BienAvecNomPAYS.Photo)],
                AssuranceObligatoire = (bool)record[nameof(BienAvecNomPAYS.AssuranceObligatoire)],
                isEnabled = (bool)record[nameof(BienAvecNomPAYS.isEnabled)],
                //DisabledDate = (DateTime?)record[nameof(BienEchange.DisabledDate)],
                DisabledDate = (record[nameof(BienAvecNomPAYS.DisabledDate)] == DBNull.Value) ? null : (DateTime?)record[nameof(BienAvecNomPAYS.DisabledDate)],

                Latitude = (string)record[nameof(BienAvecNomPAYS.Latitude)],
                Longitude = (string)record[nameof(BienAvecNomPAYS.Longitude)],
                idMembre = (int)record[nameof(BienAvecNomPAYS.idMembre)],
                DateCreation = (DateTime)record[nameof(BienAvecNomPAYS.DateCreation)]
            };
        }

        public static OptionsBienWithLabel_forONEBien ToOptionsForONEBien(IDataRecord record)
        {
            if (record is null) return null;
            return new OptionsBienWithLabel_forONEBien
            {
                idBien = (int)record[nameof(OptionsBienWithLabel_forONEBien.idBien)],
                idOption = (int)record[nameof(OptionsBienWithLabel_forONEBien.idOption)],
                Libelle = (string)record[nameof(OptionsBienWithLabel_forONEBien.Libelle)],
                Valeur = (string)record[nameof(OptionsBienWithLabel_forONEBien.Valeur)],
            };
        }

        public static BienOptionPay ToBienOPTIONpay (IDataRecord record)
        {
            if (record is null) return null;
            return new BienOptionPay
            {
                idPays = (int)record[nameof(BienOptionPay.idPays)],
                Libelle = (string)record[nameof(BienOptionPay.Libelle)],
                idBien = (int)record[nameof(BienOptionPay.idBien)],
                titre = (string)record[nameof(BienOptionPay.titre)],
                DescCourte = (string)record[nameof(BienOptionPay.DescCourte)],
                DescLong = (string)record[nameof(BienOptionPay.DescLong)],
                NombrePerson = (int)record[nameof(BienOptionPay.NombrePerson)],
                Ville = (string)record[nameof(BienOptionPay.Ville)],
                Rue = (string)record[nameof(BienOptionPay.Rue)],
                Numero = (string)record[nameof(BienOptionPay.Numero)],
                CodePostal = (string)record[nameof(BienOptionPay.CodePostal)],
                Photo = (string)record[nameof(BienOptionPay.Photo)],
                AssuranceObligatoire = (bool)record[nameof(BienOptionPay.AssuranceObligatoire)],
                isEnabled = (bool)record[nameof(BienOptionPay.isEnabled)],
                DisabledDate = (record[nameof(BienOptionPay.DisabledDate)] == DBNull.Value) ? null : (DateTime?)record[nameof(BienOptionPay.DisabledDate)],
                Latitude = (string)record[nameof(BienOptionPay.Latitude)],
                Longitude = (string)record[nameof(BienOptionPay.Longitude)],
                idMembre = (int)record[nameof(BienOptionPay.idMembre)],
                DateCreation = (DateTime)record[nameof(BienOptionPay.DateCreation)],
                Valeur = (string)record[nameof(BienOptionPay.Valeur)],
                idOption = (int)record[nameof(BienOptionPay.idOption)],
                LibelleOption = (string)record[nameof(BienOptionPay.LibelleOption)],
            };
        }
    }
}
