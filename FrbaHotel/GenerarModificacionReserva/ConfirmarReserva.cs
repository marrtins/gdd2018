using FrbaHotel.AbmCliente;
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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ConfirmarReserva : Form
    {
        private DateTime dtDesde;
        private DateTime dtHasta;
        private string hotel;
        
        private string regimen;
        private float precio;
        private int idCliente;
        private int idHotel;
        private int idPersona;
        private int codigoRes;
        private List<TipoCant> tcs;



        public ConfirmarReserva(int idHotel,DateTime dtDesde, DateTime dtHasta, string hotel, string regimen, float precio,List<TipoCant>tcs)
        {
            this.dtDesde = dtDesde;
            this.idHotel = idHotel;
            this.dtHasta = dtHasta;
            this.hotel = hotel;
            this.tcs = tcs;
            this.regimen = regimen;
            this.precio = precio;

            InitializeComponent();
            lblDesde.Text = dtDesde.ToString();
            lblHasta.Text = dtHasta.ToString();
            lblHotel.Text = hotel;
            //lblHab.Text = tipohab;
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
                            return;
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
                            return;
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
            string consultaBusqueda = String.Format("select p.idPersona,p.Nombre,p.Apellido,p.Mail,p.NroDocumento,hu.idHuesped from mmel.Persona p,mmel.Huesped, mmel.TipoDocumento td where p.idPersona=idPersona and p.NroDocumento={0} and td.idTipoDocumento=p.idTipoDocumento and td.detalle='{1}'", txtidnro.Text, cboidtipo.Text);
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
                    ErrorPasaporteErroneo epe = new ErrorPasaporteErroneo(nro,mail,this);
                    this.Hide();
                    epe.Show();
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
                    idPersona = Int32.Parse(reader["idPersona"].ToString());
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
                    //MailErroneoReserva per = new MailErroneoReserva(idCliente, nombre, apellido, idNro, mail,this);
                    //per.Show();
                    ErrorPasaporteErroneo epe = new ErrorPasaporteErroneo(idNro, mail, this);
                    epe.Show();
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
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fechaDesde", SqlDbType.Date).Value = dtDesde;
            cmd.Parameters.Add("@fechaHasta", SqlDbType.Date).Value = dtHasta;
            cmd.Parameters.Add("@fechaDeReserva", SqlDbType.DateTime).Value = value;
            int idusuario;
            if (LoginData.IdUsuario == 0)
                idusuario = 1;
                else idusuario = LoginData.IdUsuario;
            cmd.Parameters.Add("@idUsuarioQueReserva", SqlDbType.Int).Value = LoginData.IdUsuario;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            //cmd.Parameters.Add("@tipoHabDesc", SqlDbType.VarChar, 100).Value = tipohab;
            cmd.Parameters.Add("@tipoRegimenDesc", SqlDbType.VarChar, 100).Value = regimen;
            cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
            
            
            

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();


            codigoRes = getCodigoRes();
            MessageBox.Show(string.Format("Reserva Concretada. Codigo: {0}", codigoRes), "OK", MessageBoxButtons.OK);
            setearHabitaciones();
            this.Hide();
            GenModReserva gmr = new GenModReserva();
            gmr.Show();
            /*var dr = cmd.ExecuteReader();

            var res = 0;

            if (dr.HasRows)
            {
                dr.Read();

                res = int.Parse(dr["Resultado"].ToString()); //si res = -1 es fallido

                if (res == -1)
                {
                    MessageBox.Show("No se puede realizar la reserva ya que existen fechas de baja superpuestas");
                }
                else
                {

                    int codigoReserva = int.Parse(cmd.Parameters["@codReserva"].Value.ToString());
                    codigoRes = codigoReserva;
                    MessageBox.Show(string.Format("Reserva Concretada. Codigo: {0}", codigoReserva), "OK", MessageBoxButtons.OK);
                    setearHabitaciones();
                    this.Hide();
                    GenModReserva gmr = new GenModReserva();
                    gmr.Show();
                }

            }    */
        }
        private int getCodigoRes()
        {
          
                string consultaBusqueda = String.Format("select max(CodigoReserva) Codigo from mmel.Reserva");
                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);
                SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
                con.Open();
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                int cod = 0;
                while (reader.Read())
                {
                    cod = int.Parse(reader["Codigo"].ToString());
                }
                reader.Close();
                con.Close();
                return cod;
            
        }

        private void setearHabitaciones()
        {

            int i;
            for (i = 0; i < tcs.Count; i++)
            {

                string strCo = ConfigurationManager.AppSettings["stringConexion"];
                SqlConnection con = new SqlConnection(strCo);

                SqlCommand cmd;
                cmd = new SqlCommand("MMEL.setearHabitaciones", con);
                DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codigoRes", SqlDbType.Int).Value = codigoRes;
                cmd.Parameters.Add("@cantHab", SqlDbType.Int).Value = tcs[i].cant;
                cmd.Parameters.Add("@tipoHabDesc", SqlDbType.VarChar, 100).Value = tcs[i].desc;
                cmd.Parameters.Add("@fechaDesde", SqlDbType.Date).Value = dtDesde;
                cmd.Parameters.Add("@fechaHasta", SqlDbType.Date).Value = dtHasta;
                cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;


                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();
            }
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
                idPersona = int.Parse(cmd.Parameters["@idNuevo"].Value.ToString());
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
