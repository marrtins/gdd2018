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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class CodigoReserva : Form
    {
        public CodigoReserva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int i;
            if (textBox1.Text == "" || !int.TryParse(textBox1.Text, out i))
            {
                MessageBox.Show("Complete el codigo de la reserva");
                return;
            }
            string consultaBusqueda = String.Format("select * from mmel.reserva where CodigoReserva = {0} and (EstadoReserva='CO' or EstadoReserva='MO' or EstadoReserva='RINSF' or EstadoReserva='RINCF'  )", textBox1.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Reserva res = new Reserva();
                while (reader.Read())
                {
                    res.idReserva = Int32.Parse(reader["idReserva"].ToString());
                    int idU;
                    if (!int.TryParse((reader["idUsuarioQueProcesoReserva"].ToString()), out idU))
                        idU = 0;
                    res.idUsuarioQueProcesoReserva = idU;
                    res.idHotel = Int32.Parse(reader["idHotel"].ToString());
                    DateTime dt;
                    if (!DateTime.TryParse((reader["FechaDeReserva"].ToString()), out dt))
                        dt = DateTime.Parse("1/1/1900");
                    res.FechaDeReserva = dt;

                    //res.FechaDeReserva = DateTime.Parse(reader["FechaDeReserva"].ToString());

                    res.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                    res.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                    //res.idHabitacion = Int32.Parse(reader["idHabitacion"].ToString());
                    res.idRegimen = Int32.Parse(reader["idRegimen"].ToString());
                    res.idHuesped = Int32.Parse(reader["idHuesped"].ToString());
                    res.EstadoReserva = (reader["idHuesped"].ToString())[0];
                    res.CodigoReserva = Int32.Parse(reader["CodigoReserva"].ToString());
                    
                }
                reader.Close();
                con.Close();
                res=llenarHabitaciones(res);
                this.Hide();
                ModificarReserva mr = new ModificarReserva(res);
                mr.Show();
            }
            else
            {
                MessageBox.Show("Error. El codigo no existe/ya expiró");
                reader.Close();
                con.Close();
                return;
            }
            
        }
        private Reserva llenarHabitaciones(Reserva res)
        {
            int idReserva = res.idReserva;
            string consultaBusqueda = String.Format("select idReserva,idHabitacion from mmel.ReservaPorHabitacion where idReserva = {0}",idReserva);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            res.idHabitaciones = new List<int>();
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                    res.idHabitaciones.Add(Int32.Parse(reader["idHabitacion"].ToString()));
                }
                reader.Close();
                con.Close();
                
                
                
            }
            else
            {
                MessageBox.Show("Error. El codigo no existe/ya expiró");
                reader.Close();
                con.Close();
            }

            return res;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenModReserva gm = new GenModReserva();
            gm.Show();
            this.Hide();
        }
    }
}
