using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class ModificarCliente : Form
    {

        private int idPersona;
        private string nombre;
        private string apellido;
        private string tipodoc;
        private string nrodoc;
        private string mail;
        private string telefono;
        private DateTime fechanac;
        private string nacionalidad;
        private string dircalle;
        private int dirnrocalle;
        private string pais;
        private int dirpiso;
        private string dirdepto;
        private string dirloc;
        private string habilitado;

        

        public ModificarCliente(DatosCliente datos)
        {

            
            this.idPersona = datos.idPersona;
            this.nombre = datos.nombre;
            this.apellido = datos.apellido;
            this.tipodoc = datos.tipodoc;
            this.nrodoc = datos.nrodoc;
            this.mail = datos.mail;
            this.fechanac = datos.fechanac;
            this.nacionalidad = datos.nacionalidad;
            this.dircalle = datos.dircalle;
            this.dirnrocalle = datos.dirnrocalle;
            this.pais = datos.pais;
            this.dirpiso = datos.dirpiso;
            this.dirdepto = datos.dirdepto;
            this.dirloc = datos.dirloc;
            this.habilitado = datos.habilitado;
            this.telefono = datos.telefono;
            
            int aux = datos.esErroneo(idPersona);
            InitializeComponent();
            if (aux == 1)
            {
                this.Hide();
                MailErroneo me = new MailErroneo(datos,1); 
                me.Show();
                
            }
            else if (aux == 2)
            {
                //error de id y tipo repetidos
                this.Hide();
                PasaporteErroneo pe = new PasaporteErroneo(datos,1); //1 x modificacion. 
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
            if (habilitado.Equals("N"))
            {
                groupClienteNoHabilitado.Visible = true;
            }
            txtNombre.Text = this.nombre;
            txtApellido.Text = this.apellido;
            cboTipoId.Text = this.tipodoc; //todo
            txtNroID.Text = this.nrodoc;
            txtEmail.Text = this.mail;
            txtTel.Text = this.telefono;
            dateTimePicker1.Value = this.fechanac;
            txtNacionalidad.Text = this.nacionalidad;
            txtCalle.Text = this.dircalle;
            txtNro.Text = this.dirnrocalle.ToString();
            txtPais.Text = this.pais;
            txtPiso.Text = this.dirpiso.ToString();
            txtDepto2.Text = this.dirdepto;
            txtLocalidad.Text = this.dirloc;
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

        private void Limpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
