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
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();
            //verificar si el cliente esta habilitado. si no lo esta, se habilita el boton para hacerlo.
            //caso contrario no ya q se deshabliita desde borrar cliente.
            if (this.clienteNoHabilitado())
            {
                groupClienteNoHabilitado.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {

        }

        private void lblClienteHabilitado_Click(object sender, EventArgs e)
        {

        }
        private bool clienteNoHabilitado()
        {
            return false;
        }
    }
}
