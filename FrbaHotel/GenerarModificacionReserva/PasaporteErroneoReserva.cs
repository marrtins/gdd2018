using FrbaHotel.AbmCliente;
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
    public partial class PasaporteErroneoReserva : Form
    {
        private int idPersona;
        private int idPersona2;
        private string nombre;
        private string apellido;
        private string nrodoc;
        private string mail;
        ConfirmarReserva crform;
        public PasaporteErroneoReserva(int idPersona,string nombre,string apellido,string nroDoc,string mail,ConfirmarReserva crform)
        {
            this.idPersona = idPersona;
            
            this.nombre = nombre;
            this.apellido =apellido;
            this.nrodoc = nroDoc;
            this.mail = mail;
            this.crform = crform;
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

        private void PasaporteErroneoReserva_Load(object sender, EventArgs e)
        {

        }
        private void btn1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btn1_Click_1(object sender, EventArgs e)
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
            crform.Show();
        }

        private void btn2_Click_1(object sender, EventArgs e)
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
            crform.Show();
        }
    }
}
