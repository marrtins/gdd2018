using FrbaHotel.AbmRol.Model;
using FrbaHotel.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class Listado : Form
    {
        BindingList<Rol> roles;
        BindingList<Funcionalidad> funcionalidades;


        public Listado()
        {
            InitializeComponent();
        }

        private void RefreshRolesData()
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.RolesListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = filtros.Nombre ?? Convert.DBNull;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaRoles = dr.MapToList<Rol>();

                    roles.Clear();

                    if (listaRoles != null)
                        listaRoles.ForEach(lh => roles.Add(lh)); // lo hago asi para que no se pierda el binding
                }
            }
        }

        private void RefreshFuncionalidadesData(int idRol)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.FuncionalidadesListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", SqlDbType.Int).Value = idRol;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaF = dr.MapToList<Funcionalidad>();

                    funcionalidades.Clear();

                    if (listaF != null)
                        listaF.ForEach(lh => funcionalidades.Add(lh)); // lo hago asi para que no se pierda el binding
                }
            }
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var selectedItem = this.dataGridView2.Rows[e.RowIndex].DataBoundItem as Rol;

            RefreshFuncionalidadesData(selectedItem.Id);
        }
    }
}
