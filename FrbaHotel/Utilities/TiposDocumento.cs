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
    public static class TiposDocumento
    {
        public static List<TipoDocumento> GetOne(int? id)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.TiposDocumentoListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idTipoDocumento", SqlDbType.NVarChar).Value = id ?? Convert.DBNull;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    return dr.MapToList<TipoDocumento>();
                }
            }
        }

        public static List<TipoDocumento> GetAll()
        {
            return GetOne(null);
        }

    }
}
