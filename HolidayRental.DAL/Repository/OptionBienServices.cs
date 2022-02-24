using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class OptionBienServices : ConnectionBase, IGetRepositotyTwoInt<OptionsBien, int, int>
    {
        public OptionsBien Get(int idOption, int idBien)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idOption], [idBien], [Valeur] FROM [OptionsBien] WHERE [idOption] = @idOption and [idBien]=@idBien ";

                    SqlParameter p_id1 = new SqlParameter("idOption", idOption);
                    cmd.Parameters.Add(p_id1);
                    SqlParameter p_id2 = new SqlParameter("idBien", idBien);
                    cmd.Parameters.Add(p_id2);
                    c.Open();


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.toOptionsBien(reader);
                    return null;
                }
            }
        }

        public IEnumerable<OptionsBien> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idOption], [idBien], [Valeur] FROM [OptionsBien]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.toOptionsBien(reader);
                }
            }
        }
    }
}
