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

            RegistrarInputs();
        }

        private void RegistrarInputs()
        {
            usernameInput.DataBindings.Add(new TextBinding(this.Model, "Username"));
            
            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));

            apellidoInput.DataBindings.Add(new TextBinding(this.Model, "Apellido"));

            mailInput.DataBindings.Add(new TextBinding(this.Model, "Mail"));

            nroDocumentoInput.DataBindings.Add(new TextBinding(this.Model, "NroDocumento"));

            cboRol.DataSource = Roles.GetAll();

            cboRol.DataBindings.Add(new Binding("SelectedValue", this.Model, "IdRol"));

            cboTipoDoc.DataSource = TiposDocumento.GetAll();

            cboTipoDoc.DataBindings.Add(new Binding("SelectedValue", this.Model, "IdTipoDocumento"));
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
            var filtros = (UsuarioFiltros)this.Model;
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.UsuarioListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", SqlDbType.NVarChar).Value = filtros.Username ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = filtros.Nombre ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@Apellido", SqlDbType.NVarChar).Value = filtros.Apellido ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = filtros.Mail ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@NroDocumento", SqlDbType.NVarChar).Value = filtros.NroDocumento ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@IdTipoDocumento", SqlDbType.Int).Value = filtros.IdTipoDocumento;
                    cmd.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = filtros.IdRol;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaUsuarios = dr.MapToList<Usuario>();

                    usuarios.Clear();

                    if(listaUsuarios != null)
                        listaUsuarios.ForEach(lu => usuarios.Add(lu)); // lo hago asi para que no se pierda el binding
                }
            }
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            RefreshData();
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this.filtrosGroup);
        }
    }
}
