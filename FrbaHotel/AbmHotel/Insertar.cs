using FrbaHotel.AbmHotel.Model;
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
    public partial class Insertar : ModelBoundForm
    {
        private int idUsuario;

        public Insertar(int idUsuario)
            : base(new Hotel(0))
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            telefonoInput.DataBindings.Add(new TextBinding(this.Model, "Telefono"));
            Register(ErrorLabel.For(telefonoInput, Alignment.Bottom,2));

            mailInput.DataBindings.Add(new TextBinding(this.Model, "Mail"));
            Register(ErrorLabel.For(mailInput, Alignment.Bottom, 2));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var connection = ConfigurationManager.ConnectionStrings["GDD"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelCrear", con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Mail", txtfirstname);
                    //cmd.Parameters.AddWithValue("@idDireccion", SqlDbType.Int).Value =
                    //cmd.Parameters.AddWithValue("@Telefono", txtfirstname);
                    //cmd.Parameters.AddWithValue("@CantidadEstrellas", txtlastname);
                    //cmd.Parameters.AddWithValue("@FechaDeCreacion", DateTime.Today.ToShortDateString());
                    //cmd.Parameters.AddWithValue("@Nombre", txtlastname);
                    //cmd.Parameters.AddWithValue("@idAdmin", idUsuario);

                    //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
                    //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;

                    //con.Open();
                    //cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
