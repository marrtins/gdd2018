using FrbaHotel.Facturar;
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
    public partial class VerConsumibles : Form
    {
       
        int idEstadia;
        int codRes;
        Form formvolver;
        public VerConsumibles(int idEstadia,Form formVolver,int codRes)
        {
            this.idEstadia = idEstadia;
            this.codRes = codRes;
            this.formvolver = formVolver;
            InitializeComponent();
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Accion";

            bcol.Text = "Quitar Consumible";
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(bcol);
            lblCons.Text = lblCons.Text + String.Format(" {0}", codRes);
            cargarConsumibles();
        }

        private void VerConsumibles_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                                
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                int idCPE = Int32.Parse(row.Cells["idCPE"].Value.ToString());

                string consultaBusqueda = String.Format("delete from mmel.ConsumiblePorEstadia where idCPE={0}",idCPE);
                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);
                SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
                con.Open();
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();

                MessageBox.Show("Consumible eliminado");
                //row.Visible = false;
                cargarConsumibles();


            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            formvolver.Show();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

            existeFactura();
            
        }

        private void cargarConsumibles()
        {
            string consultaBusqueda = String.Format("select Nombre,Costo,c1.idConsumible,c1.idCPE from mmel.ConsumiblePorEstadia c1,mmel.Consumible c2 where c1.idEstadia={0} and c1.idConsumible=c2.idConsumible",idEstadia);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaBusqueda, strCo);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.dataGridView1.DataSource = dataTable;
            int cant = dataTable.Rows.Count;
            lblCant.Text = String.Format("Cant consumibles: {0}", cant);
        }
    
    private void existeFactura()
    {
        string consultaBusqueda = String.Format("select * from mmel.Facturacion  where idEstadia = {0}",idEstadia);
        string strCo = ConfigurationManager.AppSettings["stringConexion"];
        SqlConnection con = new SqlConnection(strCo);
        SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
        con.Open();
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        SqlDataReader reader = cmd.ExecuteReader();
        

        if (reader.HasRows)
        {
                int idFactura,FactTotal,NroFactura;
                DateTime FacturaFecha;
                while (reader.Read())
                {
                    idFactura = Int32.Parse(reader["idFactura"].ToString());
                    FactTotal = Int32.Parse(reader["FactTotal"].ToString());
                    NroFactura = Int32.Parse(reader["NroFactura"].ToString());
                    FacturaFecha = DateTime.Parse(reader["FacturaFecha"].ToString());
                    this.Hide();
                    FacturaExistente fe = new FacturaExistente(idFactura, FactTotal, NroFactura, FacturaFecha, idEstadia);
                    
                    fe.Show();
                    return;

                }
                reader.Close();
                con.Close();              
        }
        else
        {
                NuevaFactura nf = new NuevaFactura(idEstadia);
                nf.Show();
                this.Hide();
        }
            
        }
    }
}
