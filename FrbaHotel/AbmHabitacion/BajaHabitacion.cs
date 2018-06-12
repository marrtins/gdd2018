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
        }
        private DialogResult result;

        public DialogResult Result { get => result; set => result = value; }
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
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", SqlDbType.Int).Value = tipoHabInput.Text;
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", SqlDbType.Int).Value = numHabInput.Text;
                    cmd.Parameters.AddWithValue("@IdHotel", SqlDbType.Int).Value = hotelInput.Text;
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = pisoInput.Text;
                    cmd.Parameters.AddWithValue("@VistaAlExterior", SqlDbType.Char).Value = vistaExtInput.Text;

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



                }
            }
        }
    }
}
