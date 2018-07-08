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
    public partial class ListadoEstadistico : ModelBoundForm
    {
        public ListadoEstadistico()
            :base(new Top5Filtros())
        {
            InitializeComponent();
            this.trimestreInput.Items.Add("1ºTrimestre (1º de Enero ~ 31 de Marzo)");
            this.trimestreInput.Items.Add("2ºTrimestre (1º de Abril ~ 30 de Junio)");
            this.trimestreInput.Items.Add("3ºTrimestre (1º de Julio ~ 30 de Septiembre)");
            this.trimestreInput.Items.Add("4ºTrimestre (1º de Octubre ~ 31 de Diciembre)");

            this.top5Input.Items.Insert(0, "Hoteles con mayor cantidad de reservas canceladas");
            this.top5Input.Items.Insert(1, "Hoteles con mayor cantidad de consumibles facturados");
            this.top5Input.Items.Insert(2, "Hoteles con mayor cantidad de días fuera de servicio");
            this.top5Input.Items.Insert(3, "Habitaciones con mayor cantidad de dias que fueron ocupadas");
            this.top5Input.Items.Insert(4, "Habitaciones con mayor cantidad de veces que fueron ocupadas");
            this.top5Input.Items.Insert(5, "Cliente con mayor cantidad de puntos");

            RegistrarInputs();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void RegistrarInputs()
        {
            trimestreInput.DataBindings.Add(new TextBinding(this.Model, "Trimestre"));
            Register(ErrorLabel.For(trimestreInput, Alignment.Bottom, 2));


            top5Input.DataBindings.Add(new TextBinding(this.Model, "Top5De"));
            Register(ErrorLabel.For(top5Input, Alignment.Bottom, 2));


            dateTimePicker1.DataBindings.Add(new TextBinding(this.Model, "Anio"));
            Register(ErrorLabel.For(dateTimePicker1, Alignment.Bottom, 2));

        }

        private void filtrarBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            var filtros = (Top5Filtros)this.Model;


            var top5 = filtros.Top5De;

            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                switch (top5)
                {
                    case ("Hoteles con mayor cantidad de reservas canceladas"):
                        this.obtenerTop5HotelesReservasCanceladas();
                        break;
                    case ("Hoteles con mayor cantidad de consumibles facturados"):
                        this.obtenerTop5HotelesConsumiblesFacturados();
                        break;
                    case ("Hoteles con mayor cantidad de días fuera de servicio"):
                        this.obtenerTop5HotelesFueraServicio();
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

        private void obtenerTop5HotelesReservasCanceladas()
        {
            obtenerTop5De<HotelCantidades>("HotelesConMayorCantidadDeReservasCanceladas");
        }

        private void obtenerTop5HotelesFueraServicio()
        {
            obtenerTop5De<HotelCantidades>("HotelesConMayorCantidadDeDiasFueraDeServicio");
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

        private void obtenerTop5HotelesConsumiblesFacturados()
        {
            obtenerTop5De<HotelCantidades>("HotelesConMayorCantidadDeConsumiblesFacturados");
        }

        private void obtenerTop5De<T>(string procedureName) where T : new()
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;
            var filtros = (Top5Filtros)this.Model;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL." + procedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@anio", SqlDbType.Int).Value = filtros.Anio;
                    cmd.Parameters.AddWithValue("@trimestre", SqlDbType.Int).Value = filtros.Trimestre[0].ToString();

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var resultados = dr.MapToList<T>();

                    dataGridView1.DataSource = new BindingList<T>(resultados);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }  
}
