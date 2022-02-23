using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;



namespace HolidayRental.DAL.Repository
{
    public class MembreServices : ConnectionBase, IAllRepositoryBASE<Membre>
    {
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Membre] WHERE [idMembre] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);
                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public Membre Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idMembre], [Nom], [Prenom], [Email], [Pays], [Telephone], [Login] FROM [Membre] WHERE [idMembre] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToMembre(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Membre> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idMembre], [Nom], [Prenom], [Email], [Pays], [Telephone], [Login] FROM [Membre]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToMembre(reader);
                }
            }
        }

        public int Insert(Membre entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Membre]([Nom], [Prenom], [Email], [Pays], [Telephone], [Login], [Password]) OUTPUT [inserted].[idMembre] VALUES(@nom, @prenom, @email, @pays, @tel,  @login, @psw)";
                    SqlParameter p_nom = new SqlParameter("nom", entity.Nom);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.Prenom);
                    SqlParameter p_email = new SqlParameter("email", entity.Email);
                    SqlParameter p_pays = new SqlParameter("pays", entity.Pays);
                    SqlParameter p_tel = new SqlParameter("tel", entity.Telephone);
                    SqlParameter p_login = new SqlParameter("login", entity.Login);
                    SqlParameter p_psw = new SqlParameter("psw", entity.Password);

                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_pays);
                    cmd.Parameters.Add(p_tel);
                    cmd.Parameters.Add(p_login);
                    cmd.Parameters.Add(p_psw);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Membre entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Membre] SET [Nom]=@nom, [Prenom]= @prenom, [Email]= @email, [Pays]= @pays, [Telephone]= @tel, [Login]=@login, [Password]=@psw WHERE [idMembre] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    SqlParameter p_nom = new SqlParameter("nom", entity.Nom);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.Prenom);
                    SqlParameter p_email = new SqlParameter("email", entity.Email);
                    SqlParameter p_pays = new SqlParameter("pays", entity.Pays);
                    SqlParameter p_tel = new SqlParameter("tel", entity.Telephone);
                    SqlParameter p_login = new SqlParameter("login", entity.Login);
                    SqlParameter p_psw = new SqlParameter("psw", entity.Password);

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_pays);
                    cmd.Parameters.Add(p_tel);
                    cmd.Parameters.Add(p_login);
                    cmd.Parameters.Add(p_psw);

                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
