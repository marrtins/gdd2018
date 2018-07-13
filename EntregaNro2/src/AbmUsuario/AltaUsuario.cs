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

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
            cargarTipoID();
            cargarPaises();
            cargarHoteles();
            cboTipo.Text = "Seleccionar";
            cboPaisDir.Text = "Seleccionar";
            cboNacionalidad.Text = "Seleccionar";
            cboHotel.Text = "Seleccionar";
            cboRol.Items.Add("Administrador");
            cboRol.Items.Add("Recepcionista");

        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {

        }

        public bool datosValidos()
        {
            int i;
            if (txtNombre.Text == "") { MessageBox.Show("Falta completar el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtApellido.Text == "") { MessageBox.Show("Falta completar el apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboTipo.Text == "Seleccionar") { MessageBox.Show("Falta completar el tipo de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNroId.Text == "" || !int.TryParse(txtNroId.Text, out i)) { MessageBox.Show("Error en el campo de numero de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtEmail.Text == "") { MessageBox.Show("Falta completar el mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtTel.Text == "" || !int.TryParse(txtTel.Text, out i)) { MessageBox.Show("Error en el campo telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtCalle.Text == "") { MessageBox.Show("Falta completar la calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNroCalle.Text == "" || !int.TryParse(txtNroCalle.Text, out i)) { MessageBox.Show("Error en el campo de numero de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtPiso.Text == "") { MessageBox.Show("Falta completar el piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtDepto.Text == "") { MessageBox.Show("Falta completar el dpto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtLocalidad.Text == "") { MessageBox.Show("Falta completar localidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboNacionalidad.Text == "Seleccionar") { MessageBox.Show("Falta completar nacionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboPaisDir.Text == "Seleccionar") { MessageBox.Show("Falta completar pais del domicilio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboRol.Text=="Seleccionar") { MessageBox.Show("Seleccionar rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboHotel.Text == "Seleccionar") { MessageBox.Show("Seleccionar hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtUserName.Text == "") { MessageBox.Show("Falta completar username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtPassword.Text == "") { MessageBox.Show("Falta completar password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            return true;
        }

        private void cargarTipoID()
        {


            string consultaBusqueda = String.Format("select distinct * from mmel.TipoDocumento ");
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
                string tipo = (reader["detalle"].ToString());
                cboTipo.Items.Add(tipo);

            }
            reader.Close();
            con.Close();




        }

        private void cargarPaises()
        {


            string consultaBusqueda = String.Format("select distinct * from mmel.Pais ");
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
                string tipo = (reader["Nombre"].ToString());
                cboPaisDir.Items.Add(tipo);
                cboNacionalidad.Items.Add(tipo);

            }
            reader.Close();
            con.Close();
            

        }
        private void cargarHoteles()
        {


            string consultaBusqueda = String.Format("select distinct * from mmel.Hotel ");
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
                string tipo = (reader["Nombre"].ToString());
                cboHotel.Items.Add(tipo);

            }
            reader.Close();
            con.Close();
            


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is ComboBox)
                        (control as ComboBox).Text = "Seleccionar";
                    else
                        func(control.Controls);
            };

            func(Controls);

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (datosValidos())
            {

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.crearUsuario", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 200).Value = txtUserName.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 200).Value = txtPassword.Text;
                int idRol;
                if (cboRol.Text == "administrador")
                    idRol = 1;
                else
                    idRol = 2;
                cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
                int idHotel;
                /*if (cboRol.SelectedIndex == 0)
                    idHotel = 0;
                else*/
                idHotel = cboHotel.SelectedIndex + 1;
                cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel; //REVISAR


                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtNombre.Text;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtApellido.Text;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 200).Value = txtEmail.Text;
                cmd.Parameters.Add("@idTipoDocumento", SqlDbType.VarChar, 15).Value = cboTipo.SelectedIndex+1;//revisar
                cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 25).Value = txtNroId.Text;
                cmd.Parameters.Add("@dirIdPais", SqlDbType.VarChar, 150).Value = cboPaisDir.SelectedIndex+1;//revi
                cmd.Parameters.Add("@dirCalle", SqlDbType.VarChar, 150).Value = txtCalle.Text;
                cmd.Parameters.Add("@dirNroCalle", SqlDbType.Int).Value = txtNroCalle.Text;
                cmd.Parameters.Add("@fechaDeNacimiento", SqlDbType.Date).Value = dtfn2.Value;
                cmd.Parameters.Add("@dirDepto", SqlDbType.Char, 2).Value = txtDepto.Text;
                cmd.Parameters.Add("@dirPiso", SqlDbType.SmallInt).Value = Int16.Parse(txtPiso.Text);
                cmd.Parameters.Add("@dirLocalidad", SqlDbType.NVarChar, 150).Value = txtLocalidad.Text;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = txtTel.Text;
                cmd.Parameters.Add("@idNacionalidad", SqlDbType.VarChar, 50).Value = cboNacionalidad.SelectedIndex+1;//rev
                if (chkHab.Checked)
                {
                    cmd.Parameters.Add("@habilitado", SqlDbType.Char, 1).Value = 'S';
                }
                else
                {
                    cmd.Parameters.Add("@habilitado", SqlDbType.Char, 1).Value = 'N';

                }


                //cmd.Parameters.Add("@idNuevo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->ok. 1->tipoynroid existe. 2->mail existe

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
                //int idNuevo = int.Parse(cmd.Parameters["@idNuevo"].Value.ToString());
                if (codigoRet == 0)
                {
                    MessageBox.Show(string.Format("Usuario creado. id "), "OK", MessageBoxButtons.OK);
                    this.Hide();
                    MainAbmUsuario c = new MainAbmUsuario();
                    c.Show();
                }
                else if (codigoRet == 1)
                {
                    MessageBox.Show("Usuario no creado. El tipo y nro de identificacion ya existe", "X", MessageBoxButtons.OK);

                }
                else if (codigoRet == 2)
                {
                    MessageBox.Show("Usuario no creado. El mail ya existe", "X", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Usuario no creado. El username ya existe", "X", MessageBoxButtons.OK);
                }

            }
        }

        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cboRol.SelectedIndex == 0)
            {
                
                cboHotel.Visible = false;
                lblHotel.Visible = false;
                cboHotel.Text = "";
            }
            else
            {
                cboHotel.Visible = true;
                lblHotel.Visible = true;
                cboHotel.Text = "Seleccionar";
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainAbmUsuario m = new MainAbmUsuario();
            m.Show();
        }
    }
}
