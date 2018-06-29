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
        int modo = 1; //1: modificar ; 2:borrar
        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
        BindingList<Habitacion> habitaciones = new BindingList<Habitacion>();
        public InicioHabitacion()
        {
            InitializeComponent();

            
            bcol.HeaderText = "Accion";
            bcol.Text = "Modificar ";
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(bcol);
            cargarHoteles();
            button4.Visible = false;
            optModificar.Checked=true;
         
    
           
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

             var tipoHab = (tipoHabInput.Text.Trim() == "")?"null":tipoHabInput.Text;
             var numHab = (numHabInput.Text.Trim() == "") ? "null" : numHabInput.Text;
                    var hotel = (hotelInput.Text.Trim() == "") ? "null" : hotelInput.Text;
                    var piso = (pisoInput.Text.Trim() == "") ? "null" : pisoInput.Text;
                    var vista = (vistaExtInput.Text.Trim() == "") ? "null" : vistaExtInput.Text;

            var query = String.Format("exec [MMEL].[HabitacionesListar] {0} , {1} , '{2}' , {3} ,  {4}  ", tipoHab, numHab, hotel, piso, vista);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                                 
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    this.dataGridView1.DataSource = dataTable;
         
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
            int id = Int32.Parse(row.Cells["idHabitacion"].Value.ToString());
            int numeroHabitacion = Int32.Parse(row.Cells["NumeroHabitacion"].Value.ToString());
            int piso  = Int32.Parse(row.Cells["Piso"].Value.ToString());
            int idhotel = Int32.Parse(row.Cells["idHotel"].Value.ToString());
            string vista = row.Cells["VistaAlExterior"].Value.ToString();
            int  tipo = Int32.Parse(row.Cells["idTipoHabitacion"].Value.ToString());
            string descripcion = row.Cells["Descripcion"].Value.ToString();
            string habilitado = row.Cells["Habilitado"].Value.ToString();
            string hotel= getNombreHotel(idhotel);
            if (modo == 1)
            {
                ModificarHabitacion mod = new ModificarHabitacion(this,idhotel,id, numeroHabitacion, piso, hotel, vista, tipo, descripcion, habilitado);
                this.Hide();
                mod.ShowDialog();
                if (mod.Result == DialogResult.OK)
                    RefreshData();
            }
            else
            {
                if (habilitado == "S")
                {
                    bajarHabitacion(id);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("La habitacion se encuentra inhabilitada");
                }
                
            }
            this.Show();

            
        }
        private string getNombreHotel(int idHotel)
        {
            string consultaBusqueda = String.Format("select * from mmel.Hotel where idHotel = {0} ", idHotel);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            string nombre = "";
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    nombre = (reader["Nombre"].ToString());
                    return nombre;
                }
            }
            else
            {
                MessageBox.Show("Error. El codigo no existe");
                reader.Close();
                con.Close();
                return nombre;
            }
            return nombre;
        }
        private void bajarHabitacion(int id)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HabitacionesBaja", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdHabitacion", SqlDbType.Int).Value = id;
                    

                    cmd.Parameters.Add("@MESSAGE", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr != null)
                    {
                        int MENSAJE = Convert.ToInt32(cmd.Parameters["@MESSAGE"].Value);
                        if (MENSAJE == 0)
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
                    else
                    {
                        this.Hide();
                    }


                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void InicioHabitacion_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void optModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (optModificar.Checked)
            {
                bcol.Text = "Modificar";
                modo = 1;
            }
            else
            {
                bcol.Text = "Inhabilitar";
                modo = 2;
            }
        }
    }
}
