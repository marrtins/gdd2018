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
    public partial class BorrarCliente : Form
    {
        private DatosCliente datos;

        public BorrarCliente()
        {
            
        }

        public BorrarCliente(DatosCliente dc)
        {
            this.datos = dc;

            InitializeComponent();


            int aux = datos.esErroneo(datos.idPersona);

            if (aux == 1)
            {
                MailErroneo me = new MailErroneo(datos,2);
                me.Show();
            }
            else if (aux == 2)
            {
                //error de id y tipo repetidos
                PasaporteErroneo pe = new PasaporteErroneo(datos,2);
                pe.Show();
            }
            else if (aux == 0)
            {
                //todo ok 
                llenarCampos();
            }


        }

        private void llenarCampos()
        {
            lblNombre.Text = datos.nombre;
            lblTipoDoc.Text = datos.tipodoc.ToString();
            lblNroDoc.Text = datos.nrodoc;
            lblMail.Text = datos.mail;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
