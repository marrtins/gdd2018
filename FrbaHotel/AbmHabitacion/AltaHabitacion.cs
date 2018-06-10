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
    public partial class AltaHabitacion : Form
    {
        private DialogResult result;

        public DialogResult Result { get => result; set => result = value; }

        public AltaHabitacion()
        {
            InitializeComponent();
        }
    }
}
