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
    public partial class ModificarCheckInInconsistente : Form
    {
        DateTime fin, fout;
        int idest;
        Form ftr;
            
        public ModificarCheckInInconsistente(DateTime fin,DateTime fout,int idest,Form ftr)
        {
            
            InitializeComponent();
            this.fin = fin;
            this.fout = fout;
            this.idest = idest;
            this.ftr = ftr;
            lblCheckInActual.Text = lblCheckInActual.Text + String.Format(" {0}", fin);
            lblFechaCheckOut.Text = lblFechaCheckOut.Text + String.Format(" {0}", fout);
            //label2.Text = "Para dejar la estadia en un estado consistente, se modificará la fecha de check in  y se eliminará la fecha de check out a fin de poder estipularla cuando sea necesaria. Gracias"
        }

        private void ModificarCheckInInconsistente_Load(object sender, EventArgs e)
        {
            this.Hide();
            ftr.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            ftr.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.actualizarCheckIn", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idest;
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
                ftr.Show();
            }
            else
            {
                MessageBox.Show("Solo puede realizarse check in el día que fue reservado", "X", MessageBoxButtons.OK);
            }
        }
    }
}
