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
using FrbaHotel.AbmHotel.Model;
using FrbaHotel.Utilities;

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaUsuario : Form
    {
        public Rol Rol { get; private set; }
        public List<Hotel> Hoteles { get; private set; }
        public List<Rol> Roles { get; private set; }

        public AltaUsuario()
        {
            InitializeComponent();
            cargarTipoID();
            cargarPaises();
            cboTipo.Text = "Seleccionar";
            cboPaisDir.Text = "Seleccionar";
            cboNacionalidad.Text = "Seleccionar";
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
            if (Roles == null) { MessageBox.Show("Seleccionar rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (Hoteles == null) { MessageBox.Show("Seleccionar hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
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

            Hoteles = null;
            Rol = null;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (datosValidos())
            {

                var hotelesTable = new DataTable();
                hotelesTable.Columns.Add("Id", typeof(int));
                Hoteles.ForEach(h => hotelesTable.Rows.Add(h.IdHotel));


                var rolesTable = new DataTable();
                rolesTable.Columns.Add("Id", typeof(int));
                Roles.ForEach(h => rolesTable.Rows.Add(h.idRol));

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.crearUsuario", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 200).Value = txtUserName.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 200).Value = txtPassword.Text;

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

                var pList = new SqlParameter("@hoteles_ids", SqlDbType.Structured);
                pList.TypeName = "MMEL.IdList";
                pList.Value = hotelesTable;
                cmd.Parameters.Add(pList);

                var pList2 = new SqlParameter("@roles_ids", SqlDbType.Structured);
                pList2.TypeName = "MMEL.IdList";
                pList2.Value = rolesTable;
                cmd.Parameters.Add(pList2);


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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainAbmUsuario m = new MainAbmUsuario();
            m.Show();
        }

        private void seleccionarHotelBtn_Click(object sender, EventArgs e)
        {
            var abmHotel = new AbmHotel.Listado(TipoSeleccion.Multi);

            abmHotel.ShowDialog();

            if (abmHotel.DialogResult == DialogResult.OK)
            {
                Hoteles = abmHotel.ObjetosResultado;

                this.hotelesLv.Items.Clear();
                this.hotelesLv.Items.AddRange(Hoteles.Select(h => new ListViewItem(h.Nombre)).ToArray());
            }
        }

        private void seleccionarRolBtn_Click(object sender, EventArgs e)
        {
            var abmRol = new AbmRol.Listado(TipoSeleccion.Multi);

            abmRol.ShowDialog();

            if (abmRol.DialogResult == DialogResult.OK)
            {
                Roles = abmRol.ObjetosResultado;

                this.rolesLv.Items.Clear();
                this.rolesLv.Items.AddRange(Roles.Select(h => new ListViewItem(h.Nombre)).ToArray());
            }
        }
    }
}
