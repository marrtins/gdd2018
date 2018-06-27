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
                    var tipoHab = (tipoHabInput.Text.Trim() == "")?"null":tipoHabInput.Text;
                    var numHab = (numHabInput.Text.Trim() == "") ? "null" : numHabInput.Text;
                    var hotel = (hotelInput.Text.Trim() == "") ? "null" : hotelInput.Text;
                    var piso = (pisoInput.Text.Trim() == "") ? "null" : pisoInput.Text;
                    var vista = (vistaExtInput.Text.Trim() == "") ? "null" : vistaExtInput.Text;
                   
                    var query = String.Format("exec [MMEL].[HabitacionesListar] {0} , {1} , {2} , {3} ,  {4}  ", tipoHab, numHab, hotel, piso, vista);
                    MessageBox.Show("Ejecutando query:" +query);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                   this.dataGridView1.DataSource = table;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            int numeroHabitacion = Int32.Parse(row.Cells["Numero Habitacion"].Value.ToString());
           int piso  = Int32.Parse(row.Cells["Piso"].Value.ToString());
            int hotel = Int32.Parse(row.Cells["Hotel"].Value.ToString());
            string vista = row.Cells["Vista al Exterior"].Value.ToString();
            int  tipo = Int32.Parse(row.Cells["Tipo"].Value.ToString());
            string descripcion = row.Cells["Descripcion"].Value.ToString();
            string habilitado = row.Cells["Habilitado"].Value.ToString();

            ModificarHabitacion mod = new ModificarHabitacion(numeroHabitacion,piso,hotel,vista,tipo,descripcion,habilitado);
            this.Hide();
            mod.ShowDialog();

            this.Show();

            if (mod.Result == DialogResult.OK)
                RefreshData();
        }
    }
}
