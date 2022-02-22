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
    }
}
