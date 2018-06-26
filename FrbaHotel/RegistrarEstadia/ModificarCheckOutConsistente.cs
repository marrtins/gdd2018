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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class ModificarCheckOutConsistente : Form
    {
        DateTime fechaChkOut;
        int idEstadia;
        Form formtoret;
        public ModificarCheckOutConsistente(DateTime fechaChkOut, int idEstadia, Form formtoret)
        {
            InitializeComponent();
            this.fechaChkOut = fechaChkOut;
            this.idEstadia = idEstadia;
            this.formtoret = formtoret;
            InitializeComponent();
            label1.Text = label1.Text + String.Format(" {0}", fechaChkOut);
        }

        private void ModificarCheckOutConsistente_Load(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.actualizarCheckOut", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEstadia;

            
            cmd.Parameters.Add("@fechaCheckOut", SqlDbType.Int).Value = DateTime.Today; //MODIFICAR!
            cmd.Parameters.Add("@userQueModifica", SqlDbType.VarChar, 200).Value = "Juan"; //MODIFICArRRRrR
            

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();


            MessageBox.Show("Fecha check out modificada exitosamente", "X", MessageBoxButtons.OK);
            this.Hide();
            formtoret.Show();

        }
    }
}
