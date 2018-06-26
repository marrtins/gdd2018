using FrbaHotel.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Login.Model
{
    public static class HotelesLogin
    {
        public static List<HotelLogin> GetAllFor(int userId)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelesDeUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = userId;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    return dr.MapToList<HotelLogin>();
                }
            }
        }
    }
}
