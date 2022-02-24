using HolidayRental.Common;
using HolidayRental.DAL.Handlers;
using HolidayRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public class BienOptionPayServices : ConnectionBase, IGetRepositoryDeuxLIST<BienOptionPay>
    {
        public IEnumerable<BienOptionPay> GetALLlist()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idPays], [Libelle], [idBien], [titre], [DescCourte], [DescLong], [NombrePerson], [Ville], [Rue], [Numero], [CodePostal], [Photo], [AssuranceObligatoire], [isEnabled], [DisabledDate], [Latitude], [Longitude], [idMembre], [DateCreation], [Valeur], [idOption], [LibelleOption] FROM [dbo].[Vue_Bien_Option_Pay]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToBienOPTIONpay(reader) ;
                }
            }
        }

        public IEnumerable<BienOptionPay> GetOneList(int id)
        {
            throw new NotImplementedException();
        }
    }
}
