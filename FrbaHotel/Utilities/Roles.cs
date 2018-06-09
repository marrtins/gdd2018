﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Utilities
{
    public static class Roles
    {
        public static List<Rol> GetAllFor(int idUsuario)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.RolesDeUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    return dr.MapToList<Rol>();
                }
            }
        }
    }
}
