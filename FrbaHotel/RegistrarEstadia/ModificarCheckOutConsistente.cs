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
            
            label1.Text = label1.Text + String.Format(" {0}", fechaChkOut);
        }

        private void ModificarCheckOutConsistente_Load(object sender, EventArgs e)
        {
            

        }
        private void realizarCheckOut()
        {

        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            formtoret.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.actualizarCheckOut", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEstadia;
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

            cmd.Parameters.Add("@fechaCheckOut", SqlDbType.DateTime).Value = value;
            cmd.Parameters.Add("@iduserQueModifica", SqlDbType.VarChar, 200).Value = LoginData.IdUsuario;


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
