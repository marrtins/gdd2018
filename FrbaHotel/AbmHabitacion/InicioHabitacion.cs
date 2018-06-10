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

            RegistrarInputs();
        }

        private void RegistrarInputs()
        {
            tipoHabInput.DataBindings.Add(new TextBinding(this.Model, "IdTipoHabitacion"));
            numHabInput.DataBindings.Add(new TextBinding(this.Model, "NumeroHabitacion"));
            hotelInput.DataBindings.Add(new TextBinding(this.Model, "IdHotel"));
            pisoInput.DataBindings.Add(new TextBinding(this.Model, "Piso"));
            vistaExtInput.DataBindings.Add(new TextBinding(this.Model, "VistaAlExterior"));
            habilitadoInput.DataBindings.Add(new TextBinding(this.Model, "Habilitado"));

        }
        private void RefreshData()
        {
            var filtros = (Habitacion)this.Model;
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", SqlDbType.Int).Value = filtros.IdTipoHabitacion;
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", SqlDbType.Int).Value = filtros.NumeroHabitacion;
                    cmd.Parameters.AddWithValue("@IdHotel", SqlDbType.Int).Value = filtros.IdHotel; // filtros.Pais != null ? filtros.Pais.Nombre : Convert.DBNull;
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = filtros.Piso;
                    cmd.Parameters.AddWithValue("@VistaAlExterior", SqlDbType.Char).Value = filtros.VistaAlExterior;
                    cmd.Parameters.AddWithValue("@Habilitado", SqlDbType.Char).Value = filtros.Habilitado;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaHoteles = dr.MapToList<Habitacion>();

                    habitaciones.Clear();

                    if (listaHoteles != null)
                        listaHoteles.ForEach(lh => habitaciones.Add(lh)); // lo hago asi para que no se pierda el binding
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        
           RefreshData();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaHabitacion alta = new AltaHabitacion();
            this.Hide();

            ins.ShowDialog();

            this.Show();

            if (ins.Result == DialogResult.OK)
                RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
