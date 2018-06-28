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
    public partial class AltaHabitacion : Form
    {
        private DialogResult result;

        public DialogResult Result { get { return result; } set { result = value; } }

        public AltaHabitacion()
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

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HabitacionesAlta", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", SqlDbType.Int).Value = tipoHabInput.Text;
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", SqlDbType.Int).Value = numHabInput.Text;
                    cmd.Parameters.AddWithValue("@IdHotel", SqlDbType.Char).Value = hotelInput.Text;
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = pisoInput.Text;
                    cmd.Parameters.AddWithValue("@VistaAlExterior", SqlDbType.Char).Value = vistaExtInput.Text;
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.Char).Value = descripcionInput.Text;
                    cmd.Parameters.Add("@MESSAGE", SqlDbType.Int).Direction = ParameterDirection.Output;
                    if (habilitadoInput.Checked)
                    {
                        cmd.Parameters.Add("@Habilitado", SqlDbType.Char, 1).Value = 'S';
                    }
                    else
                    {
                        cmd.Parameters.Add("@Habilitado", SqlDbType.Char, 1).Value = 'N';

                    }
                    con.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr != null)
                    {
                        int MENSAJE = Convert.ToInt32(cmd.Parameters["@MESSAGE"].Value);
                        if (MENSAJE == 0)
                        {
                            MessageBox.Show("La habitacion no se puede dar de alta porque ya existe");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("La habitacion se dio de alta con exito");
                            this.Hide();
                        }
                    }
                    else
                    {
                        this.Hide();
                    }


                }
            }
        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);
        }
    }
}
