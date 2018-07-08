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

namespace FrbaHotel.Facturar
{
    public partial class NuevaFactura : Form
    {
        int idEstadia;
        bool dtoRegimenbool = false;
        float nuevoValorVB;
        int nuevoValorCons;
        int nuevoCantCons;
        int nuevoDtoRegimen;
        float valorActual;
        public NuevaFactura(int idest)
        {
            InitializeComponent();
            this.idEstadia = idest;
            cargarFacturaNueva();
            cargarFormaDePago();
        }

        private void NuevaFactura_Load(object sender, EventArgs e)
        {

        }



        private void cargarFacturaNueva()
        {


            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.getFacturaNueva", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEstadia;

            cmd.Parameters.Add("@rPrecio", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@hcantEst", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@hrEst", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@cantPersonas", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@cantDias", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@cantDiasUtilizados", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@cantDiasNoUtilizados", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@chINEstadia", SqlDbType.DateTime).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@chOUTEstadia", SqlDbType.DateTime).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@valorConsumibles", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@dtoRegimen", SqlDbType.Int).Direction = ParameterDirection.Output;




            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int rPrecio = int.Parse(cmd.Parameters["@rPrecio"].Value.ToString());
            int hcantEst = int.Parse(cmd.Parameters["@hcantEst"].Value.ToString());
            int hrEst = int.Parse(cmd.Parameters["@hrEst"].Value.ToString());
            int cantPersonas = int.Parse(cmd.Parameters["@cantPersonas"].Value.ToString());
            int cantDias = int.Parse(cmd.Parameters["@cantDias"].Value.ToString());

            //int cantidadConsumibles = int.Parse(cmd.Parameters["@cantidadConsumibles"].Value.ToString());
            int valorConsumibles = int.Parse(cmd.Parameters["@valorConsumibles"].Value.ToString());
            DateTime chINEstadia = DateTime.Parse(cmd.Parameters["@chINEstadia"].Value.ToString());
            DateTime chOUTEstadia = DateTime.Parse(cmd.Parameters["@chOUTEstadia"].Value.ToString());
            TimeSpan cdaux = chOUTEstadia.Date - chINEstadia.Date;
            int cantDiasUtilizados = Convert.ToInt32(cdaux.TotalDays);

            int cantDiasNoUtilizados = cantDias - cantDiasUtilizados;

            int dtoRegimen = int.Parse(cmd.Parameters["@dtoRegimen"].Value.ToString());


            float valorBaseHab = (rPrecio * cantPersonas + hrEst * hcantEst) * cantDias * cantPersonas;

            //nuevoCantCons = cantidadConsumibles;
            nuevoValorCons = valorConsumibles;
            nuevoValorVB = valorBaseHab;

            valorActual=valorBaseHab + valorConsumibles;
            if (dtoRegimen == 100)
            {
                valorActual = valorActual - valorConsumibles;
                lblTotalAct.Text = lblTotalAct.Text + String.Format(" $-{0}", valorConsumibles);
                dtoRegimenbool = true;
                nuevoDtoRegimen = valorConsumibles;
            }
            else
            {
                lblTotalAct.Text = lblTotalAct.Text + String.Format(" ${0}", valorActual);
            }


            lblFCHIN.Text += String.Format(" {0}", chINEstadia);
            lblFCHOUT.Text += String.Format(" {0}", chOUTEstadia);

            lblVBActual.Text = lblVBActual.Text + String.Format(" ${0}", valorBaseHab);
            lbldaloj.Text += String.Format(" {0}", cantDiasUtilizados);
            lbldnu.Text += String.Format(" {0}", cantDiasNoUtilizados);
            lblVCAct.Text += String.Format(" ${0}", valorConsumibles);
            lblDtoACt.Text += String.Format(" $ -{0}", dtoRegimen);


            listarConsumiblesAct();




        }

        private void cargarFormaDePago()
        {
            cboFormaDePago.Items.Add("TARJETA DE CREDITO");
            cboFormaDePago.Items.Add("TARJETA DE DEBITO");
            cboFormaDePago.Items.Add("EFECTIVO");
            cboFormaDePago.Items.Add("CHEQUE");

        }
        private void listarConsumiblesAct()
        {
            string consultaBusqueda = String.Format("select Nombre,Costo from mmel.Consumible co,mmel.ConsumiblePorEstadia ce where ce.idEstadia={0} and ce.idConsumible=co.idConsumible",idEstadia);
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
                string aux="";
                while (reader.Read())
                {

                    aux = (reader["Nombre"].ToString()) + " " + (reader["Costo"].ToString());
                    lstConsAct.Items.Add(aux);
                }
                reader.Close();
                con.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //factual
            if (cboFormaDePago.Text == "Seleccionar")
            {
                return;
            }


            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.crearFactura", con);
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEstadia;
            cmd.Parameters.Add("@FactTotal", SqlDbType.Int).Value = (valorActual);
            cmd.Parameters.Add("@FacturaFecha", SqlDbType.DateTime).Value = value;
            cmd.Parameters.Add("@formaDePago", SqlDbType.VarChar,50).Value = cboFormaDePago.Text;



            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            MessageBox.Show("Facturacion realizada exitosamente");


            actualizarVBAse();
            if (dtoRegimenbool)
            {
                actualizardtoReg();
            }


            this.Hide();
            Inicio f = new Inicio();
            f.Show();
        }
        private void actualizarVBAse()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.actualizarItems", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEstadia;
            cmd.Parameters.Add("@nuevoValorVB", SqlDbType.Int).Value = nuevoValorVB;
            cmd.Parameters.Add("@nuevoValorCons", SqlDbType.Int).Value = nuevoValorCons;
            cmd.Parameters.Add("@cantCons", SqlDbType.Int).Value = nuevoCantCons;




            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
        }
        private void actualizardtoReg()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.agregarItemDto", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEstadia;
            cmd.Parameters.Add("@valorDto", SqlDbType.Int).Value = nuevoDtoRegimen;





            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
        }
    }
}
