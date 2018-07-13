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



            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Accion";

            bcol.Text = "Modificar "; 
            
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(bcol);


        }

        private void RegistrarInputs()
        {
            usernameInput.DataBindings.Add(new TextBinding(this.Model, "Username"));
            
            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));

            apellidoInput.DataBindings.Add(new TextBinding(this.Model, "Apellido"));

            mailInput.DataBindings.Add(new TextBinding(this.Model, "Mail"));

            nroDocumentoInput.DataBindings.Add(new TextBinding(this.Model, "NroDocumento"));

            cboRol.DisplayMember = "Nombre";
            cboRol.ValueMember = "idRol";
            cboRol.DataSource = Roles.GetAllWithDefault();
            //cboRol.DataBindings.Add(new Binding("SelectedValue", this.Model, "idRol"));

            cboTipoDoc.DisplayMember = "detalle";
            cboTipoDoc.ValueMember = "idTipoDocumento";
            cboTipoDoc.DataSource = TiposDocumento.GetAllWithDefault();

            //cboTipoDoc.DataBindings.Add(new Binding("SelectedValue", this.Model, "idTipoDocumento"));
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
                    cmd.Parameters.AddWithValue("@idTipoDocumento", SqlDbType.Int).Value = filtros.NroDocumento ?? Convert.DBNull; ;//filtros.IdTipoDocumento;
                    cmd.Parameters.AddWithValue("@idRol", SqlDbType.Int).Value = filtros.NroDocumento ?? Convert.DBNull;// filtros.IdRol;

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

            var targetUsuario = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Usuario;

            if (e.ColumnIndex == this.dataGridView1.Columns["SeleccionarCol"].DisplayIndex)
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
            ControlResetter.ResetAllControls(this.gpoFiltros);
        }

        private void usuariosGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuariosGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                /*string nombre,string apellido,string tipodoc,string nrodoc,string mail,string telefono,
            DateTime fechanac,string nacionalidad,string dircalle,int dirnrocalle,string pais,int dirpiso,
            string dirdepto,string dirlocalidad, string habilitado
            */
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                int idPersona = Int32.Parse(row.Cells["idPersona"].Value.ToString());
                string username = row.Cells["username"].Value.ToString();
                string nombre = row.Cells["Nombre"].Value.ToString();
                string apellido = row.Cells["Apellido"].Value.ToString();
                string tipodoc = row.Cells["Tipo Identificacion"].Value.ToString();
                string nrodoc = row.Cells["Nro de Identificacion"].Value.ToString();
                string mail = row.Cells["Mail"].Value.ToString();
                string telefono = row.Cells["Telefono"].Value.ToString();
                DateTime fechanac = DateTime.Parse(row.Cells["Fecha de Nacimiento"].Value.ToString());
                string nacionalidad = row.Cells["Nacionalidad"].Value.ToString();
                string dircalle = row.Cells["Calle"].Value.ToString();
                int dirnrocalle = Int32.Parse(row.Cells["Numero"].Value.ToString());
                string pais = row.Cells["Pais del Domicilio"].Value.ToString();
                int dirpiso = Int32.Parse(row.Cells["Piso"].Value.ToString());
                string dirdepto = row.Cells["Dpto"].Value.ToString();
                string dirloc = row.Cells["Localidad"].Value.ToString();
                string habilitado = row.Cells["Habilitado"].Value.ToString();


                //aca ir a modificar


                //StateMents you Want to execute to Get Data 
            }
        }
    }
}
