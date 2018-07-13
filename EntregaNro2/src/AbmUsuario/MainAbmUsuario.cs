using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class MainAbmUsuario : Form
    {
        public MainAbmUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();

        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            AltaUsuario au = new AltaUsuario();
            au.Show();
            this.Hide();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SeleccUser su = new SeleccUser(1);
            su.Show();
            this.Hide();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            SeleccUser su = new SeleccUser(2);
            su.Show();
            this.Hide();
        }
    }
}
