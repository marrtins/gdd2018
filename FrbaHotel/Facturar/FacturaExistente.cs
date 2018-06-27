using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Facturar
{
    public partial class FacturaExistente : Form
    {
        int idFactura; int FactTotal; int NroFactura; int idEstadia;
        DateTime FacturaFecha;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public FacturaExistente(int idFactura, int FactTotal, int NroFactura, DateTime FacturaFecha,int idEstadia)
        {
            this.idFactura = idFactura;
            this.FactTotal = FactTotal;
            this.NroFactura = NroFactura;
            this.FacturaFecha = FacturaFecha;
            this.idEstadia = idEstadia;
            InitializeComponent();
            cargarFacturaVieja();

        }

        private void FacturaExistente_Load(object sender, EventArgs e)
        {

        }
        private void cargarFacturaVieja()
        {

        }
    }
}
