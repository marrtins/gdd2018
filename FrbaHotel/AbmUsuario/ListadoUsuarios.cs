using FrbaHotel.AbmUsuario.Model;
using FrbaHotel.Utilities;
using Rubberduck.Winforms;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class ListadoUsuarios : ModelBoundForm
    {
        BindingList<Usuario> usuarios = new BindingList<Usuario>();

        public ListadoUsuarios()
            :base(new UsuarioFiltros())
        {
            InitializeComponent();

            this.usuariosGridView.AutoGenerateColumns = false;

            this.usuariosGridView.DataSource = usuarios;
        }

        private void btnAlta_Click(object sender, System.EventArgs e)
        {
            AltaModificar alta = new AltaModificar(LoginData.IdUsuario);
            this.Hide();

            alta.ShowDialog();

            this.Show();

            if (alta.Result == DialogResult.OK)
                RefreshData();
        }

        private void RefreshData()
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.UsuarioListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHotel", SqlDbType.Int).Value = LoginData.Hotel.IdHotel;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaUsuarios = dr.MapToList<Usuario>();

                    usuarios.Clear();

                    if(listaUsuarios != null)
                        listaUsuarios.ForEach(lu => usuarios.Add(lu)); // lo hago asi para que no se pierda el binding
                }
            }
        }

        private void usuariosGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //toco los headers
                return;

            var targetUsuario = this.usuariosGridView.Rows[e.RowIndex].DataBoundItem as Usuario;

            if (e.ColumnIndex == this.usuariosGridView.Columns["SeleccionarCol"].DisplayIndex)
            {
                AbrirModificar(targetUsuario);
            } 
        }

        private void AbrirModificar(Usuario usuario)
        {
            AltaModificar alta = new AltaModificar(1,ObjectCloner.DeepCopy(usuario));
            this.Hide();

            alta.ShowDialog();

            this.Show();

            if (alta.Result == DialogResult.OK)
                RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoUsuarios_Shown(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
