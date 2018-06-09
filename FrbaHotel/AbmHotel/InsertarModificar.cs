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

            RegistrarInputs();

            accion = Insertar;
        }

        public InsertarModificar(int idUsuario, Hotel hotel)
            :base(hotel)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.paises = Paises.GetAll();

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

            (this.Model as Hotel).CantidadEstrellas = 1; //si fuera cero romperia
            cantidadEstrellasInput.DataBindings.Add(new Binding("Value", this.Model, "CantidadEstrellas"));

            paisCombo.DataSource = paises;
            (this.Model as Hotel).IdPais = 1;
            paisCombo.DataBindings.Add(new Binding("Value", this.Model, "IdPais"));
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
                    cmd.Parameters.AddWithValue("@idPais", SqlDbType.Int).Value = 1;
                    cmd.Parameters.AddWithValue("@ciudad", SqlDbType.VarChar).Value = hotel.Ciudad;
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = hotel.Telefono;
                    cmd.Parameters.AddWithValue("@CantidadEstrellas", SqlDbType.Int).Value = hotel.CantidadEstrellas;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = hotel.Nombre;
                    cmd.Parameters.AddWithValue("@idAdmin", SqlDbType.Int).Value = 2;

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
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelModificar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.VarChar).Value = hotel.Mail;
                    cmd.Parameters.AddWithValue("@idDireccion", SqlDbType.Int).Value = hotel.IdDireccion;
                    cmd.Parameters.AddWithValue("@calle", SqlDbType.VarChar).Value = hotel.Calle;
                    cmd.Parameters.AddWithValue("@nrocalle", SqlDbType.Int).Value = hotel.NroCalle;
                    cmd.Parameters.AddWithValue("@idPais", SqlDbType.Int).Value = 1;
                    cmd.Parameters.AddWithValue("@ciudad", SqlDbType.VarChar).Value = hotel.Ciudad;
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = hotel.Telefono;
                    cmd.Parameters.AddWithValue("@CantidadEstrellas", SqlDbType.Int).Value = hotel.CantidadEstrellas;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = hotel.Nombre;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    //TODO con ese reader hay que almacenar el ID
                }
            }
        }
    }
}
