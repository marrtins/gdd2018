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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class IngresarCliente : Form
    {
        Form ftr;
        int cant;
        int o = 0;
        
        public IngresarCliente(Form ftr,int cant)
        {
            this.ftr = ftr;
            
            this.cant = cant-1;
            InitializeComponent();
            optRegis.Checked = true;
            grNuevoCliente.Visible = false;
            cargarPaises();
            cargarTipoID();
            label8.Text = String.Format("Ingrese los datos de los {0} huespedes restantes", cant);
        }

        private void IngresarCliente_Load(object sender, EventArgs e)
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
            //cboTipoIdNuevo.Items.Add("Otro");
            //cboidtipo.Items.Add("Otro");
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
            //cboPaisDirNuevo.Items.Add("Otro");
            //cboNacionalidadNuevo.Items.Add("Otro");
        }

        private void optRegis_CheckedChanged(object sender, EventArgs e)
        {
            if (optRegis.Checked == true)
            {
                grpIdentificarse.Visible = true;
                grNuevoCliente.Visible = false;
            }
            else
            {
                grpIdentificarse.Visible = false;
                grNuevoCliente.Visible = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
           
                if (optNuevo.Checked == true)
                {
                    if (crearCliente())
                    {
                        o++;
                        lstHuespedes.Items.Add(String.Format("{0} {1}", txtNombre.Text, txtApellido.Text));
                    txtidmail.Text = "";
                    txtidnro.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    cboTipoIdNuevo.Text = "Seleccionar";
                    txtNroId.Text = "";
                    txtEmail.Text = "";
                    txtTel.Text = "";
                    txtCalle.Text = "";
                    txtNroCalle.Text = "";
                    txtPiso.Text = "";
                    txtDepto.Text = "";
                    txtLocalidad.Text = "";
                    cboNacionalidadNuevo.Text = "Seleccionar";
                    cboPaisDirNuevo.Text = "Seleccionar";
                }
                }
                else
                {
                    if (txtidnro.Text == "" && txtidmail.Text == "")
                    {
                        MessageBox.Show("Faltan completar datos para identificar", "Error", MessageBoxButtons.OK);
                    }
                    else if ((txtidnro.Text != "" && cboidtipo.Text != "") || (txtidmail.Text != ""))
                    {
                        if (txtidnro.Text != "" && cboidtipo.Text != "")
                        {

                            if (consultarUsuarioExistenteIdentificacion())
                            {
                                o++;
                            txtidmail.Text = "";
                            txtidnro.Text = "";
                            txtNombre.Text = "";
                            txtApellido.Text = "";
                            cboTipoIdNuevo.Text = "Seleccionar";
                            txtNroId.Text = "";
                            txtEmail.Text = "";
                            txtTel.Text = "";
                            txtCalle.Text = "";
                            txtNroCalle.Text = "";
                            txtPiso.Text = "";
                            txtDepto.Text = "";
                            txtLocalidad.Text = "";
                            cboNacionalidadNuevo.Text = "Seleccionar";
                            cboPaisDirNuevo.Text = "Seleccionar";
                        }
                            else
                            {
                                
                            }

                        }
                        else if (txtidmail.Text != "")
                        {
                            if (consultarUsuarioExistenteMail())
                            {
                                o++;
                            txtidmail.Text = "";
                            txtidnro.Text = "";
                            txtNombre.Text = "";
                            txtApellido.Text = "";
                            cboTipoIdNuevo.Text = "Seleccionar";
                            txtNroId.Text = "";
                            txtEmail.Text = "";
                            txtTel.Text = "";
                            txtCalle.Text = "";
                            txtNroCalle.Text = "";
                            txtPiso.Text = "";
                            txtDepto.Text = "";
                            txtLocalidad.Text = "";
                            cboNacionalidadNuevo.Text = "Seleccionar";
                            cboPaisDirNuevo.Text = "Seleccionar";
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
            

            if (o == cant)
            {
                this.Hide();
                ftr.Show();
            }
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
            int idPersona;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idPersona = Int32.Parse(reader["idPersona"].ToString());
                    nombre = (reader["Nombre"].ToString());
                    apellido = (reader["Apellido"].ToString());
                    mail = (reader["Mail"].ToString());
                    idNro = (reader["NroDocumento"].ToString());
                    aux++;
                }
                reader.Close();
                con.Close();
                if (aux > 1)
                {
                    //MailErroneoReserva per = new MailErroneoReserva(idCliente, nombre, apellido, idNro, mail,this);
                    //per.Show();
                    ErrorPasaporteErroneo epe = new ErrorPasaporteErroneo(idNro, mail, this);
                    epe.Show();
                    this.Hide();
                    return false;
                }
                else
                {
                    MessageBox.Show("Cliente identificado");
                    lstHuespedes.Items.Add(String.Format("{0} {1}", nombre, apellido));
                    return true;
                }

            }
            else
            {
                MessageBox.Show("No hay usuario registrado con ese mail");
                return false;
            }
            return true;
        }
        private bool consultarUsuarioExistenteIdentificacion()
        {
            string consultaBusqueda = String.Format("select p.idPersona,p.Nombre,p.Apellido,p.Mail,p.NroDocumento,hu.idHuesped from mmel.Persona p,mmel.Huesped hu, mmel.TipoDocumento td where p.idPersona=hu.idPersona and p.NroDocumento={0} and td.idTipoDocumento=p.idTipoDocumento and td.detalle='{1}'", txtidnro.Text, cboidtipo.Text);
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
            string nro = "";
            int idPersona;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idPersona = Int32.Parse(reader["idPersona"].ToString());
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

                    //PasaporteErroneoReserva per = new PasaporteErroneoReserva(idCliente, nombre, apellido, nro, mail,this);
                    //per.Show();
                    ErrorPasaporteErroneo epe = new ErrorPasaporteErroneo(nro, mail, this);
                    this.Hide();
                    epe.Show();
                    return false;
                }
                else
                {
                    MessageBox.Show("Cliente identificado");
                    lstHuespedes.Items.Add(String.Format("{0} {1}", nombre,apellido));
                    return true;
                }

            }
            else
            {
                MessageBox.Show("No hay usuario registrado con ese tipo y nro de identifiacion");
                return false;
            }
            return true;
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
                int idPersona = int.Parse(cmd.Parameters["@idNuevo"].Value.ToString());
                if (codigoRet == 0)
                {
                    MessageBox.Show(string.Format("Cliente creado. id {0}", idPersona), "OK", MessageBoxButtons.OK);

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
    }
}
