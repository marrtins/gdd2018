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
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
            dtFNac.Value = DateTime.Now.AddDays(1);
            //agregar tipos de identificacion al cbo 
            cboTipo.Items.Add("DNI");
            cboTipo.Items.Add("Pasaporte");

        }


        private void btnCliente_Click(object sender, EventArgs e)
        {
            if (validarAltaCliente())
            {
                //crear cliente
                MessageBox.Show("Cliente creado satisfactoriamente");
            }
        }

        private bool validarAltaCliente()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Completar Nombre del cliente");
                return false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Completar Apellido del cliente");
                return false;
            }
            if (cboTipo.Text == "Seleccionar")
            {
                MessageBox.Show("Seleccionar tipo de identificación");
                return false;
            }
            if (string.IsNullOrEmpty(txtNroId.Text))
            {
                MessageBox.Show("Completar número de identificación");
                //validar tipo y nro de identificacion unicos
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Completar Email");
                //validar email unico
                return false;
            }
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("Completar Telefono");
                return false;
            }
            if (string.IsNullOrEmpty(txtCalle.Text))
            {
                MessageBox.Show("Completar Calle");
                return false;
            }
            if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("Completar Localidad");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                MessageBox.Show("Completar País");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                MessageBox.Show("Completar Nacionalidad");
                return false;
            }
            if(dtFNac.Value== DateTime.Now.AddDays(1))
            {
                MessageBox.Show("Completar Fecha de Nacimiento");
                return false;
            }

            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            cboTipo.Text = "Seleccionar";
            txtNroId.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtCalle.Text = "";
            txtLocalidad.Text = "";
            txtPais.Text = "";
            txtNacionalidad.Text = "";
            dtFNac.Value = DateTime.Now.AddDays(1);
        }


    }
}
