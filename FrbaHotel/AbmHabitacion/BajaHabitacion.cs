using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rubberduck.Winforms;
using FrbaHotel.AbmHabitacion.Model;
using System.Data.SqlClient;
using FrbaHotel.Utilities;
using FrbaHotel.AbmHotel.Model;
using System.Configuration;

namespace FrbaHotel.AbmHabitacion
{
    public partial class BajaHabitacion : Form
    {
        public BajaHabitacion()
        {
            InitializeComponent();
            cargarHoteles();
        }
        private void cargarHoteles()
        {

            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;
            
            string consultaBusqueda = String.Format("select distinct * from mmel.Hotel ");

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string tipo = (reader["Nombre"].ToString());
                hotelInput.Items.Add(tipo);
            }
            reader.Close();
            con.Close();

        }
        private DialogResult result;

        public DialogResult Result { get { return result; } set { result = value; } }
        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);

        }

        private void borrarBtn_Click(object sender, EventArgs e)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HabitacionesBaja", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdHabitacion", SqlDbType.Int).Value = habitacionInput.Text;
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.Char).Value = descripcionInput.Text;
             
                    cmd.Parameters.Add("@MESSAGE", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr != null)
                    {
                        int MENSAJE = Convert.ToInt32(cmd.Parameters["@MESSAGE"].Value);
                        if(MENSAJE == 0)
                        {
                            MessageBox.Show("La habitacion no se puede dar de baja porque tiene reserva");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("La habitacion se dio de baja con exito");
                            this.Hide();
                        }
                    }
                    else {
                        this.Hide();
                }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            
        }
    }
}
