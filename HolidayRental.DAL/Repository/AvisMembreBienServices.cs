using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class AvisMembreBienServices : ConnectionBase, IAllRepositoryBASE<AvisMembreBien>
    {
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [AvisMembreBien] WHERE [idAvis] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);
                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AvisMembreBien Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [note], [message], [idMembre], [idBien], [DateAvis], [Approuve] FROM [AvisMembreBien] WHERE [idAvis] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.toAvis(reader);
                    return null;
                }
            }
        }

        public IEnumerable<AvisMembreBien> Get()
        {
            using(SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idAvis], [note], [message], [idMembre], [idBien], [DateAvis], [Approuve] FROM [AvisMembreBien]";
                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.toAvis(reader);
                }
            }
        }

        public int Insert(AvisMembreBien entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [AvisMembreBien]([note], [message], [idMembre], [idBien], [DateAvis], [Approuve]) OUTPUT [inserted].[idAvis] VALUES(@note, @sms, @membroId, @beneId, @date,  @approvato)";
                    
                    SqlParameter p_note = new SqlParameter("note", entity.note);
                    SqlParameter p_sms = new SqlParameter("sms", entity.message);
                    SqlParameter p_membroId = new SqlParameter("membroId", entity.idMembre);
                    SqlParameter p_beneId = new SqlParameter("beneId", entity.idBien);
                    SqlParameter p_date = new SqlParameter("date", entity.DateAvis);
                    SqlParameter p_approvato = new SqlParameter("approvato", entity.Approuve);

                    cmd.Parameters.Add(p_note);
                    cmd.Parameters.Add(p_sms);
                    cmd.Parameters.Add(p_membroId);
                    cmd.Parameters.Add(p_beneId);
                    cmd.Parameters.Add(p_date);
                    cmd.Parameters.Add(p_approvato);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, AvisMembreBien entity)
        {

            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [AvisMembreBien] SET [note] = @note,[message] = @sms,[idMembre] = @membroId,[idBien] = @beneId,[DateAvis] = @date,[Approuve] = @approvat WHERE [idAvis] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    SqlParameter p_note = new SqlParameter("note", entity.note);
                    SqlParameter p_sms = new SqlParameter("sms", entity.message);
                    SqlParameter p_membroId = new SqlParameter("membroId", entity.idMembre);
                    SqlParameter p_beneId = new SqlParameter("beneId", entity.idBien);
                    SqlParameter p_date = new SqlParameter("date", entity.DateAvis);
                    SqlParameter p_approvato = new SqlParameter("approvato", entity.Approuve);

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_note);
                    cmd.Parameters.Add(p_sms);
                    cmd.Parameters.Add(p_membroId);
                    cmd.Parameters.Add(p_beneId);
                    cmd.Parameters.Add(p_date);
                    cmd.Parameters.Add(p_approvato);


                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
