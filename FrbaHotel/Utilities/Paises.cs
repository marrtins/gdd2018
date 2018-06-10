using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Utilities
{
    public static class Paises
    {
        public static List<Pais> GetOne(int? id)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.PaisListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idPais", SqlDbType.NVarChar).Value = id ?? Convert.DBNull;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    return dr.MapToList<Pais>();
                }
            }
        }

        public static List<Pais> GetAll()
        {
            return GetOne(null);
        }

        public static List<Pais> GetAllWithDefault()
        {
            var paises = GetOne(null);

            // default
            paises.Insert(0, new Pais(0, "Todos"));

            return paises;
        }

    }
}
