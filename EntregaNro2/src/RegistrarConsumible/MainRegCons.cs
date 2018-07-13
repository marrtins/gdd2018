using FrbaHotel.AbmHabitacion.Model;
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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class MainRegCons : Form
    {

        int idEstadia=-1;
        List<Consumible> consumibles = new List<Consumible>();
        List<Habitacion> habitaciones = new List<Habitacion>();
        public MainRegCons(int codRes)        
        {
            InitializeComponent();
            cboHabitaciones.Text = "Seleccionar";
            cboConsumibles.Text = "Seleccionar";
            if (codRes != 0)
            {
                txtCodRes.Text = String.Format("{0}", codRes);
            }

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
    

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (datosValidos())
            {

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.agregarConsumibles", con);

                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@idHabitacion", SqlDbType.Int).Value = getIdHab();
                cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = LoginData.Hotel.IdHotel;
                cmd.Parameters.Add("@codigoReserva", SqlDbType.VarChar,50).Value = txtCodRes.Text;
                cmd.Parameters.Add("@idConsumible", SqlDbType.Int).Value = getIdConsumible();
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Int32.Parse(textBox1.Text);
                cmd.Parameters.Add("@fechaCheckOut", SqlDbType.Date).Value = DateTime.Today; ///ARREGLARRR
                cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->no existe la habitacion en esta fecha ; 1 -> ok
                cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
                
                idEstadia = int.Parse(cmd.Parameters["@idEstadia"].Value.ToString());

                if (codigoRet == 2)
                {
                    MessageBox.Show("No se puede agregar un consumible a una reserva de otro hotel", "X", MessageBoxButtons.OK);
                    return;
                }


                if (idEstadia == 0)
                {
                    MessageBox.Show("No se puede agregar un consumible a una reserva sin check-out realizado" ,"X", MessageBoxButtons.OK);
                    return;
                }

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
            if (txtCodRes.Text == "")
            {
                MessageBox.Show("Seleccionar Coigo Reserva", "X", MessageBoxButtons.OK);
                return false;
            }
            if(textBox1.Text=="" || !int.TryParse(textBox1.Text, out i))
            {
                MessageBox.Show("Seleccionar Cantidad", "X", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        
        
        private int getIdConsumible()
        {
            return consumibles[cboConsumibles.SelectedIndex].IdConsumible;
        }
       

        private void btnOtroConsumible_Click(object sender, EventArgs e)
        {
            int cod;
            int i;
            if (txtCodRes.Text == "" || !int.TryParse(txtCodRes.Text, out i))
                cod = 0;
            else
                cod = int.Parse(txtCodRes.Text);
                NuevoConsumible nc = new NuevoConsumible(this,cod);
            nc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            if (txtCodRes.Text=="" || !int.TryParse(txtCodRes.Text, out i))
            {
                MessageBox.Show("Seleccionar codigo de reserva valido", "X", MessageBoxButtons.OK);
                return;
            }
            if (idEstadia == -1 || idEstadia==0)
            {
                idEstadia = getEstadia();
                if (idEstadia == -1)
                {
                    MessageBox.Show("Seleccionar codigo de reserva valido", "X", MessageBoxButtons.OK);
                    return;
                }
            }
            if (idEstadia == -2)
            {
                return;
            }
            VerConsumibles vc = new VerConsumibles(idEstadia,this,int.Parse(txtCodRes.Text));
            vc.Show();
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
        private int getEstadia()
        {
            string consultaBusqueda = String.Format("select idEstadia,EstadoReserva, r.idHotel from mmel.Estadia e,mmel.Reserva r where r.idReserva=e.idReserva and r.CodigoReserva={0} and EstadoReserva ='RF' ",txtCodRes.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            int idEstadia = -1;
            int idHotel=0;
            string estadoReserva = "";
            while (reader.Read())
            {
                idEstadia = Int32.Parse(reader["idEstadia"].ToString());
                estadoReserva = (reader["estadoReserva"].ToString());
                idHotel = Int32.Parse(reader["idHotel"].ToString());
            }
            reader.Close();
            con.Close();
            /*if (estadoReserva != "RF")
            {
                MessageBox.Show("Solo puede registrar/facturar una estaia con el check out realizado", "X", MessageBoxButtons.OK);
                idEstadia = -2;
            }*/

            if(idHotel!= LoginData.Hotel.IdHotel)
            {
                MessageBox.Show("No se puede facturar una estadía de otro hotel", "X", MessageBoxButtons.OK);
                idEstadia = -2;
            }

            return idEstadia;
        }
    }
}
