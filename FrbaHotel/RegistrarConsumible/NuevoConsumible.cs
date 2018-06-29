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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class NuevoConsumible : Form
    {
        Form ftr;
        int codRes;
        public NuevoConsumible(Form ftr,int codRes)
        {
            InitializeComponent();
            this.ftr = ftr;
            this.codRes = codRes;
        }

        private void NuevoConsumible_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (datosValidos())
            {

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.crearConsumible", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar,75).Value = txtNombre.Text;
                cmd.Parameters.Add("@costo", SqlDbType.Int).Value = Int32.Parse(textBox1.Text);
                cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->no existe la habitacion en esta fecha ; 1 -> ok

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
                if (codigoRet == 0)
                {
                    MessageBox.Show("El consumible ya esta creado. Intente nuevamente", "X", MessageBoxButtons.OK);
                }
                else if (codigoRet == 1)
                {
                    MessageBox.Show("Consumible creado", "OK", MessageBoxButtons.OK);
                    this.Hide();
                    MainRegCons mrc = new MainRegCons(codRes);
                    mrc.Show();
                }
            }
        }
        private bool datosValidos()
        {
            int i;
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Seleccionar nombre de consumible", "X", MessageBoxButtons.OK);
                return false;
            }
            
            if (textBox1.Text == "" || !int.TryParse(textBox1.Text, out i))
            {
                MessageBox.Show("Seleccionar precio del consumible", "X", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            ftr.Show();
        }
    }
}
