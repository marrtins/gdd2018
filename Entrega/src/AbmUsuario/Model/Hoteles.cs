using System;
using System.Collections.Generic;
using System.Configuration;
using FrbaHotel.Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmUsuario.Model
{
    public static class Hoteles
    {

        public static List<Hotel> GetOne(int? id)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelesDisponibles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idHotel", SqlDbType.NVarChar).Value = id ?? Convert.DBNull;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    return dr.MapToList<Hotel>();
                }
            }
        }

        public static List<Hotel> GetAll()
        {
            return GetOne(null);
        }

    }
}
