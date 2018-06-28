using FrbaHotel.AbmUsuario.Model;
using FrbaHotel.Utilities;
using Rubberduck.Winforms;
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

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaModificar : ModelBoundForm
    {
        private int idUsuario;
        private DialogResult result;
        private Action<Usuario> accion;
        private List<Pais> paises;
        private List<TipoDocumento> tiposDocumento;
        private List<Rol> roles;
        private List<Hotel> hoteles;

        public DialogResult Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        public AltaModificar(int idUsuario)
            : base(new Usuario())
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.paises = Paises.GetAll();
            this.roles = Roles.GetAll();
            this.tiposDocumento = TiposDocumento.GetAll();
            this.hoteles = Hoteles.GetAll();
            this.Text = "Crear";

            CargarDefaults(this.Model as Usuario);

            RegistrarInputs();

            accion = Crear;
        }

        private void CargarDefaults(Usuario usuario) //normalmente esto iria en el constructor, pero puede traer problemas con otras cosas
        {
            usuario.Activo = 'S'; // Por defecto activo
            usuario.IdTipoDocumento = 1;
            usuario.IdPais = 1;
            usuario.IdRol = 1;
            usuario.IdHotel = 1;
        }

        public AltaModificar(int idUsuario, Usuario usuario)
            :base(usuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.paises = Paises.GetAll();
            this.roles = Roles.GetAll();
            this.tiposDocumento = TiposDocumento.GetAll();
            this.hoteles = Hoteles.GetAll();
            this.Text = "Modificar";

            RegistrarInputs();

            accion = Modificar;
        }

        private void RegistrarInputs()
        {
            usernameInput.DataBindings.Add(new TextBinding(this.Model, "Username"));
            Register(ErrorLabel.For(usernameInput, Alignment.Bottom, 2));

            passwordInput.DataBindings.Add(new TextBinding(this.Model, "Password"));
            Register(ErrorLabel.For(passwordInput, Alignment.Bottom, 2));

            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));
            Register(ErrorLabel.For(nombreInput, Alignment.Bottom, 2));

            apellidoInput.DataBindings.Add(new TextBinding(this.Model, "Apellido"));
            Register(ErrorLabel.For(apellidoInput, Alignment.Bottom, 2));

            telefonoInput.DataBindings.Add(new TextBinding(this.Model, "Telefono"));
            Register(ErrorLabel.For(telefonoInput, Alignment.Bottom, 2));

            mailInput.DataBindings.Add(new TextBinding(this.Model, "Mail"));
            Register(ErrorLabel.For(mailInput, Alignment.Bottom, 2));

            calleInput.DataBindings.Add(new TextBinding(this.Model, "Calle"));
            Register(ErrorLabel.For(calleInput, Alignment.Bottom, 2));

            nroCalleInput.DataBindings.Add(new TextBinding(this.Model, "NroCalle"));
            Register(ErrorLabel.For(nroCalleInput, Alignment.Bottom, 2));

            deptoInput.DataBindings.Add(new TextBinding(this.Model, "Depto"));
            Register(ErrorLabel.For(deptoInput, Alignment.Bottom, 2));

            pisoInput.DataBindings.Add(new TextBinding(this.Model, "Piso"));
            Register(ErrorLabel.For(pisoInput, Alignment.Bottom, 2));

            localidadInput.DataBindings.Add(new TextBinding(this.Model, "Localidad"));
            Register(ErrorLabel.For(localidadInput, Alignment.Bottom, 2));

            nroDocumentoInput.DataBindings.Add(new TextBinding(this.Model, "NroDocumento"));
            Register(ErrorLabel.For(nroDocumentoInput, Alignment.Bottom, 2));

            cboPaisDir.DisplayMember = "Nombre";
            cboPaisDir.ValueMember = "idPais";
            cboPaisDir.DataSource = paises;
            //cboPaisDir.DataBindings.Add(new Binding("SelectedValue", this.Model, "IdPais"));
            
            cboRol.DisplayMember = "Nombre";
            cboRol.ValueMember = "idPais";
            cboRol.DataSource = roles;
            //cboRol.DataBindings.Add(new Binding("SelectedValue", this.Model, "IdRol"));


            cboTipoDoc.DisplayMember = "detalle";
            cboTipoDoc.ValueMember = "idTipoDocumento";
            cboTipoDoc.DataSource = tiposDocumento;
            //cboTipoDoc.DataBindings.Add(new Binding("SelectedValue", this.Model, "IdTipoDocumento"));

            cboHotel.DisplayMember = "Nombre";
            cboHotel.ValueMember = "idHotel";
            cboHotel.DataSource = hoteles;
            //cboHotel.DataBindings.Add(new Binding("SelectedValue", this.Model, "IdHotel"));

            fechaNacInput.DataBindings.Add(new TextBinding(this.Model, "FechaNac"));
            Register(ErrorLabel.For(fechaNacInput, Alignment.Bottom, 2));

            if((this.Model as Usuario).Activo == 'S') {
                activoCheck.Checked = true;
                }
                else {
                    activoCheck.Checked = false;
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            result = DialogResult.None;

            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (!this.ValidateChildren()) return;

            var usuario = (Usuario)this.Model;
            if(activoCheck.Checked){
                usuario.Activo = 'S';
            } else {
                usuario.Activo = 'N';
            }

            accion(usuario);

            result = DialogResult.OK;
            this.Close();
        }

        private void Crear(Usuario usuario)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.UsuarioCrear", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idAdmin", SqlDbType.Int).Value = LoginData.IdUsuario;
                    cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = usuario.Username;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = usuario.Password;
                    cmd.Parameters.AddWithValue("@idRol", SqlDbType.Int).Value = usuario.IdRol;
                    cmd.Parameters.AddWithValue("@idHotel", SqlDbType.Int).Value = usuario.IdHotel;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.AddWithValue("@Apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.VarChar).Value = usuario.Mail;
                    cmd.Parameters.AddWithValue("@idTipoDocumento", SqlDbType.VarChar).Value = usuario.IdTipoDocumento;
                    cmd.Parameters.AddWithValue("@NroDocumento", SqlDbType.Int).Value = usuario.NroDocumento;
                    cmd.Parameters.AddWithValue("@dirIdPais", SqlDbType.Int).Value = usuario.IdPais;
                    cmd.Parameters.AddWithValue("@dirCalle", SqlDbType.VarChar).Value = usuario.Calle;
                    cmd.Parameters.AddWithValue("@dirNrocalle", SqlDbType.Int).Value = usuario.NroCalle;
                    cmd.Parameters.AddWithValue("@FechaDeNacimiento", SqlDbType.DateTime).Value = usuario.FechaNac;
                    cmd.Parameters.AddWithValue("@dirDepto", SqlDbType.VarChar).Value = usuario.Depto;
                    cmd.Parameters.AddWithValue("@dirPiso", SqlDbType.VarChar).Value = usuario.Piso;
                    cmd.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = usuario.Localidad;
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                    cmd.Parameters.AddWithValue("@Activo", SqlDbType.Char).Value = usuario.Activo;


                    con.Open();
                    var dr = cmd.ExecuteReader();

                    //TODO con ese reader hay que almacenar el ID
                }
            }
        }

        private void Modificar(Usuario usuario)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.UsuarioUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idAdmin", SqlDbType.Int).Value = LoginData.IdUsuario;
                    cmd.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = usuario.IdUsuario;
                    cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = usuario.Username;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = usuario.Password;
                    cmd.Parameters.AddWithValue("@idRol", SqlDbType.Int).Value = usuario.IdRol;
                    cmd.Parameters.AddWithValue("@idHotel", SqlDbType.Int).Value = usuario.IdHotel;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.AddWithValue("@Apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.VarChar).Value = usuario.Mail;
                    cmd.Parameters.AddWithValue("@idTipoDocumento", SqlDbType.VarChar).Value = usuario.IdTipoDocumento;
                    cmd.Parameters.AddWithValue("@NroDocumento", SqlDbType.Int).Value = usuario.NroDocumento;
                    cmd.Parameters.AddWithValue("@dirIdPais", SqlDbType.Int).Value = usuario.IdPais;
                    cmd.Parameters.AddWithValue("@dirCalle", SqlDbType.VarChar).Value = usuario.Calle;
                    cmd.Parameters.AddWithValue("@dirNrocalle", SqlDbType.Int).Value = usuario.NroCalle;
                    cmd.Parameters.AddWithValue("@FechaDeNacimiento", SqlDbType.DateTime).Value = usuario.FechaNac;
                    cmd.Parameters.AddWithValue("@dirDepto", SqlDbType.VarChar).Value = usuario.Depto;
                    cmd.Parameters.AddWithValue("@dirPiso", SqlDbType.VarChar).Value = usuario.Piso;
                    cmd.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = usuario.Localidad;
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                    cmd.Parameters.AddWithValue("@Activo", SqlDbType.Char).Value = usuario.Activo;


                    con.Open();
                    var dr = cmd.ExecuteReader();

                    //TODO con ese reader hay que almacenar el ID
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);

            this.activoCheck.Checked = true;
        }
    }
}
