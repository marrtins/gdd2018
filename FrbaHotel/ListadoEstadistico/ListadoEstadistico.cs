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
using FrbaHotel.ListadoEstadistico.Model;

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
                this.top5Input.Items.Insert(3, "Habitaciones con mayor cantidad de dias que fueron ocupadas");
                this.top5Input.Items.Insert(4, "Habitaciones con mayor cantidad de veces que fueron ocupadas");
                this.top5Input.Items.Insert(5, "Cliente con mayor cantidad de puntos");
             
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
                            switch(top5){
                                case ("Hoteles con mayor cantidad de reservas canceladas"):
                                    this.obtenerTop5HotelesReservasCanceladas();
                                    break;
                                case ("Hoteles con mayor cantidad de consumibles facturados"):
                                    //this.ejectuarComando("MMEL.TOP5" + "_2", con);
                                    break;
                                case ("Hoteles con mayor cantidad de días fuera de servicio"):
                                    //this.ejectuarComando("MMEL.TOP5" + "_3", con);
                                    break;
                                case ("Habitaciones con mayor cantidad de dias que fueron ocupadas"):
                                    this.obtenerTop5HabitacionesReservadasDias();
                                    break;
                                case ("Habitaciones con mayor cantidad de veces que fueron ocupadas"):
                                    this.obtenerTop5HabitacionesReservadasVeces();
                                    break;
                                case ("Cliente con mayor cantidad de puntos"):
                                    this.obtenerTop5Clientes();
                                    break;
                            }

                            
                        }
                    }
                }
            }
        }

        private void obtenerTop5HotelesReservasCanceladas()
        {
            obtenerTop5De<HotelCantidades>("HotelesConMayorCantidadDeReservasCanceladas");
        }

        private void obtenerTop5Clientes()
        {
            obtenerTop5De<ClientePuntos>("[ClientesConMayorCantidadDePuntos]");

           dataGridView1.Columns["idPersona"].Visible = false; // las columnas se autogeneran por los atributos de ClientePuntos, pero esa no la quiero ver
        }

        private void obtenerTop5HabitacionesReservadasVeces()
        {
            obtenerTop5De<HabitacionCantidades>("[HabitacionesConMayorCantidadDeVecesOcupadas]");
        }

        private void obtenerTop5HabitacionesReservadasDias()
        {
            obtenerTop5De<HabitacionCantidades>("[HabitacionesConMayorCantidadDeDiasOcupadas]");
        }


        private void obtenerTop5De<T>(string procedureName) where T : new()
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL." + procedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@anio", SqlDbType.Int).Value = this.añoInput.Text;
                    cmd.Parameters.AddWithValue("@trimestre", SqlDbType.Int).Value = this.trimestreInput.Text[0].ToString();

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var resultados = dr.MapToList<T>();

                    dataGridView1.DataSource = new BindingList<T>(resultados);
                }
            }
        }
    }  
}
