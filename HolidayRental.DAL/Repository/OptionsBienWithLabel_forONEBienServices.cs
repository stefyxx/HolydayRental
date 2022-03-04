using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class OptionsBienWithLabel_forONEBienServices : ConnectionBase, IRepoOptionsONEbien<OptionsBienWithLabel_forONEBien>
    {
        public IEnumerable<OptionsBienWithLabel_forONEBien> AllOptionsForONEBien(int idBien)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Options_for_ONE_Bien_With_Libelle_ET_Valeur";

                    SqlParameter bene = new SqlParameter("bene", idBien);
                    cmd.Parameters.Add(bene);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptionsForONEBien(reader);

                }
            }

        }
    }
}
