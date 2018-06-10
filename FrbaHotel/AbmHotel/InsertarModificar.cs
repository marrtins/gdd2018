using FrbaHotel.AbmHotel.Model;
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

namespace FrbaHotel.AbmHotel
{
    public partial class InsertarModificar : ModelBoundForm
    {
        private int idUsuario;
        private DialogResult result;   
        private Action<Hotel> accion;
        private List<Pais> paises;

        public DialogResult Result { get => result; set => result = value; }

        public InsertarModificar(int idUsuario)
            : base(new Hotel())
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.paises = Paises.GetAll();
            this.Text = "Insertar";

            CargarDefaults(this.Model as Hotel);

            RegistrarInputs();

            accion = Insertar;
        }

        private void CargarDefaults(Hotel hotel) //normalmente esto iria en el constructor, pero puede traer problemas con otras cosas
        {
            hotel.CantidadEstrellas = 1; //si fuera cero romperia
            hotel.Inhabilitado = false; //por defecto esta habilitado;
            hotel.IdPais = 1;
        }

        public InsertarModificar(int idUsuario, Hotel hotel)
            :base(hotel)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.paises = Paises.GetAll();
            this.Text = "Modificar";

            RegistrarInputs();

            accion = Modificar;
        }

        private void RegistrarInputs()
        {
            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));
            Register(ErrorLabel.For(nombreInput, Alignment.Bottom, 2));

            telefonoInput.DataBindings.Add(new TextBinding(this.Model, "Telefono"));
            Register(ErrorLabel.For(telefonoInput, Alignment.Bottom, 2));

            mailInput.DataBindings.Add(new TextBinding(this.Model, "Mail"));
            Register(ErrorLabel.For(mailInput, Alignment.Bottom, 2));

            ciudadInput.DataBindings.Add(new TextBinding(this.Model, "Ciudad"));
            Register(ErrorLabel.For(ciudadInput, Alignment.Bottom, 2));

            calleInput.DataBindings.Add(new TextBinding(this.Model, "Calle"));
            Register(ErrorLabel.For(calleInput, Alignment.Bottom, 2));

            nroInput.DataBindings.Add(new TextBinding(this.Model, "NroCalle"));
            Register(ErrorLabel.For(nroInput, Alignment.Bottom, 2));

            cantidadEstrellasInput.DataBindings.Add(new Binding("Value", this.Model, "CantidadEstrellas"));

            paisCombo.DataSource = paises;
            paisCombo.DataBindings.Add(new Binding("SelectedValue", this.Model, "IdPais"));

            habilitadoCheck.Checked = !(this.Model as Hotel).Inhabilitado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = DialogResult.None;

            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            var hotel = (Hotel)this.Model;
            hotel.Inhabilitado = !habilitadoCheck.Checked;

            accion(hotel);

            result = DialogResult.OK;
            this.Close();
        }

        private void Insertar(Hotel hotel)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelCrear", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.VarChar).Value = hotel.Mail;
                    cmd.Parameters.AddWithValue("@calle", SqlDbType.VarChar).Value = hotel.Calle;
                    cmd.Parameters.AddWithValue("@nrocalle", SqlDbType.Int).Value = hotel.NroCalle;
                    cmd.Parameters.AddWithValue("@idPais", SqlDbType.Int).Value = hotel.IdPais;
                    cmd.Parameters.AddWithValue("@ciudad", SqlDbType.VarChar).Value = hotel.Ciudad;
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = hotel.Telefono;
                    cmd.Parameters.AddWithValue("@CantidadEstrellas", SqlDbType.Int).Value = hotel.CantidadEstrellas;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = hotel.Nombre;
                    cmd.Parameters.AddWithValue("@idAdmin", SqlDbType.Int).Value = LoginData.IdUsuario;
                    cmd.Parameters.AddWithValue("@Inhabilitado", SqlDbType.VarChar).Value = hotel.Inhabilitado;


                    con.Open();
                    var dr = cmd.ExecuteReader();

                    //TODO con ese reader hay que almacenar el ID
                }
            }
        }

        private void Modificar(Hotel hotel)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idHotel", SqlDbType.Int).Value = hotel.IdHotel;
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.VarChar).Value = hotel.Mail;
                    cmd.Parameters.AddWithValue("@idDireccion", SqlDbType.Int).Value = hotel.IdDireccion;
                    cmd.Parameters.AddWithValue("@calle", SqlDbType.VarChar).Value = hotel.Calle;
                    cmd.Parameters.AddWithValue("@nrocalle", SqlDbType.Int).Value = hotel.NroCalle;
                    cmd.Parameters.AddWithValue("@idPais", SqlDbType.Int).Value = hotel.IdPais;
                    cmd.Parameters.AddWithValue("@ciudad", SqlDbType.VarChar).Value = hotel.Ciudad;
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = hotel.Telefono;
                    cmd.Parameters.AddWithValue("@CantidadEstrellas", SqlDbType.Int).Value = hotel.CantidadEstrellas;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = hotel.Nombre;
                    cmd.Parameters.AddWithValue("@Inhabilitado", SqlDbType.VarChar).Value = hotel.Inhabilitado;


                    con.Open();
                    var dr = cmd.ExecuteReader();

                    //TODO con ese reader hay que almacenar el ID
                }
            }
        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);

            this.habilitadoCheck.Checked = true;
        }
    }
}
