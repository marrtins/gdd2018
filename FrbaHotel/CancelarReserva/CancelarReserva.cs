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

namespace FrbaHotel.CancelarReserva
{
    public partial class CancelarReserva : Form
    {
        int codigoRes;
        public CancelarReserva(int codigoReserva)
        {
            this.codigoRes = codigoReserva;
            InitializeComponent();
            
        }

        private void CancelarReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.cancelarReserva", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@motivo", SqlDbType.VarChar, 300).Value = textBox1.Text;
            cmd.Parameters.Add("@rol", SqlDbType.Int).Value = 1; //modificar esto!!!!
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@codigoRes", SqlDbType.Int).Value = codigoRes;
            cmd.Parameters.Add("@cancelPor", SqlDbType.Int).Value = 1; //modificar esto
            
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            MessageBox.Show("Reserva cancelada con exito", "", MessageBoxButtons.OK);

            
        }
    }
}
