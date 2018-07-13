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
    public partial class SeleccionCliente : Form
    {
        private int modo;

        public SeleccionCliente()
        {
            

            

        }

        public SeleccionCliente(int v)
        {
            this.modo = v; // valor  = 1 -> modificar ; valor = 2 -> BOrrar



            InitializeComponent();
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Accion";

            if (modo == 1) { bcol.Text = "Modificar "; }
            else { bcol.Text = "Inhabilitar"; }            
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dgCustomer.Columns.Add(bcol);
            cboTipoId.Items.Add("Seleccionar");
            cargarTipoID();
            buscar();
            


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int i;
            if (txtNroId.Text!= "" && !int.TryParse(txtNroId.Text, out i))
            {
                MessageBox.Show("Ingrese formato correcto de nro de identificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
                
            }
            string consultaBusqueda = String.Format("select distinct pe.Nombre,pe.Apellido,td.Detalle \"Tipo Identificacion\",pe.NroDocumento \"Nro de Identificacion\",pe.Mail,pe.Telefono, pe.FechaDeNacimiento \"Fecha de Nacimiento\",pa.Nombre Nacionalidad, pe.dirCalle \"Calle\",pe.dirNroCalle Numero, pe.dirPiso Piso, pe.dirDepto Dpto,pe.dirLocalidad Localidad, pa2.Nombre \"Pais del Domicilio\",hu.Habilitado,pe.idPersona from mmel.Persona pe, mmel.huesped,mmel.Pais pa, mmel.Pais pa2,mmel.Huesped hu, mmel.TipoDocumento td where pa.idPais = pe.idNacionalidad and pa2.idPais = dirIdPais and pe.idPersona = hu.idPersona and td.idTipoDocumento = pe.idTipoDocumento ");
            if (modo == 2) consultaBusqueda = consultaBusqueda + " and hu.Habilitado = 'S'";
            if (txtNombre.Text != "")
            {
                    consultaBusqueda = String.Format("{0} and pe.Nombre like '%{1}%'", consultaBusqueda,txtNombre.Text.ToUpper());
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaBusqueda,strCo);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.dgCustomer.DataSource = dataTable;
            label1.Text = String.Format("Cant resultados: {0}", dataTable.Rows.Count);      
            
        }
        private void buscar()
        {
            int i;
            if (txtNroId.Text != "" && !int.TryParse(txtNroId.Text, out i))
            {
                MessageBox.Show("Ingrese formato correcto de nro de identificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string consultaBusqueda = String.Format("select distinct pe.Nombre,pe.Apellido,td.Detalle \"Tipo Identificacion\",pe.NroDocumento \"Nro de Identificacion\",pe.Mail,pe.Telefono, pe.FechaDeNacimiento \"Fecha de Nacimiento\",pa.Nombre Nacionalidad, pe.dirCalle \"Calle\",pe.dirNroCalle Numero, pe.dirPiso Piso, pe.dirDepto Dpto,pe.dirLocalidad Localidad, pa2.Nombre \"Pais del Domicilio\",hu.Habilitado,pe.idPersona from mmel.Persona pe, mmel.huesped,mmel.Pais pa, mmel.Pais pa2,mmel.Huesped hu, mmel.TipoDocumento td where pa.idPais = pe.idNacionalidad and pa2.idPais = dirIdPais and pe.idPersona = hu.idPersona and td.idTipoDocumento = pe.idTipoDocumento ");
            if (modo == 2) consultaBusqueda = consultaBusqueda + " and hu.Habilitado = 'S'";
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
            this.dgCustomer.DataSource = dataTable;
            label1.Text = String.Format("Cant resultados: {0}", dataTable.Rows.Count);

        }


        private void dgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                /*string nombre,string apellido,string tipodoc,string nrodoc,string mail,string telefono,
            DateTime fechanac,string nacionalidad,string dircalle,int dirnrocalle,string pais,int dirpiso,
            string dirdepto,string dirlocalidad, string habilitado
            */
                if (e.RowIndex >=0 )
                {
                    DataGridViewRow row = this.dgCustomer.Rows[e.RowIndex];
                    int idPersona = Int32.Parse(row.Cells["idPersona"].Value.ToString());
                    string nombre = row.Cells["Nombre"].Value.ToString();
                    string apellido = row.Cells["Apellido"].Value.ToString();
                    string tipodoc = row.Cells["Tipo Identificacion"].Value.ToString();
                    string nrodoc = row.Cells["Nro de Identificacion"].Value.ToString();
                    string mail = row.Cells["Mail"].Value.ToString();
                    string telefono = row.Cells["Telefono"].Value.ToString();
                    DateTime fechanac = DateTime.Parse(row.Cells["Fecha de Nacimiento"].Value.ToString());
                    string nacionalidad = row.Cells["Nacionalidad"].Value.ToString();
                    string dircalle = row.Cells["Calle"].Value.ToString();
                    int dirnrocalle = Int32.Parse(row.Cells["Numero"].Value.ToString());
                    string pais = row.Cells["Pais del Domicilio"].Value.ToString();
                    int dirpiso = Int32.Parse(row.Cells["Piso"].Value.ToString());
                    string dirdepto = row.Cells["Dpto"].Value.ToString();
                    string dirloc = row.Cells["Localidad"].Value.ToString();
                    string habilitado = row.Cells["Habilitado"].Value.ToString();


                    DatosCliente dc = new DatosCliente(idPersona, nombre, apellido, tipodoc, nrodoc, mail, telefono, fechanac,
                        nacionalidad, dircalle, dirnrocalle, pais,
                        dirpiso, dirdepto,
                        dirloc, habilitado);

                    if (modo == 1)
                    {
                        ModificarCliente mc = new ModificarCliente(dc);
                        //  mc.Show();
                    }
                    else
                    {
                        BorrarCliente bc = new BorrarCliente(dc);
                        //bc.Show();
                    }


                    //StateMents you Want to execute to Get Data 
                }
            }
        }

        private void SeleccionCliente_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cliente c = new Cliente();
            c.Show();
        }
    }
    
}
