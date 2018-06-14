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
        BindingList<Rol> roles = new BindingList<Rol>();
        BindingList<Funcionalidad> funcionalidades = new BindingList<Funcionalidad>();


        public Listado()
        {
            InitializeComponent();

            this.rolesGridView.AutoGenerateColumns = false;
            this.funcionalidadesGrid.AutoGenerateColumns = false;

            this.rolesGridView.DataSource = roles;
            this.funcionalidadesGrid.DataSource = funcionalidades;

            RefreshRolesData();

            this.rolesGridView.MultiSelect = false;
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
                using (SqlCommand cmd = new SqlCommand("MMEL.FuncionalidadesDeRol", con))
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
        private void rolesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedItem = this.rolesGridView.Rows[e.RowIndex].DataBoundItem as Rol;

            RefreshFuncionalidadesData(selectedItem.idRol);
        }

        private void rolesGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedItem = this.rolesGridView.Rows[e.RowIndex].DataBoundItem as Rol;

            RefreshFuncionalidadesData(selectedItem.idRol);
        }
    }
}
