using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class BienAvecNomPAYSservices : ConnectionBase, IGetRepository<BienAvecNomPAYS>
    {
        public BienAvecNomPAYS Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idBien], [titre], [DescCourte], [DescLong], [NombrePerson], [Pays], [Ville], [Rue], [Numero], [CodePostal], [Photo], [AssuranceObligatoire], [isEnabled],[DisabledDate], [Latitude], [Longitude], [idMembre], [DateCreation] FROM [dbo].[Vue_BiensParPaysNAME] WHERE [idBien] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToBienAvecNomPAYS(reader);
                    return null;
                }
            }
        }

        public IEnumerable<BienAvecNomPAYS> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idBien], [titre], [DescCourte], [DescLong], [NombrePerson], [Pays], [Ville], [Rue], [Numero], [CodePostal], [Photo], [AssuranceObligatoire], [isEnabled],[DisabledDate], [Latitude], [Longitude], [idMembre], [DateCreation] FROM [dbo].[Vue_BiensParPaysNAME] WHERE [isEnabled]= 1 ORDER BY [Pays]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToBienAvecNomPAYS(reader);
                }
            }
        }
    }
}
