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
    }
}
