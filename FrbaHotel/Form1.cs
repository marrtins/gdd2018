using FrbaHotel.AbmCliente;
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
    }
}
