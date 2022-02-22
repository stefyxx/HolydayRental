using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class BienEchangeServices : ConnectionBase, IAllRepositoryBASE<BienEchange>
    {
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [BienEchange] WHERE [idBien] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);
                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public BienEchange Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [titre], [DescCourte], [DescLong], [NombrePerson], [Pays], [Ville], [Rue], [Numero], [CodePostal], [Photo], [AssuranceObligatoire], [isEnabled],[DisabledDate], [Latitude], [Longitude], [idMembre], [DateCreation] FROM [BienEchange] WHERE [idBien] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToBienEchange(reader);
                    return null;
                }
            }
        }

        public IEnumerable<BienEchange> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idBien], [titre], [DescCourte], [DescLong], [NombrePerson], [Pays], [Ville], [Rue], [Numero], [CodePostal], [Photo], [AssuranceObligatoire], [isEnabled],[DisabledDate], [Latitude], [Longitude], [idMembre], [DateCreation] FROM [BienEchange]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToBienEchange(reader);
                }
            }
        }

        public int Insert(BienEchange entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    //VALUES((COALESCE((SELECT MAX(idClient) FROM [Client]),0)+1), 
                    cmd.CommandText = "INSERT INTO [BienEchange]([titre], [DescCourte], [DescLong], [NombrePerson], [Pays], [Ville], [Rue], [Numero], [CodePostal], [Photo], [AssuranceObligatoire], [isEnabled], [DisabledDate], [Latitude], [Longitude], [idMembre], [DateCreation]) OUTPUT [inserted].[idBien] VALUES(@titre, @pDescr, @lDescr, @capacity, @pays, @ville, @rue, @nr, @zip, @photo, @ass, @active, @noDate, @lat, @long, @idM, @creation)";

                    SqlParameter p_titre = new SqlParameter("titre", entity.titre);
                    SqlParameter p_pDescre = new SqlParameter("pDescr", entity.DescCourte);
                    SqlParameter p_lDescr = new SqlParameter("lDescr", entity.DescLong);
                    SqlParameter p_capacity = new SqlParameter("capacity", entity.NombrePerson);
                    SqlParameter p_idPays = new SqlParameter("pays", entity.Pays);
                    SqlParameter p_Ville = new SqlParameter("ville", entity.Ville);
                    SqlParameter p_rue = new SqlParameter("rue", entity.Rue);
                    SqlParameter p_nr = new SqlParameter("nr", entity.Numero);
                    SqlParameter p_zip = new SqlParameter("zip", entity.CodePostal);
                    SqlParameter p_photo = new SqlParameter("photo", entity.Photo);
                    SqlParameter p_ass = new SqlParameter("ass", entity.AssuranceObligatoire);
                    SqlParameter p_active = new SqlParameter("active", entity.isEnabled);
                    SqlParameter p_noDate = new SqlParameter("noDate", (object)entity.DisabledDate ?? DBNull.Value);
                    SqlParameter p_lat = new SqlParameter("lat", entity.Latitude);
                    SqlParameter p_long = new SqlParameter("long", entity.Longitude);
                    SqlParameter p_idMembre = new SqlParameter("idM", entity.idMembre);
                    SqlParameter p_creation = new SqlParameter("creation", entity.DateCreation);

                    cmd.Parameters.Add(p_titre);
                    cmd.Parameters.Add(p_pDescre);
                    cmd.Parameters.Add(p_lDescr);
                    cmd.Parameters.Add(p_capacity);
                    cmd.Parameters.Add(p_idPays);
                    cmd.Parameters.Add(p_Ville);
                    cmd.Parameters.Add(p_rue);
                    cmd.Parameters.Add(p_nr);
                    cmd.Parameters.Add(p_zip);
                    cmd.Parameters.Add(p_photo);
                    cmd.Parameters.Add(p_ass);
                    cmd.Parameters.Add(p_active);
                    cmd.Parameters.Add(p_noDate);
                    cmd.Parameters.Add(p_lat);
                    cmd.Parameters.Add(p_long);
                    cmd.Parameters.Add(p_idMembre);
                    cmd.Parameters.Add(p_creation);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, BienEchange entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    //VALUES((COALESCE((SELECT MAX(idClient) FROM [Client]),0)+1), 
                    cmd.CommandText = "UPDATE [BienEchange] SET[titre] = @titre, [DescCourte] = @pDescr, [DescLong] = @lDescr,[NombrePerson] =@capacity,[Pays] = @pays,[Ville] = @ville,[Rue] = @rue,[Numero] = @nr,[CodePostal] = @zip,[Photo] =@photo,[AssuranceObligatoire] = @ass,[isEnabled] =@active,[DisabledDate] = @noDate,[Latitude] = @lat,[Longitude] = @long,[idMembre] = idM,[DateCreation] = @creation WHERE[idBien] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    SqlParameter p_titre = new SqlParameter("titre", entity.titre);
                    SqlParameter p_pDescre = new SqlParameter("pDescr", entity.DescCourte);
                    SqlParameter p_lDescr = new SqlParameter("lDescr", entity.DescLong);
                    SqlParameter p_capacity = new SqlParameter("capacity", entity.NombrePerson);
                    SqlParameter p_idPays = new SqlParameter("pays", entity.Pays);
                    SqlParameter p_Ville = new SqlParameter("ville", entity.Ville);
                    SqlParameter p_rue = new SqlParameter("rue", entity.Rue);
                    SqlParameter p_nr = new SqlParameter("nr", entity.Numero);
                    SqlParameter p_zip = new SqlParameter("zip", entity.CodePostal);
                    SqlParameter p_photo = new SqlParameter("photo", entity.Photo);
                    SqlParameter p_ass = new SqlParameter("ass", entity.AssuranceObligatoire);
                    SqlParameter p_active = new SqlParameter("active", entity.isEnabled);
                    SqlParameter p_noDate = new SqlParameter("noDate", (object)entity.DisabledDate ?? DBNull.Value);
                    SqlParameter p_lat = new SqlParameter("lat", entity.Latitude);
                    SqlParameter p_long = new SqlParameter("long", entity.Longitude);
                    SqlParameter p_idMembre = new SqlParameter("idM", entity.idMembre);
                    SqlParameter p_creation = new SqlParameter("creation", entity.DateCreation);

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_titre);
                    cmd.Parameters.Add(p_pDescre);
                    cmd.Parameters.Add(p_lDescr);
                    cmd.Parameters.Add(p_capacity);
                    cmd.Parameters.Add(p_idPays);
                    cmd.Parameters.Add(p_Ville);
                    cmd.Parameters.Add(p_rue);
                    cmd.Parameters.Add(p_nr);
                    cmd.Parameters.Add(p_zip);
                    cmd.Parameters.Add(p_photo);
                    cmd.Parameters.Add(p_ass);
                    cmd.Parameters.Add(p_active);
                    cmd.Parameters.Add(p_noDate);
                    cmd.Parameters.Add(p_lat);
                    cmd.Parameters.Add(p_long);
                    cmd.Parameters.Add(p_idMembre);
                    cmd.Parameters.Add(p_creation);

                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<BienEchange> GetLibre(DateTime dateDebut, DateTime dateFin)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_RecupBienDispo";

                    SqlParameter p_date1 = new SqlParameter("DateDeb", dateDebut);
                    SqlParameter p_date2 = new SqlParameter("DateFin", dateFin);
                    cmd.Parameters.Add(p_date1);
                    cmd.Parameters.Add(p_date1);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToBienEchange(reader);
                }
            }
        }

        public IEnumerable<BienEchange> GetAllBiensParMembre(int idMembro)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_RecupBienMembre";

                    SqlParameter p_id = new SqlParameter("idMembre", idMembro);

                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToBienEchange(reader);
                }
            }
        }
    }
}
