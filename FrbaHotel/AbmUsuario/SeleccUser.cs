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
    public partial class SeleccUser : Form
    {
        int modo;
        public SeleccUser(int modo)
        {
            InitializeComponent();
            this.modo = modo;
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Accion";

            if (modo == 1) { bcol.Text = "Modificar "; }
            else { bcol.Text = "Inhabilitar"; }
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(bcol);
            cboTipoId.Items.Add("Seleccionar");
            cargarTipoID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int i;
            if (txtNroId.Text != "" && !int.TryParse(txtNroId.Text, out i))
            {
                MessageBox.Show("Ingrese formato correcto de nro de identificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string consultaBusqueda = String.Format("select pe.Nombre,pe.Apellido,us.Username,td.detalle TipoDocumento,pe.NroDocumento,pe.Mail,ro.Nombre Rol,ho.Nombre NombreHotel,us.idusuario from mmel.Usuarios us,mmel.Persona pe,mmel.TipoDocumento td,mmel.UsuariosPorRoles rpu,mmel.Rol ro,mmel.HotelesPorUsuarios hpu,mmel.Hotel ho where us.idPersona = pe.idPersona and pe.idTipoDocumento = td.idTipoDocumento and rpu.idUsuario = us.idUsuario and rpu.idRol = ro.idRol and hpu.idUsuario = us.idUsuario and ho.idHotel = hpu.idHotel");
            if (modo == 2) consultaBusqueda = consultaBusqueda + " and us.activo = 'S'";


            if (txtUsername.Text != "")
            {
                consultaBusqueda = String.Format("{0} and us.username like '%{1}%'", consultaBusqueda, txtUsername.Text.ToUpper());
            }
            if (txtNombre.Text != "")
            {
                consultaBusqueda = String.Format("{0} and pe.Nombre like '%{1}%'", consultaBusqueda, txtNombre.Text.ToUpper());
            }
            if (txtApellido.Text != "")
            {
                consultaBusqueda = String.Format("{0} and pe.Apellido like '%{1}%'", consultaBusqueda, txtApellido.Text.ToUpper());

            }
            if (cboTipoId.Text != "Seleccionar")
            {

                consultaBusqueda = String.Format("{0} and td.detalle like '{1}'", consultaBusqueda, cboTipoId.Text);

            }

            if (txtNroId.Text != "")
            {

                consultaBusqueda = String.Format("{0} and pe.NroDocumento like '%{1}%'", consultaBusqueda, Int32.Parse(txtNroId.Text));

            }
            if (txtEmail.Text != "")
            {
                consultaBusqueda = String.Format("{0} and pe.Mail like '%{1}%'", consultaBusqueda, txtEmail.Text);

            }

            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaBusqueda, strCo);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void buscar()
        {
            int i;
            if (txtNroId.Text != "" && !int.TryParse(txtNroId.Text, out i))
            {
                MessageBox.Show("Ingrese formato correcto de nro de identificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string consultaBusqueda = String.Format("select pe.Nombre,pe.Apellido,us.Username,td.detalle TipoDocumento,pe.NroDocumento,pe.Mail,ro.Nombre Rol,ho.Nombre NombreHotel,us.idusuario from mmel.Usuarios us,mmel.Persona pe,mmel.TipoDocumento td,mmel.UsuariosPorRoles rpu,mmel.Rol ro,mmel.HotelesPorUsuarios hpu,mmel.Hotel ho where us.idPersona = pe.idPersona and pe.idTipoDocumento = td.idTipoDocumento and rpu.idUsuario = us.idUsuario and rpu.idRol = ro.idRol and hpu.idUsuario = us.idUsuario and ho.idHotel = hpu.idHotel");
            if (modo == 2) consultaBusqueda = consultaBusqueda + " and us.activo = 'S'";


            if (txtUsername.Text != "")
            {
                consultaBusqueda = String.Format("{0} and us.username like '%{1}%'", consultaBusqueda, txtUsername.Text.ToUpper());
            }
            if (txtNombre.Text != "")
            {
                consultaBusqueda = String.Format("{0} and pe.Nombre like '%{1}%'", consultaBusqueda, txtNombre.Text.ToUpper());
            }
            if (txtApellido.Text != "")
            {
                consultaBusqueda = String.Format("{0} and pe.Apellido like '%{1}%'", consultaBusqueda, txtApellido.Text.ToUpper());

            }
            if (cboTipoId.Text != "Seleccionar")
            {

                consultaBusqueda = String.Format("{0} and td.detalle like '{1}'", consultaBusqueda, cboTipoId.Text);

            }

            if (txtNroId.Text != "")
            {

                consultaBusqueda = String.Format("{0} and pe.NroDocumento like '%{1}%'", consultaBusqueda, Int32.Parse(txtNroId.Text));

            }
            if (txtEmail.Text != "")
            {
                consultaBusqueda = String.Format("{0} and pe.Mail like '%{1}%'", consultaBusqueda, txtEmail.Text);

            }

            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaBusqueda, strCo);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
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
                cboTipoId.Items.Add(tipo);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                /*string nombre,string apellido,string tipodoc,string nrodoc,string mail,string telefono,
            DateTime fechanac,string nacionalidad,string dircalle,int dirnrocalle,string pais,int dirpiso,
            string dirdepto,string dirlocalidad, string habilitado
            */
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                int idUsuario = Int32.Parse(row.Cells["idUsuario"].Value.ToString());
                string nombre = row.Cells["Nombre"].Value.ToString();
                string apellido = row.Cells["Apellido"].Value.ToString();
                string tipodoc = row.Cells["TipoDocumento"].Value.ToString();
                string nrodoc = row.Cells["NroDocumento"].Value.ToString();
                string rol = row.Cells["rol"].Value.ToString();
                string nombreHotel = row.Cells["NombreHotel"].Value.ToString();

                if (modo == 1)
                {
                    ModificarUsuario mu = new ModificarUsuario(idUsuario);
                    mu.Show();
                    this.Hide();
                }
                else
                {
                    inhabilitarUsuario(idUsuario);
                    MessageBox.Show("Cliente inhabilitado", "Ok" ,MessageBoxButtons.OK);
                    buscar();
                }

               


                
            }
        }
        private void inhabilitarUsuario(int idUsuario)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.borrarUsuario", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
        }

        private void SeleccUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainAbmUsuario m = new MainAbmUsuario();
            m.Show();
        }
    }
}
