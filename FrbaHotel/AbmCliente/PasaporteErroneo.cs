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
    public partial class PasaporteErroneo : Form
    {

        private int idPersona;
        private int idPersona2;
        private string nombre;
        private string apellido;
        private string nrodoc;
        private string mail;
        private DatosCliente datos;
        private int modo;

        public PasaporteErroneo(DatosCliente datos,int modo)
        {
            this.idPersona = datos.idPersona;
            this.modo = modo;
            this.nombre = datos.nombre;
            this.apellido = datos.apellido;
            this.nrodoc = datos.nrodoc;
            this.mail = datos.mail;
            this.datos = datos;
            InitializeComponent();
            label1.Text = "El cliente seleccionado posee un Nro de pasaporte duplicado. \n. Seleccione a quien le corresponda dicho número";

            lblNombre1.Text = nombre;
            lblApellido1.Text = apellido;
            lblNumero1.Text = nrodoc;
            lblMail1.Text = mail;

            string consultaBusqueda = String.Format("select top 1 pe.idPersona, pe.Nombre,pe.Apellido,pe.NroDocumento,pe.Mail from mmel.Persona pe where pe.idPersona <>{0} and pe.NroDocumento like  '{1}' ", idPersona, nrodoc);
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
                lblNombre2.Text = (reader["Nombre"].ToString());
                lblApellido2.Text = (reader["Apellido"].ToString());
                lblnro2.Text = (reader["NroDocumento"].ToString());
                lblMail2.Text = (reader["Mail"].ToString());
                idPersona2 = Int32.Parse(reader["idPersona"].ToString());
            }
            reader.Close();
            con.Close();


        }

        private void PasaporteErroneo_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.removerPasaporte", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
            this.Hide();
            if (modo == 1)
            {
                ModificarCliente mc = new ModificarCliente(datos);
            }
            else if (modo == 2)
            {
                BorrarCliente bc = new BorrarCliente(datos);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.removerPasaporte", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona2;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
            this.Hide();
            if (modo == 1)
            {
                ModificarCliente mc = new ModificarCliente(datos);
            }
            else if (modo == 2)
            {
                BorrarCliente bc = new BorrarCliente(datos);
            }
        }
    }
}
