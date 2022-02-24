using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class OptionServices : ConnectionBase, IGetRepository<Options>
    {
        public Options Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idOption], [Libelle] FROM [Options] WHERE [idOption] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.toOptions(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Options> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idOption], [Libelle] FROM [Options]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.toOptions(reader);
                }
            }
        }
    }
}
