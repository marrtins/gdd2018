using FrbaHotel.Utilities;
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
            cargarPaises();
            cargarTipoID();
            if (aux == 1)
            {
                this.Hide();
                //MailErroneo me = new MailErroneo(datos,1); 
                ErrorPasaporteErroneo epe = new ErrorPasaporteErroneo(nrodoc,mail,this);
                epe.Show();
                //me.Show();
                
            }
            else if (aux == 2)
            {
                //error de id y tipo repetidos
                this.Hide();
                //PasaporteErroneo pe = new PasaporteErroneo(datos,1); //1 x modificacion. 
                //pe.Show();
                ErrorPasaporteErroneo epe = new ErrorPasaporteErroneo(nrodoc, mail, this);
                epe.Show();


            }

            else if (aux == 0)
            {
                //todo ok 
                this.Show();
                llenarCampos();
            }

            llenarCampos();


        }


        
       private void llenarCampos()
        {
            if (habilitado.Equals("N"))
            {
                groupClienteNoHabilitado.Visible = true;
            }
            else
            {
                btnSi.Checked = true;
            }
            txtNombre.Text = this.nombre;
            txtApellido.Text = this.apellido;
            cboTipoId.Text = this.tipodoc; //todo
            txtNroID.Text = this.nrodoc;
            txtEmail.Text = this.mail;
            txtTel.Text = this.telefono;
            dateTimePicker1.Value = this.fechanac;
            cboNacionalidad.Text = this.nacionalidad;
            txtCalle.Text = this.dircalle;
            txtNro.Text = this.dirnrocalle.ToString();
            cboPais.Text = this.pais;
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
            llenarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (datosValidos())
            {

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.modificarCliente", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = this.idPersona;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtNombre.Text;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtApellido.Text;
                cmd.Parameters.Add("@tipoDocumento", SqlDbType.VarChar, 15).Value = cboTipoId.Text;
                cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 25).Value = txtNroID.Text;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 200).Value = txtEmail.Text;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = txtTel.Text;
                cmd.Parameters.Add("@fechaDeNacimiento", SqlDbType.Date).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 50).Value = cboNacionalidad.Text;
                cmd.Parameters.Add("@dirCalle", SqlDbType.VarChar, 150).Value = txtCalle.Text;
                cmd.Parameters.Add("@pais", SqlDbType.VarChar, 150).Value = cboPais.Text;
                cmd.Parameters.Add("@dirNroCalle", SqlDbType.Int).Value = txtNro.Text;
                cmd.Parameters.Add("@dirPiso", SqlDbType.SmallInt).Value = Int16.Parse(txtPiso.Text);
                cmd.Parameters.Add("@dirDepto", SqlDbType.Char, 2).Value = txtDepto2.Text;
                cmd.Parameters.Add("@dirLocalidad", SqlDbType.NVarChar, 150).Value = txtLocalidad.Text;
                if (btnSi.Checked)
                {
                    cmd.Parameters.Add("@habilitado", SqlDbType.Char, 1).Value = 'S';
                }
                else
                {
                    cmd.Parameters.Add("@habilitado", SqlDbType.Char, 1).Value = 'N';

                }
                
                cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->ok. 1->tipoynroid existe. 2->mail existe

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
                if (codigoRet == 0)
                {
                    MessageBox.Show(string.Format("Cliente modificado. id {0}", this.idPersona), "OK", MessageBoxButtons.OK);
                    this.Hide();
                }
                else if (codigoRet == 1)
                {
                    MessageBox.Show("Cliente no modificado. El tipo y nro de identificacion ya existe", "X", MessageBoxButtons.OK);

                }
                else if (codigoRet == 2)
                {
                    MessageBox.Show("Cliente no modificado. El mail ya existe", "X", MessageBoxButtons.OK);

                }
                

            }
        }
        private bool datosValidos()
        {
            int i;
            if (txtNombre.Text == "") { MessageBox.Show("Falta completar el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtApellido.Text == "") { MessageBox.Show("Falta completar el apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboTipoId.Text == "Seleccionar") { MessageBox.Show("Falta completar el tipo de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNroID.Text == "" || !int.TryParse(txtNroID.Text, out i)) { MessageBox.Show("Error en el campo de numero de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtEmail.Text == "") { MessageBox.Show("Falta completar el mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtTel.Text == "" || !int.TryParse(txtTel.Text, out i)) { MessageBox.Show("Error en el campo telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtCalle.Text == "") { MessageBox.Show("Falta completar la calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNro.Text == "" || !int.TryParse(txtNro.Text, out i)) { MessageBox.Show("Error en el campo de numero de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtPiso.Text == "") { MessageBox.Show("Falta completar el piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtDepto2.Text == "") { MessageBox.Show("Falta completar el dpto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtLocalidad.Text == "") { MessageBox.Show("Falta completar localidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboNacionalidad.Text == "Seleccionar") { MessageBox.Show("Falta completar nacionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboPais.Text == "Seleccionar") { MessageBox.Show("Falta completar pais del domicilio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            return true;



        }




        private void cargarTipoID()
        {


            string consultaBusqueda = String.Format("select distinct * from mmel.TipoDocumento ");
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string tipo = (reader["detalle"].ToString());
                cboTipoId.Items.Add(tipo);

            }
            reader.Close();
            con.Close();
            cboTipoId.Items.Add("Otro");



        }

        private void cargarPaises()
        {


            string consultaBusqueda = String.Format("select distinct * from mmel.Pais ");
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string tipo = (reader["Nombre"].ToString());
                cboPais.Items.Add(tipo);
                cboNacionalidad.Items.Add(tipo);

            }
            reader.Close();
            con.Close();
            cboPais.Items.Add("Otro");
            cboNacionalidad.Items.Add("Otro");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
