using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Login.Model;
using FrbaHotel.Utilities;
using Rubberduck.Winforms;
using System.Configuration;
using System.Data.SqlClient;


namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();

            if(this.trimestreInput.Items.Count == 0)
            {
                this.trimestreInput.Items.Insert(0, "1ºTrimestre (1º de Enero ~ 31 de Marzo)");
                this.trimestreInput.Items.Insert(1, "2ºTrimestre (1º de Abril ~ 30 de Junio)");
                this.trimestreInput.Items.Insert(2, "3ºTrimestre (1º de Julio ~ 30 de Septiembre)");
                this.trimestreInput.Items.Insert(3, "4ºTrimestre (1º de Octubre ~ 31 de Diciembre)");
            }


            if (this.top5Input.Items.Count == 0 )
            {
                this.top5Input.Items.Insert(0, "Hoteles con mayor cantidad de reservas canceladas");
                this.top5Input.Items.Insert(1, "Hoteles con mayor cantidad de consumibles facturados");
                this.top5Input.Items.Insert(2, "Hoteles con mayor cantidad de días fuera de servicio");
                this.top5Input.Items.Insert(3, "Habitaciones con mayor cantidad de días y veces que fueron ocupadas");
                this.top5Input.Items.Insert(4, "Cliente con mayor cantidad de puntos");
             
            }
        }

        private void filtrarBtn_Click(object sender, EventArgs e)
        {  
            if ( this.top5Input.Text.Trim() != "")
            {
                if ( this.trimestreInput.Text.Trim() != "")
                {
                    if ( this.añoInput.Text.Trim() != "")
                    {
                        var top5 = this.top5Input.Text;
                        
                        var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(connection))
                        {
                            MessageBox.Show(this.top5Input.Text.Trim());
                            switch(top5){
                                case ("Hoteles con mayor cantidad de reservas canceladas"):
                                    this.ejectuarComando("MMEL.TOP5" + "_1", con);
                                    break;
                                case ("Hoteles con mayor cantidad de consumibles facturados"):
                                    this.ejectuarComando("MMEL.TOP5" + "_2", con);
                                    break;
                                case ("Hoteles con mayor cantidad de días fuera de servicio"):
                                    this.ejectuarComando("MMEL.TOP5" + "_3", con);
                                    break;
                                case ("Habitaciones con mayor cantidad de días y veces que fueron ocupadas"):
                                    this.ejectuarComando("MMEL.TOP5" + "_4", con);
                                    break;
                                case ("Cliente con mayor cantidad de puntos"):
                                    this.ejectuarComando("MMEL.TOP5" + "_5", con);
                                    break;
                                default:
                                    
                                    break;
                            }

                            
                        }
                    }
                }
            }
        }
        private void ejectuarComando(string procedure, SqlConnection con)
        {  
            
            using (SqlCommand cmd = new SqlCommand(procedure, con))
            {
                cmd.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = this.añoInput.Text;
                cmd.Parameters.AddWithValue("@Trimestre", SqlDbType.NVarChar).Value = this.trimestreInput.Text;
                

                con.Open();
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    mostarResultados(dr,cmd);
                }
                else
                {
                    MessageBox.Show("No existe top 5");
                }
            }
        }

        public void mostarResultados(SqlDataReader dr,SqlCommand procedure)
        {
            DataGridViewHelper.fill(procedure, dataGridView1);
        }
    }
   
}
