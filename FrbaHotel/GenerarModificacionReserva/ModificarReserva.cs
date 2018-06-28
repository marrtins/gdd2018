using System;
using FrbaHotel.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Login.Model;
using System.Configuration;
using System.Data.SqlClient;
using FrbaHotel.AbmHabitacion.Model;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ModificarReserva : Form
    {
        private int idHotel;
        private Reserva res;
        List<TipoCant> tcs = new List<TipoCant>();



        public ModificarReserva(Reserva res)
        {
            this.res = res;
            InitializeComponent();
            btnModificar.Enabled = false;
            cargarRegimenes();
            
            llenarCampos();
            groupBox1.Visible = false;
            chkModificar.Checked = false;
        }


        private void llenarCampos()
        {
            lblHotel.Text = getNombreHotel();
            dtDesde.Value = res.FechaDesde;
            dtHasta.Value = res.FechaHasta;
            cboRegimen.SelectedIndex = res.idRegimen;
            
            txtC1.Text = "0";
            txtC2.Text = "0";
            txtC3.Text = "0";
            txtC4.Text = "0";
            txtC5.Text = "0";

            llenarHabitaciones();

        }

        private void llenarHabitaciones()
        {
            string consultaBusqueda = String.Format("select distinct ha.idTipoHabitacion,count(ha.idHabitacion) Cant from mmel.ReservaPorHabitacion rph, mmel.Habitacion ha where rph.idReserva={0} and rph.idHabitacion=ha.idHabitacion group by ha.idTipoHabitacion", res.idReserva);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            int bs = 0;
            int bd = 0;
            int bt = 0;
            int bc = 0;
            int k = 0;
            int idth;
            int cant;
            if (reader.HasRows)
            {
                Reserva res = new Reserva();
                while (reader.Read())
                {
                    idth = Int32.Parse(reader["idTipoHabitacion"].ToString());
                    cant= Int32.Parse(reader["Cant"].ToString());
                    if (idth == 1001) bs=cant;
                    if (idth == 1002) bd = cant;
                    if (idth == 1003) bt = cant;
                    if (idth == 1004) bc = cant;
                    if (idth == 1005) k = cant;
                }
                reader.Close();
                con.Close();
                lblc1.Text = String.Format("{0}",bs);
                lblc2.Text = String.Format("{0}", bd);
                lblc3.Text = String.Format("{0}", bt);
                lblc4.Text = String.Format("{0}", bc);
                lblc5.Text = String.Format("{0}", k);


            }
        }
        private string getNombreHotel()
        {

            return "asd";//todo



        }
        private void ModificarReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cboRegimen.Text == "Seleccionar")
            {
                MessageBox.Show("Debe seleccionar el regimen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            float precio;
            precio = getPrecio();

            

            if (Int32.Parse(txtC1.Text) > 0)
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
            if ( Int32.Parse(txtC5.Text) > 0)
            {
                TipoCant tc = new TipoCant();
                tc.cant = Int32.Parse(txtC5.Text);
                tc.desc = "KING";
                tcs.Add(tc);
            }




            modificarReserva();
        }
        private void modificarReserva()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.modificarReserva", con);
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = dtDesde.Value;
            cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = dtHasta.Value;
            cmd.Parameters.Add("@fechaDeReserva", SqlDbType.DateTime).Value = value;
            cmd.Parameters.Add("@idUsuarioQueReserva", SqlDbType.Int).Value = LoginData.IdUsuario;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = res.idReserva;
            
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = res.idRegimen;
            
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();


            
            MessageBox.Show(string.Format("Reserva Modificada correctamente."), "OK", MessageBoxButtons.OK);
            if (chkModificar.Checked)
            {
                eliminarHabitaciones();
                setearHabitaciones();
            }
            
            this.Hide();
            GenModReserva gmr = new GenModReserva();
            gmr.Show();
            /*var dr = cmd.ExecuteReader();

            var res = 0;

            if (dr.HasRows)
            {
                dr.Read();

                res = int.Parse(dr["Resultado"].ToString()); //si res = -1 es fallido

                if (res == -1)
                {
                    MessageBox.Show("No se puede realizar la reserva ya que existen fechas de baja superpuestas");
                }
                else
                {

                    int codigoReserva = int.Parse(cmd.Parameters["@codReserva"].Value.ToString());
                    codigoRes = codigoReserva;
                    MessageBox.Show(string.Format("Reserva Concretada. Codigo: {0}", codigoReserva), "OK", MessageBoxButtons.OK);
                    setearHabitaciones();
                    this.Hide();
                    GenModReserva gmr = new GenModReserva();
                    gmr.Show();
                }

            }    */
        
        }

        private void eliminarHabitaciones()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.eliminarHabitaciones", con);
            

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = res.idReserva;


            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
        }

        private void setearHabitaciones()
        {

            int i;
            for (i = 0; i < tcs.Count; i++)
            {

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.setearHabitaciones", con);
                DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codigoRes", SqlDbType.Int).Value = res.CodigoReserva;
                cmd.Parameters.Add("@cantHab", SqlDbType.Int).Value = tcs[i].cant;
                cmd.Parameters.Add("@tipoHabDesc", SqlDbType.VarChar, 100).Value = tcs[i].desc;
                cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = dtDesde.Value;
                cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = dtHasta.Value;
                cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;


                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();
            }
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
                int idR = Int32.Parse(reader["idRegimen"].ToString());
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
        

        private void chkModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModificar.Checked)
            {
                groupBox1.Visible = true;
            }
            else if(!chkModificar.Checked)
            {
                groupBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                return;
            }
            else
            {
                if (!chkModificar.Checked)
                {
                    txtC1.Text = lblc1.Text;
                    txtC2.Text = lblc2.Text;
                    txtC3.Text = lblc3.Text;
                    txtC4.Text = lblc4.Text;
                    txtC5.Text = lblc5.Text;

                }

                if (txtC1.Text != "0" )
                {
                    if (!haydispo("BASE SIMPLE", Int32.Parse(txtC1.Text)))
                    {
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC2.Text != "0" )
                {
                    if (!haydispo("BASE DOBLE", Int32.Parse(txtC2.Text)))
                    {
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC3.Text != "0" )
                {
                    if (!haydispo("BASE TRIPLE", Int32.Parse(txtC3.Text)))
                    {
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC4.Text != "0" )
                {
                    if (!haydispo("BASE CUADRUPLE", Int32.Parse(txtC2.Text)))
                    {
                        MessageBox.Show(string.Format("No hay disponibilidad para las fechas indicadas"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtC5.Text != "0" )
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
                //cboHotel.Enabled = false;
                cboRegimen.Enabled = true;
                
                button1.Enabled = false;
                btnModificar.Enabled = true;
                txtC1.Enabled = false;
                txtC2.Enabled = false;
                txtC3.Enabled = false;
                txtC4.Enabled = false;
                
                txtC5.Enabled = false;
            }
        }

        private bool validarCampos()
        {
            int i;
            /*if (cboHotel.Text == "Seleccionar")
            {
                MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

            int result = DateTime.Compare(dtDesde.Value, dtHasta.Value);
            int result2 = DateTime.Compare(value, dtDesde.Value);

            if (result >= 0)
            {
                MessageBox.Show("Seleccione fechas validas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (result2 > 0)
            {
                MessageBox.Show("Seleccione fechas validas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (chkModificar.Checked)
            {
                
                if (!int.TryParse(txtC1.Text, out i) || !int.TryParse(txtC2.Text, out i) || !int.TryParse(txtC3.Text, out i)|| !int.TryParse(txtC4.Text, out i) || !int.TryParse(txtC5.Text, out i))
                {
                    MessageBox.Show("Ingrese cantidad valida de habitaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }


        private bool haydispo(string tipoHabDesc, int cant)
        {


            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.hayDisponibilidadMod", con);

            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = dtDesde.Value;
            cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = dtHasta.Value;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = res.idHotel;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = res.idReserva;
            cmd.Parameters.Add("@tipoHabDesc", SqlDbType.VarChar, 150).Value = tipoHabDesc;


            cmd.Parameters.Add("@rta", SqlDbType.Int).Direction = ParameterDirection.Output; //1->hay dispo. 0>no hay dispo

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int codigoRet = int.Parse(cmd.Parameters["@rta"].Value.ToString());

            if (codigoRet == 0 || codigoRet < cant)
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

            string consultaBusqueda = String.Format("select (r.precio * {0} + ho.RecargaEstrellas * ho.CantidadEstrellas) \"Precio por Noche\", Descripcion \"Tipo de Regimen\" from mmel.Regimen r, mmel.hotel ho where ho.idHotel={1}", cantPersonas, res.idHotel);
            if (cboRegimen.Text != "Seleccionar") consultaBusqueda = consultaBusqueda + String.Format(" and r.Descripcion='{0}'", cboRegimen.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaBusqueda, strCo);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.dgPrecios.DataSource = dataTable;

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
            if (chkModificar.Checked)
            {
                    cant += 1 * Int32.Parse(txtC1.Text);
                    cant += 2 *Int32.Parse(txtC2.Text);
                    cant += 3 *Int32.Parse(txtC3.Text);
                    cant += 4 * Int32.Parse(txtC4.Text);
                    cant += 5 * Int32.Parse(txtC5.Text);
                
            }
            else
            {
                cant += 1 * Int32.Parse(lblc1.Text);
                cant += 2 * Int32.Parse(lblc2.Text);
                cant += 3 * Int32.Parse(lblc3.Text);
                cant += 4 * Int32.Parse(lblc4.Text);
                cant += 5 * Int32.Parse(lblc5.Text);
            }
            return cant;


        }
        private float getPrecio()
        {
            string consultaBusqueda = String.Format("select (r.precio * {0} + ho.RecargaEstrellas * ho.CantidadEstrellas) \"Precio por Noche\", Descripcion \"Tipo de Regimen\" from mmel.Regimen r, mmel.hotel ho where ho.idHotel={1} and r.descripcion='{2}'", getCantPersonas(), idHotel, cboRegimen.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            float precio = 0;
            while (reader.Read())
            {
                precio = Single.Parse(reader["Precio por Noche"].ToString());
            }
            reader.Close();
            con.Close();
            return precio;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CodigoReserva cr = new CodigoReserva();
            cr.Show();
        }
    }
}
