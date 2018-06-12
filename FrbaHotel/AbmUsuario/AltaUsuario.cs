using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaUsuario : Form
    {
        private Label lblUsername;
        private Label lblPassword;
        private DateTimePicker dtFN;
        private Label lblRol;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTipo;
        private Label lblNId;
        private Label lblEmail;
        private Label lblTel;
        private Label lblFN;
        private Label lblCalle;
        private Label lblLocalidad;
        private TextBox txtUsername;
        private TextBox txtNombre;
        private ComboBox cboRol;
        private TextBox txtApellido;
        private TextBox txtNroId;
        private TextBox txtEmail;
        private TextBox txtCalle;
        private TextBox txtLocalidad;
        private TextBox txtTel;
        private ComboBox cboTipoId;
        private Button btnCrearUsuario;
        private Button btnCancelar;
        private TextBox txtNroCalle;
        private Label label4;
        private TextBox txtDepto;
        private Label lblDpto;
        private TextBox txtPiso;
        private Label label2;
        private ComboBox cboPaisDir;
        private Label lblPais;
        private MaskedTextBox mtxtPassword;
    
        public AltaUsuario()
        {
            InitializeComponent();
            cboRol.Items.Add("Administrador");
            cboRol.Items.Add("Recepcionista");

            cboTipoId.Items.Add("DNI");
            cboTipoId.Items.Add("Pasaporte");
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            
            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.AgregarUsuario",con);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUsername.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = mtxtPassword.Text;
             cmd.Parameters.Add("rolasignado", SqlDbType.VarChar, 15).Value = cboRol;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = txtNombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = txtApellido.Text;
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.VarChar, 15).Value = cboTipoId.Text;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar,25).Value = txtNroId.Text;
            cmd.Parameters.Add("@fechaDeNacimiento", SqlDbType.Date).Value = dtfn2.Value;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = txtTel.Text;
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 200).Value = txtEmail.Text;
            cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 50).Value = cboNacionalidad.Text;
            cmd.Parameters.Add("@pais", SqlDbType.VarChar,150).Value = cboPaisDir.Text;
            cmd.Parameters.Add("@dirCalle", SqlDbType.VarChar, 150).Value = txtCalle.Text;
            cmd.Parameters.Add("@dirNroCalle", SqlDbType.Int).Value = txtNroCalle.Text;
            cmd.Parameters.Add("@dirLocalidad", SqlDbType.NVarChar, 150).Value = txtLocalidad.Text;
            cmd.Parameters.Add("@dirDepto", SqlDbType.Char,2).Value = txtDepto.Text;
            cmd.Parameters.Add("@dirPiso", SqlDbType.SmallInt).Value = Int16.Parse(txtPiso.Text);
            
            cmd.Parameters.Add("@idNuevo", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; // 0 -> Ok. / 1 -> Tipo y Nro. de documento existen. / 2 -> Email existe.

            if (chkAct.Checked)
            {
                cmd.Parameters.Add("@activo", SqlDbType.Char, 1).Value = 'S';
            }
            else
            {
                cmd.Parameters.Add("@activo", SqlDbType.Char, 1).Value = 'N';

            }

           if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());
            int idNuevo= int.Parse(cmd.Parameters["@idNuevo"].Value.ToString());
            if (codigoRet == 0) {

                MessageBox.Show(string.Format("Usuario creado. id {0}", idNuevo), "OK", MessageBoxButtons.OK);

            }
            else if (codigoRet == 1) {

                MessageBox.Show("Usuario no creado. El tipo y número de identificacion ya existe", "X", MessageBoxButtons.OK);

            }
            else if (codigoRet == 2) {

                MessageBox.Show("Usuario no creado. El mail ya existe", "X", MessageBoxButtons.OK);

            }   
        }

        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.dtFN = new System.Windows.Forms.DateTimePicker();
            this.mtxtPassword = new System.Windows.Forms.MaskedTextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblNId = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblFN = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNroId = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.cboTipoId = new System.Windows.Forms.ComboBox();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNroCalle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.lblDpto = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPaisDir = new System.Windows.Forms.ComboBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUsername.Location = new System.Drawing.Point(35, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPassword.Location = new System.Drawing.Point(35, 60);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // dtFN
            // 
            this.dtFN.Location = new System.Drawing.Point(205, 240);
            this.dtFN.Name = "dtFN";
            this.dtFN.Size = new System.Drawing.Size(200, 20);
            this.dtFN.TabIndex = 2;
            // 
            // mtxtPassword
            // 
            this.mtxtPassword.Location = new System.Drawing.Point(205, 60);
            this.mtxtPassword.Name = "mtxtPassword";
            this.mtxtPassword.Size = new System.Drawing.Size(100, 20);
            this.mtxtPassword.TabIndex = 3;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRol.Location = new System.Drawing.Point(35, 90);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(92, 17);
            this.lblRol.TabIndex = 4;
            this.lblRol.Text = "Rol Asignado";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNombre.Location = new System.Drawing.Point(35, 120);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblApellido.Location = new System.Drawing.Point(35, 150);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 6;
            this.lblApellido.Text = "Apellido";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTipo.Location = new System.Drawing.Point(35, 180);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(142, 17);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo de Identificación";
            // 
            // lblNId
            // 
            this.lblNId.AutoSize = true;
            this.lblNId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNId.Location = new System.Drawing.Point(35, 210);
            this.lblNId.Name = "lblNId";
            this.lblNId.Size = new System.Drawing.Size(141, 17);
            this.lblNId.TabIndex = 8;
            this.lblNId.Text = "Nro. de Identificación";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEmail.Location = new System.Drawing.Point(35, 300);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTel.Location = new System.Drawing.Point(35, 270);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(64, 17);
            this.lblTel.TabIndex = 10;
            this.lblTel.Text = "Teléfono";
            // 
            // lblFN
            // 
            this.lblFN.AutoSize = true;
            this.lblFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFN.Location = new System.Drawing.Point(35, 240);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(141, 17);
            this.lblFN.TabIndex = 11;
            this.lblFN.Text = "Fecha de Nacimiento";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCalle.Location = new System.Drawing.Point(435, 60);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(39, 17);
            this.lblCalle.TabIndex = 12;
            this.lblCalle.Text = "Calle";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLocalidad.Location = new System.Drawing.Point(435, 120);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(69, 17);
            this.lblLocalidad.TabIndex = 13;
            this.lblLocalidad.Text = "Localidad";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(205, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(205, 120);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // cboRol
            // 
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(205, 90);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(121, 21);
            this.cboRol.TabIndex = 16;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(205, 150);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 17;
            // 
            // txtNroId
            // 
            this.txtNroId.Location = new System.Drawing.Point(205, 210);
            this.txtNroId.Name = "txtNroId";
            this.txtNroId.Size = new System.Drawing.Size(100, 20);
            this.txtNroId.TabIndex = 18;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(205, 300);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 19;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(550, 60);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(100, 20);
            this.txtCalle.TabIndex = 20;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(550, 120);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 21;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(205, 270);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 22;
            // 
            // cboTipoId
            // 
            this.cboTipoId.FormattingEnabled = true;
            this.cboTipoId.Location = new System.Drawing.Point(205, 180);
            this.cboTipoId.Name = "cboTipoId";
            this.cboTipoId.Size = new System.Drawing.Size(121, 21);
            this.cboTipoId.TabIndex = 23;
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCrearUsuario.Location = new System.Drawing.Point(450, 400);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(150, 50);
            this.btnCrearUsuario.TabIndex = 24;
            this.btnCrearUsuario.Text = "Crear";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(175, 400);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 50);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.Location = new System.Drawing.Point(550, 90);
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.Size = new System.Drawing.Size(100, 20);
            this.txtNroCalle.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(435, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "Nro";
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(554, 154);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(29, 20);
            this.txtDepto.TabIndex = 41;
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDpto.Location = new System.Drawing.Point(435, 150);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(98, 17);
            this.lblDpto.TabIndex = 40;
            this.lblDpto.Text = "Departamento";
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(554, 184);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(29, 20);
            this.txtPiso.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(435, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Piso";
            // 
            // cboPaisDir
            // 
            this.cboPaisDir.FormattingEnabled = true;
            this.cboPaisDir.Location = new System.Drawing.Point(550, 30);
            this.cboPaisDir.Name = "cboPaisDir";
            this.cboPaisDir.Size = new System.Drawing.Size(150, 21);
            this.cboPaisDir.TabIndex = 37;
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPais.Location = new System.Drawing.Point(435, 30);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(35, 17);
            this.lblPais.TabIndex = 34;
            this.lblPais.Text = "Pais";
            // 
            // AltaUsuario
            // 
            this.ClientSize = new System.Drawing.Size(734, 486);
            this.Controls.Add(this.txtNroCalle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.lblDpto);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPaisDir);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.cboTipoId);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNroId);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.cboRol);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblFN);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNId);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.mtxtPassword);
            this.Controls.Add(this.dtFN);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "AltaUsuario";
            this.Text = "Alta de Usuario";
            this.Load += new System.EventHandler(this.AltaUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
