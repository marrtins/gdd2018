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

namespace FrbaHotel.AbmUsuario
{
    public partial class ModificarUsuario : Form
    {
        int idUsuario;
        bool puedeModificar=false;

        int idHotel;
        int idRol;

        public ModificarUsuario(int idUsuario)
        {
            InitializeComponent();
            cargarPaises();
            cargarTipoID();

            this.idUsuario = idUsuario;
            llenarCamposUsuario();
            txtPassword.Visible = false;
            label6.Visible = false;

        }

        private void llenarCamposUsuario()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.getInfoUsuario", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@tipoid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@nroDoc", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@fechanac", SqlDbType.Date).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@calle", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@nro", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@piso", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@dpto", SqlDbType.Char, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@localidad", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@pais", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@activo", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 75).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@rol", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@hotel", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Direction = ParameterDirection.Output;


            cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            string nombre = (cmd.Parameters["@nombre"].Value.ToString());
            string apellido = (cmd.Parameters["@apellido"].Value.ToString());
            string tipoid = (cmd.Parameters["@tipoid"].Value.ToString());
            string nroDoc = (cmd.Parameters["@nroDoc"].Value.ToString());

            DateTime fechaDeNacimiento = DateTime.Parse(cmd.Parameters["@fechanac"].Value.ToString());

            string nacionalidad = (cmd.Parameters["@nacionalidad"].Value.ToString());
            string email = (cmd.Parameters["@email"].Value.ToString());
            string telefono = (cmd.Parameters["@telefono"].Value.ToString());
            string calle = (cmd.Parameters["@calle"].Value.ToString());

            int nro = Int32.Parse(cmd.Parameters["@nro"].Value.ToString());
            int piso = Int32.Parse(cmd.Parameters["@piso"].Value.ToString());
            char dpto = (cmd.Parameters["@dpto"].Value.ToString())[0];

            string localidad = (cmd.Parameters["@localidad"].Value.ToString());
            string pais = (cmd.Parameters["@pais"].Value.ToString());

            char habilitado = (cmd.Parameters["@activo"].Value.ToString())[0];

            string username = (cmd.Parameters["@username"].Value.ToString());
            string rol = (cmd.Parameters["@rol"].Value.ToString());
            string hotel = (cmd.Parameters["@hotel"].Value.ToString());

            idRol = Int32.Parse(cmd.Parameters["@idRol"].Value.ToString());
            idHotel = Int32.Parse(cmd.Parameters["@idHotel"].Value.ToString());

            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            cboTipo.Text = tipoid;
            txtNroId.Text = nroDoc;
            dtfn2.Value = fechaDeNacimiento;
            cboNacionalidad.Text = nacionalidad;
            txtEmail.Text = email;
            txtTel.Text = telefono;
            txtCalle.Text = calle;
            txtNroCalle.Text = String.Format("{0}", nro);
            txtPiso.Text = String.Format("{0}", piso);
            txtDepto.Text = String.Format("{0}", dpto);
            txtLocalidad.Text = localidad;
            cboPaisDir.Text = pais;
            if (habilitado == 'S')
                chkHab.Checked = true;
            else
                chkHab.Checked = false;
            txtUserName.Text = username;
            rolInput.Text = rol;
            hotelInput.Text = hotel;
            if (String.IsNullOrEmpty(LoginData.Hotel.Nombre))
                puedeModificar = true;
            else if (LoginData.Hotel.Nombre == hotel)
                puedeModificar = true;
        
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            llenarCamposUsuario();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            //modif
            if (!puedeModificar) { 
                MessageBox.Show("Usuario no modificado. Solo puede modificar a empleados del mismo hotel", "X", MessageBoxButtons.OK);
                return;
            }
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.modificarUsuario", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 200).Value = txtUserName.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 200).Value = txtPassword.Text;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;

            cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario; //REVISAR
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtNombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtApellido.Text;
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 200).Value = txtEmail.Text;
            cmd.Parameters.Add("@idTipoDocumento", SqlDbType.VarChar, 15).Value = cboTipo.SelectedIndex + 1;//revisar
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 25).Value = txtNroId.Text;
            cmd.Parameters.Add("@dirIdPais", SqlDbType.VarChar, 150).Value = cboPaisDir.SelectedIndex + 1;//revi
            cmd.Parameters.Add("@dirCalle", SqlDbType.VarChar, 150).Value = txtCalle.Text;
            cmd.Parameters.Add("@dirNroCalle", SqlDbType.Int).Value = txtNroCalle.Text;
            cmd.Parameters.Add("@fechaDeNacimiento", SqlDbType.Date).Value = dtfn2.Value;
            cmd.Parameters.Add("@dirDepto", SqlDbType.Char, 2).Value = txtDepto.Text;
            cmd.Parameters.Add("@dirPiso", SqlDbType.SmallInt).Value = Int16.Parse(txtPiso.Text);
            cmd.Parameters.Add("@dirLocalidad", SqlDbType.NVarChar, 150).Value = txtLocalidad.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = txtTel.Text;
            cmd.Parameters.Add("@idNacionalidad", SqlDbType.VarChar, 50).Value = cboNacionalidad.SelectedIndex + 1;//rev

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
                MessageBox.Show(string.Format("Usuario modificado "), "OK", MessageBoxButtons.OK);
                this.Hide();
                MainAbmUsuario c = new MainAbmUsuario();
                c.Show();
            }
            else if (codigoRet == 1)
            {
                MessageBox.Show("Usuario no modificado. El tipo y nro de identificacion ya existe", "X", MessageBoxButtons.OK);

            }
            else if (codigoRet == 2)
            {
                MessageBox.Show("Usuario no modificado. El mail ya existe", "X", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Usuario no modificado. El username ya existe", "X", MessageBoxButtons.OK);
            }

        }

        private void chkModiPw_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModiPw.Checked)
            {
                txtPassword.Text = "";
                txtPassword.Enabled = true;
                label6.Enabled = true;
            }
            else
            {
                txtPassword.Text = "";
                label6.Enabled = false;
                txtPassword.Enabled = false;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainAbmUsuario m = new MainAbmUsuario();
            m.Show();
        }

        private bool datosValidos()
        {
            int i;
            if (txtNombre.Text == "") { MessageBox.Show("Falta completar el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtApellido.Text == "") { MessageBox.Show("Falta completar el apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboTipo.Text == "Seleccionar") { MessageBox.Show("Falta completar el tipo de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNroId.Text == "" || !int.TryParse(txtNroCalle.Text, out i)) { MessageBox.Show("Error en el campo de numero de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtEmail.Text == "") { MessageBox.Show("Falta completar el mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtTel.Text == "" || !int.TryParse(txtTel.Text, out i)) { MessageBox.Show("Error en el campo telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtCalle.Text == "") { MessageBox.Show("Falta completar la calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNroCalle.Text == "" || !int.TryParse(txtNroCalle.Text, out i)) { MessageBox.Show("Error en el campo de numero de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtPiso.Text == "") { MessageBox.Show("Falta completar el piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtDepto.Text == "") { MessageBox.Show("Falta completar el dpto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtLocalidad.Text == "") { MessageBox.Show("Falta completar localidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboNacionalidad.Text == "Seleccionar") { MessageBox.Show("Falta completar nacionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboPaisDir.Text == "Seleccionar") { MessageBox.Show("Falta completar pais del domicilio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtUserName.Text == "") { MessageBox.Show("Falta completar el username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (chkModiPw.Checked)
            {
                if (txtPassword.Text == "") { MessageBox.Show("Falta completar el password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            }
            return true;



        }

        private void seleccionarRolBtn_Click(object sender, EventArgs e)
        {
            var abmRol = new AbmRol.Listado(true);

            abmRol.ShowDialog();

            if (abmRol.DialogResult == DialogResult.OK)
            {
                var Rol = abmRol.ObjetoResultado;

                this.rolInput.Text = Rol.Nombre;
                this.idRol = Rol.idRol;
            }
        }

        private void seleccionarHotelBtn_Click(object sender, EventArgs e)
        {
            var abmHotel = new AbmHotel.Listado(true);

            abmHotel.ShowDialog();

            if (abmHotel.DialogResult == DialogResult.OK)
            {
                var Hotel = abmHotel.ObjetoResultado;

                this.hotelInput.Text = Hotel.Nombre;
                this.idHotel = Hotel.IdHotel;
            }
        }
    }
    
}
