using FrbaHotel.AbmCliente;
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

        private void button2_Click(object sender, EventArgs e)
        {
            AbmHotel.Listado abm = new AbmHotel.Listado();
            abm.ShowDialog();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login.Login l = new Login.Login();
            l.ShowDialog();
            this.Hide();
        }
    }
}
