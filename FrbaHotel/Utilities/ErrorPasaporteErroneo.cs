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

namespace FrbaHotel.Utilities
{
    public partial class ErrorPasaporteErroneo : Form
    {
        Form formToRet;
        string nroDoc;
        string mail;

        public ErrorPasaporteErroneo(string nroDoc,string mail,Form formToRet)
        {
            this.nroDoc = nroDoc;
            this.mail = mail;
            this.formToRet = formToRet;
            InitializeComponent();
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Accion";

            bcol.Text = "Seleccionar Cliente ";
            
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(bcol);
            llenarDataGrid();
        }

        private void ErrorPasaporteErroneo_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                /*string nombre,string apellido,string tipodoc,string nrodoc,string mail,string telefono,
            DateTime fechanac,string nacionalidad,string dircalle,int dirnrocalle,string pais,int dirpiso,
            string dirdepto,string dirlocalidad, string habilitado
            */
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                int idPersona = Int32.Parse(row.Cells["idPersona"].Value.ToString());
                
                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.resolverInconsistencia", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
               

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                MessageBox.Show(string.Format("Datos Actualizados"), "OK", MessageBoxButtons.OK);
                this.Hide();
                formToRet.Show();

            }
        }

        private void llenarDataGrid()
        {
            string consultaBusqueda = String.Format("select distinct p.idPersona,p.Mail,p.NroDocumento,FechaDeNacimiento,dirCalle Calle,dirNroCalle Nro,dirPiso Piso,dirDepto Depto  from mmel.PersonasInconsistentes pic,mmel.Persona p where (pic.Mail = '{0}' or pic.nroDocumento = {1} )and p.idPersona=pic.idPersona", this.mail,this.nroDoc);
            
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaBusqueda, strCo);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.dataGridView1.DataSource = dataTable;
            label1.Text = String.Format("Cant resultados: {0}", dataTable.Rows.Count);

        }

        
    }
}
