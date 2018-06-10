using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class Habitacion : Form
    {
        public Habitacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaHabitacion alta = new AltaHabitacion();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificarHabitacion modificar = new ModificarHabitacion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BajaHabitacion baja = new BajaHabitacion();
        }
    }
}
