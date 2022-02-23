using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class PaysServeces : ConnectionBase, IAllRepositoryBASE<Pays>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pays Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idPays], [Libelle] FROM [Pays] WHERE [idPays] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.toPays(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Pays> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idPays], [Libelle] FROM [Pays]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.toPays(reader);
                }
            }
        }

        public int Insert(Pays entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Pays entity)
        {
            throw new NotImplementedException();
        }
    }
}
