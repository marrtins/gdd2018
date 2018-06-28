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
    public partial class ModificarCheckinConsistente : Form
    {
        DateTime fechaChkIn;
        int idEstadia;
        Form formtoret;
        public ModificarCheckinConsistente(DateTime fechaChkIn,int idEstadia,Form formtoret)
        {
            this.fechaChkIn = fechaChkIn;
            this.idEstadia = idEstadia;
            this.formtoret = formtoret;
            InitializeComponent();
            label1.Text = label1.Text + String.Format(" {0}",fechaChkIn);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModificarCheckinConsistente_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.actualizarCheckIn", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEstadia;
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);
            cmd.Parameters.Add("@fechaCheckIn", SqlDbType.DateTime).Value = value; 
            cmd.Parameters.Add("@iduserQueModifica", SqlDbType.Int).Value = LoginData.IdUsuario;
            cmd.Parameters.Add("@rta", SqlDbType.Int).Direction = ParameterDirection.Output;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int rta = int.Parse(cmd.Parameters["@rta"].Value.ToString());
            if (rta == 1)
            {
                MessageBox.Show("Fecha check in modificada exitosamente", "X", MessageBoxButtons.OK);
                this.Hide();
                formtoret.Show();
            }
            else
            {
                MessageBox.Show("Solo puede realizarse check in el día que fue reservado", "X", MessageBoxButtons.OK);
            }
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            formtoret.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
