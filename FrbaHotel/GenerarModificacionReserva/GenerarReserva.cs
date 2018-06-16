using FrbaHotel.AbmHabitacion.Model;
using FrbaHotel.AbmRegimen;
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
    public partial class GenerarReserva : Form
    {
        List<Regimen> listaRegimenes = new List<Regimen>();
        List<TipoHabitacion> tipoHabitaciones = new List<TipoHabitacion>();
        private int idHotel;
        public GenerarReserva(int idHotel)
        {
            this.idHotel = idHotel;
            InitializeComponent();
            cboRegimen.Items.Add("Seleccionar");
            cboRegimen.Text = "Seleccionar";
            cboTipo.Text = "Seleccionar";
            cargarRegimenes();
            cargarTipoHabitaciones();
            dgPrecios.Visible = false;
            btnReservar.Enabled = false;
            cboHotel.Text = "1";





        }
        public GenerarReserva()
        {
            InitializeComponent();
            cboRegimen.Items.Add("Seleccionar");
            cboRegimen.Text = "Seleccionar";
            cboTipo.Text = "Seleccionar";
            cargarRegimenes();
            cargarTipoHabitaciones();
            dgPrecios.Visible = false;
            btnReservar.Enabled = false;
            this.idHotel = idHotel;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {

        }

        private void cargarRegimenes()
        {
            

            string consultaBusqueda = String.Format("select distinct * from mmel.Regimen ");
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
                int idR= Int32.Parse(reader["idRegimen"].ToString());
                //float precio = (reader["Precio"].ToString());
                char habilitado = (reader["Habilitado"].ToString()[0]);
                string descr = (reader["Descripcion"].ToString());
                
                //Regimen r = new Regimen(idR,precio,habilitado,descr);
                //listaRegimenes.Add(r);
                cboRegimen.Items.Add(descr);
                
            }
            reader.Close();
            con.Close();


            
        }
        private void cargarTipoHabitaciones()
        {

            
            string consultaBusqueda = String.Format("select distinct * from mmel.TipoHabitacion ");
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
                TipoHabitacion th = new TipoHabitacion();
                int idTH = Int32.Parse(reader["idTipoHabitacion"].ToString());
              
                string descr = (reader["Descripcion"].ToString());
                cboTipo.Items.Add(descr);

            }
            reader.Close();
            con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuncionesCompartidas fc = new FuncionesCompartidas();
            if (cboHotel.Text == "Seleccionar"){ MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (cboTipo.Text == "Seleccionar") { MessageBox.Show("Seleccione Tipo de Habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if(dtDesde.Value >= dtHasta.Value | dtDesde.Value.Day<System.DateTime.Now.Day | dtHasta.Value < System.DateTime.Now) { MessageBox.Show("Seleccione fechas validas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            else
            {
                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.hayDisponibilidad", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = dtDesde.Value;
                cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = dtHasta.Value;
                cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = cboHotel.Text;
                cmd.Parameters.Add("@tipoHabDesc", SqlDbType.VarChar, 150).Value = cboTipo.Text;
            
                
                cmd.Parameters.Add("@rta", SqlDbType.Int).Direction = ParameterDirection.Output; //1->hay dispo. 0>no hay dispo

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                int codigoRet = int.Parse(cmd.Parameters["@rta"].Value.ToString());
                
                if (codigoRet == 0)
                {
                    MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (codigoRet == 1)
                {
                    MessageBox.Show("Hay disponibilidad para las fechas indicadas.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgPrecios.Visible = true;
                    llenarDataGridDePrecios();
                    dtDesde.Enabled = false;
                    dtHasta.Enabled = false;
                    cboHotel.Enabled = false;
                    cboTipo.Enabled = false;
                    cboRegimen.Enabled = false;
                    button1.Enabled = false;
                    btnReservar.Enabled = true;
                    


                }
                


            }



        }

        private void llenarDataGridDePrecios()
        {


            int cantPersonas = getCantPersonas();

            string consultaBusqueda = String.Format("select (r.precio * {0} + 25 * ho.CantidadEstrellas) \"Precio por Noche\", Descripcion \"Tipo de Regimen\" from mmel.Regimen r, mmel.hotel ho where ho.idHotel={1}", cantPersonas,idHotel);
            if (cboRegimen.Text != "Seleccionar") consultaBusqueda = consultaBusqueda + String.Format(" and r.Descripcion='{0}'", cboRegimen.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaBusqueda, strCo);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.dgPrecios.DataSource = dataTable;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgPrecios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int getCantPersonas()
        {
            if (cboTipo.Text == "Base Simple") return 1;
            if (cboTipo.Text == "Base Doble") return 2;
            if (cboTipo.Text == "Base Triple") return 3;
            if (cboTipo.Text == "Base Cuadruple") return 4;
            if (cboTipo.Text == "King") return 5;
            return -1;

        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (cboRegimen.Text == "Seleccionar")
            {
                MessageBox.Show("Debe seleccionar el regimen","Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            float precio;
            precio = getPrecio();
            ConfirmarReserva cr = new ConfirmarReserva(dtDesde.Value,dtHasta.Value,cboHotel.Text,cboTipo.Text,cboRegimen.Text,precio);
            cr.Show();
            this.Hide();
              

        }
        private float getPrecio()
        {
            string consultaBusqueda = String.Format("select (r.precio * {0} + 25 * ho.CantidadEstrellas) \"Precio por Noche\", Descripcion \"Tipo de Regimen\" from mmel.Regimen r, mmel.hotel ho where ho.idHotel={1} and r.descripcion='{2}'", getCantPersonas(), idHotel,cboRegimen.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            float precio=0;
            while (reader.Read())
            {
                precio = Single.Parse(reader["Precio por Noche"].ToString());
            }
            reader.Close();
            con.Close();
            return precio;
        }
    }
}
