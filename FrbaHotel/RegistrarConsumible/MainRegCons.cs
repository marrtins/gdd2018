using FrbaHotel.AbmHabitacion.Model;
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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class MainRegCons : Form
    {

        int idHotel = 1; //CAMBIARRRRRRRRRR
        List<Consumible> consumibles = new List<Consumible>();
        List<Habitacion> habitaciones = new List<Habitacion>();
        public MainRegCons()        
        {
            InitializeComponent();
            cboHabitaciones.Text = "Seleccionar";
            cboConsumibles.Text = "Seleccionar";
            cargarHabitaciones();
            cargarConsumibles();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainRegCons_Load(object sender, EventArgs e)
        {

        }
        private void cargarConsumibles()
        {
            string consultaBusqueda = String.Format("select distinct * from mmel.Consumible ");
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int idConsumible = Int32.Parse(reader["idConsumible"].ToString());
                int costo = Int32.Parse(reader["Costo"].ToString());
                string nombre = (reader["Nombre"].ToString());
                int codigoConsumible = Int32.Parse(reader["CodigoConsumible"].ToString());
                cboConsumibles.Items.Add(nombre);
                Consumible c = new Consumible();
                c.IdConsumible = idConsumible;
                c.Costo = costo;
                c.Nombre = nombre;
                c.CodigoConsumible = codigoConsumible;
                string aux = String.Format(nombre + " (${0})", costo);
                consumibles.Add(c);

            }
            reader.Close();
            con.Close();
            
        }
        private void cargarHabitaciones()
        {
            string consultaBusqueda = String.Format("select * from mmel.Habitacion where idHotel={0}",idHotel);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int idHabitacion = Int32.Parse(reader["idHabitacion"].ToString());
                int NumeroHabitacion = Int32.Parse(reader["NumeroHabitacion"].ToString());
                cboHabitaciones.Items.Add(NumeroHabitacion);
                Habitacion h = new Habitacion();
                h.IdHabitacion = idHabitacion;
                h.NumeroHabitacion = NumeroHabitacion;
                habitaciones.Add(h);

            }
            reader.Close();
            con.Close();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (datosValidos())
            {

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.agregarConsumibles", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idHabitacion", SqlDbType.Int).Value = getIdHab();
                cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
                cmd.Parameters.Add("@idConsumible", SqlDbType.Int).Value = getIdConsumible();
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Int32.Parse(textBox1.Text);
                cmd.Parameters.Add("@fechaCheckOut", SqlDbType.Date).Value = DateTime.Today; ///ARREGLARRR
                cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->no existe la habitacion en esta fecha ; 1 -> ok

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
                if (codigoRet == 0)
                {
                    MessageBox.Show("Ninguna habitacion ha sido cerrada el dia de hoy.", "X", MessageBoxButtons.OK);
                }
                else if (codigoRet == 1)
                {
                    MessageBox.Show("Consumible/s agregado/s", "OK", MessageBoxButtons.OK);

                }
            }
        }
        private bool datosValidos()
        {
            int i;
            if (cboConsumibles.Text == "Seleccionar")
            {
                MessageBox.Show("Seleccionar consumible", "X", MessageBoxButtons.OK);
                return false;
            }
            if (cboHabitaciones.Text == "Seleccionar")
            {
                MessageBox.Show("Seleccionar Habitacion", "X", MessageBoxButtons.OK);
                return false;
            }
            if(textBox1.Text=="" || !int.TryParse(textBox1.Text, out i))
            {
                MessageBox.Show("Seleccionar Cantidad", "X", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private int getIdHab()
        {
            return habitaciones[cboHabitaciones.SelectedIndex].IdHabitacion;    
        }
        private int getIdConsumible()
        {
            return consumibles[cboConsumibles.SelectedIndex].IdConsumible;
        }

        private void btnOtroConsumible_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
