using FrbaHotel.AbmHabitacion.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class GenerarReserva : Form
    {
        //List<Regimen> listaRegimenes = new List<Regimen>();
        List<TipoHabitacion> tipoHabitaciones = new List<TipoHabitacion>();
        private int idHotel;
        public GenerarReserva(int idHotel)
        {
            this.idHotel = idHotel;
            InitializeComponent();
            
           
            cboRegimen.Text = "Seleccionar";
            cargarRegimenes();
            
            dgPrecios.Visible = false;
            btnReservar.Enabled = false;
            cboHotel.Text = "1";
            this.idHotel = idHotel;
            txtC1.Text = "0";
            txtC2.Text = "0";
            txtC3.Text = "0";
            txtC4.Text = "0";
            txtC5.Text = "0";




        }
        public GenerarReserva()
        {
            
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
       

        private bool validarCampos()
        {
            int i;
            if (cboHotel.Text == "Seleccionar")
            {
                MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

            int result = DateTime.Compare(dtDesde.Value, dtHasta.Value);
            int result2= DateTime.Compare(value,dtDesde.Value);

            if (result>=0 )
            {
                MessageBox.Show("Seleccione fechas validas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(result2>0)
            {
                MessageBox.Show("Seleccione fechas validas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

           /* if(cboTipo.Text=="Seleccionar" || txtC1.Text=="0" || !int.TryParse(txtC1.Text, out i))
            {
                MessageBox.Show("Seleccione el primer campo de tipo habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/
            if(!int.TryParse(txtC1.Text, out i) || !int.TryParse(txtC2.Text, out i) || !int.TryParse(txtC3.Text, out i) || !int.TryParse(txtC4.Text, out i) || !int.TryParse(txtC5.Text, out i))
            {
                MessageBox.Show("Ingrese cantidad valida de habitaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!validarCampos())
            {
                return;
            }

            else
            {

                if (txtC1.Text != "0" )
                {
                    if (!haydispo("BASE SIMPLE", Int32.Parse(txtC1.Text))){
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC2.Text != "0" )
                {
                    if (!haydispo("BASE DOBLE", Int32.Parse(txtC2.Text))){
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC3.Text != "0" )
                {
                    if (!haydispo("BASE TRIPLE", Int32.Parse(txtC3.Text))){
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC4.Text != "0" )
                {
                    if (!haydispo("BASE CUADRUPLE", Int32.Parse(txtC2.Text))){
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC5.Text != "0")
                {
                    if (!haydispo("KING", Int32.Parse(txtC2.Text)))
                    {
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("Hay disponibilidad para las fechas indicadas.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgPrecios.Visible = true;
                llenarDataGridDePrecios();
                dtDesde.Enabled = false;
                dtHasta.Enabled = false;
                cboHotel.Enabled = false;
                cboRegimen.Enabled = true;
                
                button1.Enabled = false;
                btnReservar.Enabled = true;
                
                txtC1.Enabled = false;
                txtC2.Enabled = false;
                txtC3.Enabled = false;
                txtC4.Enabled = false;
                txtC5.Enabled = false;
            }



        }

        private bool haydispo(string tipoHabDesc,int cant)
        {


            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.hayDisponibilidad", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = dtDesde.Value;
            cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = dtHasta.Value;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = cboHotel.Text;
            cmd.Parameters.Add("@tipoHabDesc", SqlDbType.VarChar, 150).Value = tipoHabDesc;


            cmd.Parameters.Add("@rta", SqlDbType.Int).Direction = ParameterDirection.Output; //1->hay dispo. 0>no hay dispo

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int codigoRet = int.Parse(cmd.Parameters["@rta"].Value.ToString());

            if (codigoRet == 0 || codigoRet<cant)
            {
                return false;
                //MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                /*MessageBox.Show("Hay disponibilidad para las fechas indicadas.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgPrecios.Visible = true;
                llenarDataGridDePrecios();
                dtDesde.Enabled = false;
                dtHasta.Enabled = false;
                cboHotel.Enabled = false;
                cboRegimen.Enabled = false;
                cboTipo.Enabled = false;
                button1.Enabled = false;
                btnReservar.Enabled = true;*/
                return true;



            }



            
        }

        private void llenarDataGridDePrecios()
        {


            int cantPersonas = getCantPersonas();

            string consultaBusqueda = String.Format("select (r.precio * {0} + ho.RecargaEstrellas * ho.CantidadEstrellas) \"Precio por Noche\", Descripcion \"Tipo de Regimen\" from mmel.Regimen r, mmel.hotel ho where ho.idHotel={1}", cantPersonas,idHotel);
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
        private int getTipoCant(ComboBox cbo)
        {
            if (cbo.Text == "Base Simple") return 1;
            if (cbo.Text == "Base Doble") return 2;
            if (cbo.Text == "Base Triple") return 3;
            if (cbo.Text == "Base Cuadruple") return 4;
            if (cbo.Text == "King") return 5;
            return 0;
        }
        private int getCantPersonas()
        {

            int cant = 0;
            
                cant += 1* Int32.Parse(txtC1.Text);
            
                cant += 2 * Int32.Parse(txtC2.Text);
            
                cant += 3 * Int32.Parse(txtC3.Text);
            
                cant += 4 * Int32.Parse(txtC4.Text);
            cant += 5 * Int32.Parse(txtC4.Text);


            return cant;
            

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
            
            List<TipoCant> tcs = new List<TipoCant>();

            if ( Int32.Parse(txtC1.Text) > 0)
            {
                TipoCant tc = new TipoCant();
                tc.cant = Int32.Parse(txtC1.Text);
                tc.desc = "BASE SIMPLE";
                tcs.Add(tc);
            }
            if ( Int32.Parse(txtC2.Text) > 0)
            {
                TipoCant tc = new TipoCant();
                tc.cant = Int32.Parse(txtC2.Text);
                tc.desc = "BASE DOBLE";
                tcs.Add(tc);
            }
            if ( Int32.Parse(txtC3.Text) > 0)
            {
                TipoCant tc = new TipoCant();
                tc.cant = Int32.Parse(txtC3.Text);
                tc.desc = "BASE TRIPLE";
                tcs.Add(tc);
            }
            if ( Int32.Parse(txtC4.Text) > 0)
            {
                TipoCant tc = new TipoCant();
                tc.cant = Int32.Parse(txtC4.Text);
                tc.desc = "BASE CUADRUPLE";
                tcs.Add(tc);
            }
            if (Int32.Parse(txtC5.Text) > 0)
            {
                TipoCant tc = new TipoCant();
                tc.cant = Int32.Parse(txtC4.Text);
                tc.desc = "KING";
                tcs.Add(tc);
            }



            ConfirmarReserva cr = new ConfirmarReserva(idHotel,dtDesde.Value,dtHasta.Value,cboHotel.Text,cboRegimen.Text,precio,tcs);
            cr.Show();
            this.Hide();
              

        }
        private float getPrecio()
        {
            string consultaBusqueda = String.Format("select (r.precio * {0} + ho.RecargaEstrellas * ho.CantidadEstrellas) \"Precio por Noche\", Descripcion \"Tipo de Regimen\" from mmel.Regimen r, mmel.hotel ho where ho.idHotel={1} and r.descripcion='{2}'", getCantPersonas(), idHotel,cboRegimen.Text);
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
