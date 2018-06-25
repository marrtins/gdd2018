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
            this.fin = fin;
            this.fout = fout;
            this.idest = idest;
            this.ftr = ftr;
            lblCheckInActual.Text = lblCheckInActual.Text + String.Format(" {0}", fin);
            lblFechaCheckOut.Text = lblFechaCheckOut.Text + String.Format(" {0}", fout);
            InitializeComponent();
            //label2.Text = "Para dejar la estadia en un estado consistente, se modificará la fecha de check in  y se eliminará la fecha de check out a fin de poder estipularla cuando sea necesaria. Gracias"
        }

        private void ModificarCheckInInconsistente_Load(object sender, EventArgs e)
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
            cmd.Parameters.Add("@fechaCheckIn", SqlDbType.Int).Value = DateTime.Today; //MODIFICAR!
            cmd.Parameters.Add("@userQueModifica", SqlDbType.VarChar, 200).Value = "Juan"; //MODIFICArRRRrR

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();


            MessageBox.Show("Fecha check in y check out modificada exitosamente.", "X", MessageBoxButtons.OK);
            this.Hide();
            ftr.Show();
        }
    }
}
