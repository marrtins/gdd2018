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
    public partial class ModificarUsuario : Form
    {
        private ComboBox cboTipoId;
        private TextBox txtTel;
        private TextBox txtLocalidad;
        private TextBox txtCalle;
        private TextBox txtEmail;
        private TextBox txtNroId;
        private TextBox txtApellido;
        private ComboBox cboRol;
        private TextBox txtNombre;
        private TextBox txtUsername;
        private Label lblLocalidad;
        private Label lblCalle;
        private Label lblFN;
        private Label lblTel;
        private Label lblEmail;
        private Label lblNId;
        private Label lblTipo;
        private Label lblApellido;
        private Label lblNombre;
        private Label lblRol;
        private MaskedTextBox mtxtPassword;
        private DateTimePicker dtFN;
        private Label lblPassword;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Label lblUsername;
    
        public ModificarUsuario(string username, string password, string nombre, string apellido, string tipodoc, string nrodoc, string mail,string telefono, DateTime fechanac, string nacionalidad, string dircalle, int dirnrocalle, string pais, int dirpiso, string dirdepto, string dirloc, string habilitado)
        {
            this.username = username;
            this.password = password;
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

            txtUsername.Text = username;
            mtxtPassword.Text = password;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            cboTipoId.Text = tipodoc;
            txtNroID.Text = nrodoc;
            txtEmail.Text = mail;
            txtTel.Text = telefono;
            dtFN.Value = fechanac;
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

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.cboTipoId = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNroId = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblFN = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNId = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.mtxtPassword = new System.Windows.Forms.MaskedTextBox();
            this.dtFN = new System.Windows.Forms.DateTimePicker();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboTipoId
            // 
            this.cboTipoId.FormattingEnabled = true;
            this.cboTipoId.Location = new System.Drawing.Point(205, 180);
            this.cboTipoId.Name = "cboTipoId";
            this.cboTipoId.Size = new System.Drawing.Size(121, 21);
            this.cboTipoId.TabIndex = 47;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(205, 270);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 46;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(205, 360);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 45;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(205, 330);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(100, 20);
            this.txtCalle.TabIndex = 44;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(205, 300);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 43;
            // 
            // txtNroId
            // 
            this.txtNroId.Location = new System.Drawing.Point(205, 210);
            this.txtNroId.Name = "txtNroId";
            this.txtNroId.Size = new System.Drawing.Size(100, 20);
            this.txtNroId.TabIndex = 42;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(205, 150);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 41;
            // 
            // cboRol
            // 
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(205, 90);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(121, 21);
            this.cboRol.TabIndex = 40;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(205, 120);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 39;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(205, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 38;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLocalidad.Location = new System.Drawing.Point(35, 360);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(69, 17);
            this.lblLocalidad.TabIndex = 37;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCalle.Location = new System.Drawing.Point(35, 330);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(39, 17);
            this.lblCalle.TabIndex = 36;
            this.lblCalle.Text = "Calle";
            // 
            // lblFN
            // 
            this.lblFN.AutoSize = true;
            this.lblFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFN.Location = new System.Drawing.Point(35, 240);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(141, 17);
            this.lblFN.TabIndex = 35;
            this.lblFN.Text = "Fecha de Nacimiento";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTel.Location = new System.Drawing.Point(35, 270);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(64, 17);
            this.lblTel.TabIndex = 34;
            this.lblTel.Text = "Teléfono";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEmail.Location = new System.Drawing.Point(35, 300);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 33;
            this.lblEmail.Text = "Email";
            // 
            // lblNId
            // 
            this.lblNId.AutoSize = true;
            this.lblNId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNId.Location = new System.Drawing.Point(35, 210);
            this.lblNId.Name = "lblNId";
            this.lblNId.Size = new System.Drawing.Size(141, 17);
            this.lblNId.TabIndex = 32;
            this.lblNId.Text = "Nro. de Identificación";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTipo.Location = new System.Drawing.Point(35, 180);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(142, 17);
            this.lblTipo.TabIndex = 31;
            this.lblTipo.Text = "Tipo de Identificación";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblApellido.Location = new System.Drawing.Point(35, 150);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 30;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNombre.Location = new System.Drawing.Point(35, 120);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 29;
            this.lblNombre.Text = "Nombre";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRol.Location = new System.Drawing.Point(35, 90);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(92, 17);
            this.lblRol.TabIndex = 28;
            this.lblRol.Text = "Rol Asignado";
            // 
            // mtxtPassword
            // 
            this.mtxtPassword.Location = new System.Drawing.Point(205, 60);
            this.mtxtPassword.Name = "mtxtPassword";
            this.mtxtPassword.Size = new System.Drawing.Size(100, 20);
            this.mtxtPassword.TabIndex = 27;
            // 
            // dtFN
            // 
            this.dtFN.Location = new System.Drawing.Point(205, 240);
            this.dtFN.Name = "dtFN";
            this.dtFN.Size = new System.Drawing.Size(200, 20);
            this.dtFN.TabIndex = 26;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPassword.Location = new System.Drawing.Point(35, 60);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 25;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUsername.Location = new System.Drawing.Point(35, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 24;
            this.lblUsername.Text = "Username";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(35, 415);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 50);
            this.btnLimpiar.TabIndex = 48;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(220, 415);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 50);
            this.btnGuardar.TabIndex = 49;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // ModificarUsuario
            // 
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
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
            this.Name = "ModificarUsuario";
            this.Text = "Modificar Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
