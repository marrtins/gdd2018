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
        public SeleccionCliente()
        {
            

            InitializeComponent();
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Button Column ";
            bcol.Text = "Click Me";
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dgCustomer.Columns.Add(bcol);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
                
            string consultaBusqueda = String.Format("select distinct pe.Nombre,pe.Apellido,pe.TipoDocumento \"Tipo Identificacion\",pe.NroDocumento \"Nro de Identificacion\",pe.Mail,pe.Telefono, pe.FechaDeNacimiento \"Fecha de Nacimiento\", pa.Nombre Nacionalidad, pe.dirCalle \"Calle\",pe.dirNroCalle Numero, pe.dirPiso Piso, pe.dirDepto Dpto, pe.dirLocalidad Localidad,pa2.Nombre \"Pais del Domicilio\",hu.Habilitado  from mmel.Persona pe, mmel.huesped,mmel.Pais pa, mmel.Pais pa2,mmel.Huesped  hu where pa.idPais = pe.idNacionalidad and pa2.idPais = dirIdPais and pe.idPersona=hu.idPersona");
            if (txtNombre.Text != "")
            {
                    consultaBusqueda = String.Format("{0} and pe.Nombre like '%{1}%'", consultaBusqueda,txtNombre.Text.ToUpper());
             }
            if (txtApellido.Text != "")
            {
                    consultaBusqueda = String.Format("{0} and pe.Apellido like '%{1}%'", consultaBusqueda, txtApellido.Text.ToUpper());
                
            }
            if (comboBox1.Text != "Seleccionar")
            {
                    
                    consultaBusqueda = String.Format("{0} and pe.TipoDocumento like '{1}'", consultaBusqueda, comboBox1.Text);
                
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



        private void dgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                /*string nombre,string apellido,string tipodoc,string nrodoc,string mail,string telefono,
            DateTime fechanac,string nacionalidad,string dircalle,int dirnrocalle,string pais,int dirpiso,
            string dirdepto,string dirlocalidad, string habilitado
            */
                DataGridViewRow row = this.dgCustomer.Rows[e.RowIndex];
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




                ModificarCliente mc = new ModificarCliente(nombre, apellido, tipodoc, nrodoc, mail,telefono, fechanac,
                    nacionalidad, dircalle, dirnrocalle, pais,
                    dirpiso, dirdepto,
                    dirloc, habilitado);
                mc.Show();


                
                //StateMents you Want to execute to Get Data 
            }
        }

    }
    
}
