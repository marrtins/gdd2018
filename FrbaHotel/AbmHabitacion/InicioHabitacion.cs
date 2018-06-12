using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rubberduck.Winforms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.AbmHabitacion.Model;
using System.Data.SqlClient;
using FrbaHotel.Utilities;
using FrbaHotel.AbmHotel.Model;
using System.Configuration;



namespace FrbaHotel.AbmHabitacion
{
    public partial class InicioHabitacion : ModelBoundForm
    {

        BindingList<Habitacion> habitaciones = new BindingList<Habitacion>();
        public InicioHabitacion()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = habitaciones;

    
           
        }

 
        private void button2_Click(object sender, EventArgs e)
        {
            AltaHabitacion alta = new AltaHabitacion();
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
                using (SqlCommand cmd = new SqlCommand("MMEL.HabitacionesListar", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", SqlDbType.Int).Value = tipoHabInput.Text;
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", SqlDbType.Int).Value = numHabInput.Text;
                    cmd.Parameters.AddWithValue("@IdHotel", SqlDbType.Int).Value = hotelInput.Text; 
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = pisoInput.Text;
                    cmd.Parameters.AddWithValue("@VistaAlExterior", SqlDbType.Char).Value = vistaExtInput.Text;
                
                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaHabitaciones = dr.MapToList<Habitacion>();

                    habitaciones.Clear();

                    if (listaHabitaciones != null)
                        listaHabitaciones.ForEach(lh => habitaciones.Add(lh)); // lo hago asi para que no se pierda el binding
                   
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);

        }

        private void button4_Click(object sender, EventArgs e)
        {
           BajaHabitacion baja = new BajaHabitacion();
            this.Hide();

            baja.ShowDialog();

            this.Show();

            if (baja.Result == DialogResult.OK)
                RefreshData();
        }
    }
}
