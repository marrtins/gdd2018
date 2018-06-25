using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ModificarReserva : Form
    {
        private int idHotel;
        private Reserva res;




        public ModificarReserva(Reserva res)
        {
            this.res = res;
            InitializeComponent();
            btnModificar.Enabled = false;
            //cboHotel.Text = getNombreHotel(res.idHotel);
        }

        private void ModificarReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
