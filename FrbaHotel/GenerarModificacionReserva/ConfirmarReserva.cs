using FrbaHotel.AbmCliente;
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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ConfirmarReserva : Form
    {
        private DateTime dtDesde;
        private DateTime dtHasta;
        private string hotel;
        private string tipohab;
        private string regimen;
        private float precio;
        private int idCliente;
        private int idPersona;

        public ConfirmarReserva()
        {
            


        }

        public ConfirmarReserva(DateTime dtDesde, DateTime dtHasta, string hotel, string tipohab, string regimen, float precio)
        {
            this.dtDesde = dtDesde;
            this.dtHasta = dtHasta;
            this.hotel = hotel;
            this.tipohab = tipohab;
            this.regimen = regimen;
            this.precio = precio;

            InitializeComponent();
            lblDesde.Text = dtDesde.ToString();
            lblHasta.Text = dtHasta.ToString();
            lblHotel.Text = hotel;
            lblHab.Text = tipohab;
            lblReg.Text = regimen;
            float total = (precio * ((dtHasta- dtDesde)).Days);
            lblTot.Text = total.ToString();
            optNuevo.Checked = true;
            grpIdentificarse.Visible = false;
            grMain.Visible = true;
            grNuevoCliente.Visible = true;

            cboidtipo.Text="Seleccionar";
            cboTipoIdNuevo.Text = "Seleccionar";
            cboPaisDirNuevo.Text = "Seleccionar";
            cboNacionalidadNuevo.Text = "Seleccionar";



            cboidtipo.Items.Add("Seleccionar");
            cboTipoIdNuevo.Items.Add("Seleccionar");
            cboPaisDirNuevo.Items.Add("Seleccionar");
            cboNacionalidadNuevo.Items.Add("Seleccionar");
            cargarPaises();
            cargarTipoID();





        }

        public ConfirmarReserva(int idPersona)
        {
            this.idPersona = idPersona;
            if (idPersona != -1) idCliente = idPersona;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmarReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (optNuevo.Checked)
            {
                if (crearCliente())
                {
                    realizarReserva();
                }
            }
            else
            {
                if(txtidnro.Text=="" && txtidmail.Text == "")
                {
                    MessageBox.Show("Faltan completar datos para identificar", "Error", MessageBoxButtons.OK);
                }
                else if((txtidnro.Text != "" && cboidtipo.Text!="")||(txtidmail.Text!=""))                 
                {
                    if(txtidnro.Text!="" && cboidtipo.Text != "")
                    {

                        if (consultarUsuarioExistenteIdentificacion())
                        {
                            realizarReserva();
                        }
                        else
                        {
                            
                        }

                    }
                    else if(txtidmail.Text!="")
                    {
                        if (consultarUsuarioExistenteMail())
                        {
                            realizarReserva();
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Campos de identificacion incompletos");
                    }
                }
            }

        }
        private bool consultarUsuarioExistenteIdentificacion()
        {
            string consultaBusqueda = String.Format("select idPersona,Nombre,Apellido,Mail,NroDocumento from mmel.Persona p, mmel.TipoDocumento td where p.NroDocumento={0} and td.idTipoDocumento=p.idTipoDocumento and td.detalle='{1}'", txtidnro.Text, cboidtipo.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            int aux = 0;
            string nombre="";
            string apellido = "";
            string mail = "";
            string nro = "";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   idCliente = Int32.Parse(reader["idPersona"].ToString());
                    nombre = (reader["Nombre"].ToString());
                    apellido = (reader["Apellido"].ToString());
                    mail = (reader["Mail"].ToString());
                    nro = (reader["NroDocumento"].ToString());
                    aux++;
                }
                reader.Close();
                con.Close();
                if (aux > 1)
                {
                    
                    PasaporteErroneoReserva per = new PasaporteErroneoReserva(idCliente, nombre, apellido, nro, mail,this);
                    per.Show();
                    this.Hide();
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("No hay usuario registrado con ese tipo y nro de identifiacion");
                return false;
            }
            return true;
        }


        private bool consultarUsuarioExistenteMail()
        {
            string consultaBusqueda = String.Format("select idPersona,Nombre,Apellido,Mail,NroDocumento from mmel.Persona p where p.Mail='{0}' ", txtidmail.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            int aux = 0;
            string nombre = "";
            string apellido = "";
            string mail = "";
            string idNro = "";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idCliente = Int32.Parse(reader["idPersona"].ToString());
                    nombre = (reader["Nombre"].ToString());
                    apellido = (reader["Apellido"].ToString());
                    mail = (reader["Mail"].ToString());
                    idNro= (reader["NroDocumento"].ToString());
                    aux++;
                }
                reader.Close();
                con.Close();
                if (aux > 1)
                {
                    MailErroneoReserva per = new MailErroneoReserva(idCliente, nombre, apellido, idNro, mail,this);
                    per.Show();
                    this.Hide();
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("No hay usuario registrado con ese mail");
                return false;
            }
            return true;
        }


        private void realizarReserva()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.reservar", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fechaDesde", SqlDbType.Date).Value = dtDesde;
            cmd.Parameters.Add("@fechaHasta", SqlDbType.Date).Value = dtHasta;
            cmd.Parameters.Add("@fechaDeReserva", SqlDbType.Date).Value = DateTime.Today;//cambairrrrrrrrrrrrrrrr
            cmd.Parameters.Add("@idUsuarioQueReserva", SqlDbType.Int).Value = 1; //cambiaaaaaaaaaaaaaaaaaaaaaar
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = 1; //cambiaaaaaaaaaaaaaaaaaaaaaar
            cmd.Parameters.Add("@tipoHabDesc", SqlDbType.VarChar, 100).Value = tipohab;
            cmd.Parameters.Add("@tipoRegimenDesc", SqlDbType.VarChar, 100).Value = regimen;
            cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = idCliente;
            
            cmd.Parameters.Add("@codReserva", SqlDbType.Int).Direction = ParameterDirection.Output;
            

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int codigoReserva = int.Parse(cmd.Parameters["@codReserva"].Value.ToString());
            MessageBox.Show(string.Format("Reserva Concretada. Codigo: {0}", codigoReserva), "OK", MessageBoxButtons.OK);

            this.Hide();
            GenModReserva gmr = new GenModReserva();
            gmr.Show();
        
            
        }


        private void lblHab_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void optRegis_CheckedChanged(object sender, EventArgs e)
        {
            if (optRegis.Checked)
            {

                grpIdentificarse.Visible = true;
                grNuevoCliente.Visible = false;
            }
            
            
        }

        private void optNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (optNuevo.Checked)
            {
                {
                    grpIdentificarse.Visible = false;
                    grNuevoCliente.Visible = true;
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            
        }


        private bool crearCliente()
        {
            if (datosValidosCrear())
            {



                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.AgregarCliente", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtNombre.Text;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtApellido.Text;
                cmd.Parameters.Add("@tipoDocumento", SqlDbType.VarChar, 15).Value = cboTipoIdNuevo.Text;
                cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 25).Value = txtNroId.Text;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 200).Value = txtEmail.Text;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = txtTel.Text;
                cmd.Parameters.Add("@fechaDeNacimiento", SqlDbType.Date).Value = dtfn2.Value;
                cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 50).Value = cboNacionalidadNuevo.Text;
                cmd.Parameters.Add("@dirCalle", SqlDbType.VarChar, 150).Value = txtCalle.Text;
                cmd.Parameters.Add("@pais", SqlDbType.VarChar, 150).Value = cboPaisDirNuevo.Text;
                cmd.Parameters.Add("@dirNroCalle", SqlDbType.Int).Value = txtNroCalle.Text;
                cmd.Parameters.Add("@dirPiso", SqlDbType.SmallInt).Value = Int16.Parse(txtPiso.Text);
                cmd.Parameters.Add("@dirDepto", SqlDbType.Char, 2).Value = txtDepto.Text;
                cmd.Parameters.Add("@dirLocalidad", SqlDbType.NVarChar, 150).Value = txtLocalidad.Text;

                cmd.Parameters.Add("@habilitado", SqlDbType.Char, 1).Value = 'S';

                cmd.Parameters.Add("@idNuevo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->ok. 1->tipoynroid existe. 2->mail existe

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
                idCliente = int.Parse(cmd.Parameters["@idNuevo"].Value.ToString());
                if (codigoRet == 0)
                {
                    MessageBox.Show(string.Format("Cliente creado. id {0}", idCliente), "OK", MessageBoxButtons.OK);
                    
                    return true;
                }
                else if (codigoRet == 1)
                {
                    MessageBox.Show("Cliente no creado. El tipo y nro de identificacion ya existe", "X", MessageBoxButtons.OK);
                    return false;

                }
                else if (codigoRet == 2)
                {
                    MessageBox.Show("Cliente no creado. El mail ya existe", "X", MessageBoxButtons.OK);
                    return false;

                }
                return false;
            }
            return false;
        }


        public bool datosValidosCrear()
        {
            int i;
            if (txtNombre.Text == "") { MessageBox.Show("Falta completar el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtApellido.Text == "") { MessageBox.Show("Falta completar el apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboTipoIdNuevo.Text == "Seleccionar") { MessageBox.Show("Falta completar el tipo de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNroId.Text == "" || !int.TryParse(txtNroId.Text, out i)) { MessageBox.Show("Error en el campo de numero de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtEmail.Text == "") { MessageBox.Show("Falta completar el mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtTel.Text == "" || !int.TryParse(txtTel.Text, out i)) { MessageBox.Show("Error en el campo telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtCalle.Text == "") { MessageBox.Show("Falta completar la calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtNroCalle.Text == "" || !int.TryParse(txtNroCalle.Text, out i)) { MessageBox.Show("Error en el campo de numero de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtPiso.Text == "") { MessageBox.Show("Falta completar el piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtDepto.Text == "") { MessageBox.Show("Falta completar el dpto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtLocalidad.Text == "") { MessageBox.Show("Falta completar localidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboNacionalidadNuevo.Text == "Seleccionar") { MessageBox.Show("Falta completar nacionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cboPaisDirNuevo.Text == "Seleccionar") { MessageBox.Show("Falta completar pais del domicilio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            return true;
        }

        /*public bool datosValidosIdent()
        {
            if((cboTipoIdIden.Text=="Seleccionar") && (txtNroIdentiIden.Text=="") && (txtMailIden.Text == ""))
            {
                MessageBox.Show("Faltan datos en la identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else if(cboTipoIdIden)
        }
        }*/

        private void btnIdeMail_Click(object sender, EventArgs e)
        {

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
                cboTipoIdNuevo.Items.Add(tipo);
                cboidtipo.Items.Add(tipo);
            }
            reader.Close();
            con.Close();
            cboTipoIdNuevo.Items.Add("Otro");
            cboidtipo.Items.Add("Otro");



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
                cboPaisDirNuevo.Items.Add(tipo);
                cboNacionalidadNuevo.Items.Add(tipo);

            }
            reader.Close();
            con.Close();
            cboPaisDirNuevo.Items.Add("Otro");
            cboNacionalidadNuevo.Items.Add("Otro");


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerarReserva gr = new GenerarReserva();
            gr.Show();
        }
    }
}
