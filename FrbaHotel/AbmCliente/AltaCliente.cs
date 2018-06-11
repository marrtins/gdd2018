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
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
            cboTipo.Items.Add("DNI");
            cboTipo.Items.Add("PASAPORTE");
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            /*string ConnStr = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(ConnStr);
            SqlCommand comando = new SqlCommand("Select * from [GD1C2018].[MMEL].[PAIS]");
            SqlDataReader reader = comando.ExecuteReader();
            con.Open();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["Nombre"].ToString());
            }
            reader.Close();
            con.Close();
            */



        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            
            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.AgregarCliente",con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtNombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtApellido.Text;
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.VarChar, 15).Value = cboTipo.Text;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar,25).Value = txtNroId.Text;
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 200).Value = txtEmail.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = txtTel.Text;
            cmd.Parameters.Add("@fechaDeNacimiento", SqlDbType.Date).Value = dtfn2.Value;
            cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 50).Value = cboNacionalidad.Text;
            cmd.Parameters.Add("@dirCalle", SqlDbType.VarChar, 150).Value = txtCalle.Text;
            cmd.Parameters.Add("@pais", SqlDbType.VarChar,150).Value = cboPaisDir.Text;
            cmd.Parameters.Add("@dirNroCalle", SqlDbType.Int).Value = txtNroCalle.Text;
            cmd.Parameters.Add("@dirPiso", SqlDbType.SmallInt).Value = Int16.Parse(txtPiso.Text);
            cmd.Parameters.Add("@dirDepto", SqlDbType.Char,2).Value = txtDepto.Text;
            cmd.Parameters.Add("@dirLocalidad", SqlDbType.NVarChar, 150).Value = txtLocalidad.Text;
            if (chkHab.Checked)
            {
                cmd.Parameters.Add("@habilitado", SqlDbType.Char, 1).Value = 'S';
            }
            else
            {
                cmd.Parameters.Add("@habilitado", SqlDbType.Char, 1).Value = 'N';

            }
            cmd.Parameters.Add("@idNuevo", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->ok. 1->tipoynroid existe. 2->mail existe

           if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
            int idNuevo= int.Parse(cmd.Parameters["@idNuevo"].Value.ToString());
            if (codigoRet == 0)
            {
                MessageBox.Show(string.Format("Cliente creado. id {0}", idNuevo), "OK", MessageBoxButtons.OK);
            }else if (codigoRet == 1)
            {
                MessageBox.Show("Cliente no creado. El tipo y nro de identificacion ya existe", "X", MessageBoxButtons.OK);

            }
            else if (codigoRet == 2)
            {
                MessageBox.Show("Cliente no creado. El mail ya existe", "X", MessageBoxButtons.OK);

            }















        }
    }
}
