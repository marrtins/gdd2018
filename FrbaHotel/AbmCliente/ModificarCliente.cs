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
        

        private string nombre;
        private string apellido;
        private string tipodoc;
        private string nrodoc;
        private string mail;
        private DateTime fechanac;
        private string nacionalidad;
        private string dircalle;
        private int dirnrocalle;
        private string pais;
        private int dirpiso;
        private string dirdepto;
        private string dirloc;
        private string habilitado;

        

        public ModificarCliente(string nombre, string apellido, string tipodoc, string nrodoc, string mail,string telefono, DateTime fechanac, string nacionalidad, string dircalle, int dirnrocalle, string pais, int dirpiso, string dirdepto, string dirloc, string habilitado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.tipodoc = tipodoc;
            this.nrodoc = nrodoc;
            this.mail = mail;
            this.fechanac = fechanac;
            this.nacionalidad = nacionalidad;
            this.dircalle = dircalle;
            this.dirnrocalle = dirnrocalle;
            this.pais = pais;
            this.dirpiso = dirpiso;
            this.dirdepto = dirdepto;
            this.dirloc = dirloc;
            this.habilitado = habilitado;
            InitializeComponent();
            if (habilitado.Equals("N"))
            {
                groupClienteNoHabilitado.Visible = true;
            }
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            cboTipoId.Text = tipodoc; //todo
            txtNroID.Text = nrodoc;
            txtEmail.Text = mail;
            txtTel.Text = telefono;
            dateTimePicker1.Value = fechanac;
            txtNacionalidad.Text = nacionalidad;
            txtCalle.Text = dircalle;
            txtNro.Text = dirnrocalle.ToString();
            txtPais.Text = pais;
            txtPiso.Text = dirpiso.ToString();
            txtDepto2.Text = dirdepto;
            txtLocalidad.Text = dirloc;

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
       
    }
}
