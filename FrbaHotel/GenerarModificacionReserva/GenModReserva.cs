using FrbaHotel.AbmHotel.Model;
using FrbaHotel.Utilities;
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
    public partial class GenModReserva : Form
    {
        

        public GenModReserva()

        {
            
            InitializeComponent();
            if (LoginData.IdUsuario == 1) { 
            //if user=guest. pongo cbo d hoteles. sino{ 
            //label1.Text="Realizar/Modificar Reserva para el hotel {0}" y cboHoteles.visible=false
                cboHoteles.Text = "Seleccionar";
                cargarHoteles();
            }
            else
            {
                cboHoteles.Visible = false;
                label1.Text = String.Format("Hotel: {0}",LoginData.Hotel.Nombre.ToUpper());
                cboHoteles.Text = "not";
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cargarHoteles()
        {


            
            string consultaBusqueda = String.Format("select distinct * from mmel.Hotel ");
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
                string tipo = (reader["nombre"].ToString());//cambiar
                cboHoteles.Items.Add(tipo);

            }
            reader.Close();
            con.Close();
            



        }

        private void button2_Click(object sender, EventArgs e)
        {

                CodigoReserva mr = new CodigoReserva();
                mr.Show();
                this.Hide();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboHoteles.Text == "Seleccionar")
            {
                MessageBox.Show("Debe seleccionar un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int idHotel;
                string nombreHotel;
                if (cboHoteles.Text != "not")
                {
                    idHotel = cboHoteles.SelectedIndex+1;
                    nombreHotel = cboHoteles.Text;
                }                  
                else
                {
                    idHotel = LoginData.Hotel.IdHotel;
                    nombreHotel = LoginData.Hotel.Nombre;
                }
                    
                
                GenerarReserva gr = new GenerarReserva(idHotel,nombreHotel);
                gr.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
