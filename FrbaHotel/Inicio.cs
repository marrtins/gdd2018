using FrbaHotel.AbmCliente;
using FrbaHotel.AbmRol.Model;
using FrbaHotel.AbmUsuario;
using FrbaHotel.CancelarReserva;
using FrbaHotel.GenerarModificacionReserva;
using FrbaHotel.RegistrarConsumible;
using FrbaHotel.RegistrarEstadia;
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

namespace FrbaHotel
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.SetupSecurity();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente abm = new Cliente();
            abm.ShowDialog();
            this.Hide();
        }


       

        private void abmHotelBtn_Click(object sender, EventArgs e)
        {
            AbmHotel.Listado abm = new AbmHotel.Listado();
            abm.ShowDialog();
            this.Hide();
        }

        private void rolButton_Click(object sender, EventArgs e)
        {
            AbmRol.Listado abm = new AbmRol.Listado();
            abm.ShowDialog();
            this.Hide();
        }

        private void buttonHabitacion_Click(object sender, EventArgs e)
        {
            AbmHabitacion.InicioHabitacion abm = new AbmHabitacion.InicioHabitacion();
            abm.ShowDialog();
            this.Hide();
        }

        private void buttonListadoEstadistico_Click(object sender, EventArgs e)
        {
           
            ListadoEstadistico.ListadoEstadistico listado = new ListadoEstadistico.ListadoEstadistico();
            listado.ShowDialog();
            this.Hide();
        }
        
        private void SetupSecurity()
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.FuncionalidadesDeRol", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", SqlDbType.Int).Value = LoginData.Rol.idRol;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaF = dr.MapToList<Funcionalidad>();
                    var buttonsList = this.Controls.OfType<Button>().ToList();

                    buttonsList.ForEach(b =>
                    {
                        b.Enabled = listaF.Any(f => String.Equals(f.Codigo + "Btn", b.Name));
                    });
 
                }
            }
        }

        private void abmUsuarioBtn_Click(object sender, EventArgs e)
        {
            /*AbmUsuario.ListadoUsuarios usuarios = new AbmUsuario.ListadoUsuarios();
            usuarios.ShowDialog();*/
            MainAbmUsuario mau = new MainAbmUsuario();
            mau.Show();
            this.Hide();
        }

        private void btnGenRes_Click(object sender, EventArgs e)
        {
            GenModReserva gmr = new GenModReserva();
            gmr.Show();
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MainCancelReserva mcr = new MainCancelReserva();
            mcr.Show();
            this.Hide();

        }

        private void btnEstadia_Click(object sender, EventArgs e)
        {
            MainRegEstadia mre = new MainRegEstadia();
            mre.Show();
            this.Hide();
        }

        private void btnConsumible_Click(object sender, EventArgs e)
        {
            MainRegCons mrc = new MainRegCons(0);
            mrc.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
