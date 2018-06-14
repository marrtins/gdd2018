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

namespace FrbaHotel.AbmCliente
{
    public partial class BorrarCliente : Form
    {
        private DatosCliente datos;

        public BorrarCliente()
        {
            
        }

        public BorrarCliente(DatosCliente dc)
        {
            this.datos = dc;

            InitializeComponent();


            int aux = datos.esErroneo(datos.idPersona);

            if (aux == 1)
            {
                MailErroneo me = new MailErroneo(datos,2);
                me.Show();
            }
            else if (aux == 2)
            {
                //error de id y tipo repetidos
                PasaporteErroneo pe = new PasaporteErroneo(datos,2);
                pe.Show();
            }
            else if (aux == 0)
            {
                //todo ok 
                this.Show();
                llenarCampos();
            }


        }

        private void llenarCampos()
        {


            lblMail.Text = "";


            lblNombre.Text = datos.nombre;
            lblApellido.Text = datos.apellido;
            lblTipoDoc.Text = datos.tipodoc.ToString();
            lblNroDoc.Text = datos.nrodoc;
            lblMail.Text = datos.mail;



        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.borrarCliente", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = datos.idPersona;

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            MessageBox.Show("Cliente Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BorrarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
