using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();

        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SeleccionCliente sc = new SeleccionCliente();
            sc.ShowDialog();
            
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BorrarCliente bc = new BorrarCliente();
            bc.ShowDialog();
            
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            AltaCliente ac = new AltaCliente();
            ac.ShowDialog();
            
        }
    }
}
