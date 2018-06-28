using FrbaHotel.AbmCliente;
using FrbaHotel.CancelarReserva;
using FrbaHotel.GenerarModificacionReserva;
using FrbaHotel.RegistrarConsumible;
using FrbaHotel.RegistrarEstadia;
using FrbaHotel.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (LoginData.IdUsuario == 3)
            {
                btnEstadia.Visible = false;
                btnConsumible.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente abm = new Cliente();
            abm.ShowDialog();
            this.Hide();
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            //permisos
            this.abmHotelBtn.Visible = LoginData.EsAdmin;
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

        private void abmUsuarioBtn_Click(object sender, EventArgs e)
        {
            AbmUsuario.ListadoUsuarios usuarios = new AbmUsuario.ListadoUsuarios();
            usuarios.ShowDialog();
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
            MainRegCons mrc = new MainRegCons();
            mrc.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
