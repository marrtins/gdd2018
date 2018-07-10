namespace FrbaHotel.AbmUsuario
{
    partial class AltaModificar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {   
            this.nroCalleInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deptoInput = new System.Windows.Forms.TextBox();
            this.lblDpto = new System.Windows.Forms.Label();
            this.pisoInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPaisDir = new System.Windows.Forms.ComboBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.telefonoInput = new System.Windows.Forms.TextBox();
            this.localidadInput = new System.Windows.Forms.TextBox();
            this.calleInput = new System.Windows.Forms.TextBox();
            this.mailInput = new System.Windows.Forms.TextBox();
            this.nroDocumentoInput = new System.Windows.Forms.TextBox();
            this.apellidoInput = new System.Windows.Forms.TextBox();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblFN = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblNId = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.MaskedTextBox();
            this.fechaNacInput = new System.Windows.Forms.DateTimePicker();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.cboHotel = new System.Windows.Forms.ComboBox();
            this.lblHotel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nroCalleInput
            // 
            this.nroCalleInput.Location = new System.Drawing.Point(545, 144);
            this.nroCalleInput.Name = "nroCalleInput";
            this.nroCalleInput.Size = new System.Drawing.Size(100, 20);
            this.nroCalleInput.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(430, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 110;
            this.label4.Text = "Nro. de Calle";
            // 
            // deptoInput
            // 
            this.deptoInput.Location = new System.Drawing.Point(545, 190);
            this.deptoInput.Name = "deptoInput";
            this.deptoInput.Size = new System.Drawing.Size(49, 20);
            this.deptoInput.TabIndex = 109;
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDpto.Location = new System.Drawing.Point(430, 190);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(98, 17);
            this.lblDpto.TabIndex = 108;
            this.lblDpto.Text = "Departamento";
            // 
            // pisoInput
            // 
            this.pisoInput.Location = new System.Drawing.Point(545, 233);
            this.pisoInput.Name = "pisoInput";
            this.pisoInput.Size = new System.Drawing.Size(49, 20);
            this.pisoInput.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(430, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 106;
            this.label2.Text = "Piso";
            // 
            // cboPaisDir
            // 
            this.cboPaisDir.FormattingEnabled = true;
            this.cboPaisDir.Location = new System.Drawing.Point(545, 21);
            this.cboPaisDir.Name = "cboPaisDir";
            this.cboPaisDir.Size = new System.Drawing.Size(150, 21);
            this.cboPaisDir.TabIndex = 105;
            this.cboPaisDir.Text = "Seleccionar";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPais.Location = new System.Drawing.Point(430, 21);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(35, 17);
            this.lblPais.TabIndex = 104;
            this.lblPais.Text = "Pais";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(33, 474);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 50);
            this.btnCancelar.TabIndex = 103;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAceptar.Location = new System.Drawing.Point(545, 474);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(150, 50);
            this.btnAceptar.TabIndex = 102;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(200, 241);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDoc.TabIndex = 101;
            this.cboTipoDoc.Text = "Seleccionar";
            // 
            // telefonoInput
            // 
            this.telefonoInput.Location = new System.Drawing.Point(200, 377);
            this.telefonoInput.Name = "telefonoInput";
            this.telefonoInput.Size = new System.Drawing.Size(189, 20);
            this.telefonoInput.TabIndex = 100;
            // 
            // localidadInput
            // 
            this.localidadInput.Location = new System.Drawing.Point(545, 66);
            this.localidadInput.Name = "localidadInput";
            this.localidadInput.Size = new System.Drawing.Size(100, 20);
            this.localidadInput.TabIndex = 99;
            // 
            // calleInput
            // 
            this.calleInput.Location = new System.Drawing.Point(545, 108);
            this.calleInput.Name = "calleInput";
            this.calleInput.Size = new System.Drawing.Size(100, 20);
            this.calleInput.TabIndex = 98;
            // 
            // mailInput
            // 
            this.mailInput.Location = new System.Drawing.Point(200, 420);
            this.mailInput.Name = "mailInput";
            this.mailInput.Size = new System.Drawing.Size(189, 20);
            this.mailInput.TabIndex = 97;
            // 
            // nroDocumentoInput
            // 
            this.nroDocumentoInput.Location = new System.Drawing.Point(200, 286);
            this.nroDocumentoInput.Name = "nroDocumentoInput";
            this.nroDocumentoInput.Size = new System.Drawing.Size(189, 20);
            this.nroDocumentoInput.TabIndex = 96;
            // 
            // apellidoInput
            // 
            this.apellidoInput.Location = new System.Drawing.Point(200, 197);
            this.apellidoInput.Name = "apellidoInput";
            this.apellidoInput.Size = new System.Drawing.Size(189, 20);
            this.apellidoInput.TabIndex = 95;
            // 
            // cboRol
            // 
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(200, 108);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(121, 21);
            this.cboRol.TabIndex = 94;
            this.cboRol.Text = "Seleccionar";
            // 
            // nombreInput
            // 
            this.nombreInput.Location = new System.Drawing.Point(200, 151);
            this.nombreInput.Name = "nombreInput";
            this.nombreInput.Size = new System.Drawing.Size(189, 20);
            this.nombreInput.TabIndex = 93;
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(200, 21);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(189, 20);
            this.usernameInput.TabIndex = 92;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLocalidad.Location = new System.Drawing.Point(430, 66);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(69, 17);
            this.lblLocalidad.TabIndex = 91;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCalle.Location = new System.Drawing.Point(430, 108);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(39, 17);
            this.lblCalle.TabIndex = 90;
            this.lblCalle.Text = "Calle";
            // 
            // lblFN
            // 
            this.lblFN.AutoSize = true;
            this.lblFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFN.Location = new System.Drawing.Point(30, 329);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(141, 17);
            this.lblFN.TabIndex = 89;
            this.lblFN.Text = "Fecha de Nacimiento";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTel.Location = new System.Drawing.Point(30, 377);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(64, 17);
            this.lblTel.TabIndex = 88;
            this.lblTel.Text = "Telefono";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMail.Location = new System.Drawing.Point(30, 420);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(33, 17);
            this.lblMail.TabIndex = 87;
            this.lblMail.Text = "Mail";
            // 
            // lblNId
            // 
            this.lblNId.AutoSize = true;
            this.lblNId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNId.Location = new System.Drawing.Point(30, 286);
            this.lblNId.Name = "lblNId";
            this.lblNId.Size = new System.Drawing.Size(141, 17);
            this.lblNId.TabIndex = 86;
            this.lblNId.Text = "Nro. de Identificacion";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTipo.Location = new System.Drawing.Point(30, 241);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(142, 17);
            this.lblTipo.TabIndex = 85;
            this.lblTipo.Text = "Tipo de Identificacion";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblApellido.Location = new System.Drawing.Point(30, 197);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 84;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNombre.Location = new System.Drawing.Point(30, 151);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 83;
            this.lblNombre.Text = "Nombre";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRol.Location = new System.Drawing.Point(30, 109);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(92, 17);
            this.lblRol.TabIndex = 82;
            this.lblRol.Text = "Rol Asignado";
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(200, 66);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.PasswordChar = '*';
            this.passwordInput.Size = new System.Drawing.Size(189, 20);
            this.passwordInput.TabIndex = 81;
            // 
            // fechaNacInput
            // 
            this.fechaNacInput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaNacInput.Location = new System.Drawing.Point(200, 329);
            this.fechaNacInput.Name = "fechaNacInput";
            this.fechaNacInput.Size = new System.Drawing.Size(121, 20);
            this.fechaNacInput.TabIndex = 80;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPassword.Location = new System.Drawing.Point(30, 66);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 79;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUsername.Location = new System.Drawing.Point(30, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 78;
            this.lblUsername.Text = "Username";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLimpiar.Location = new System.Drawing.Point(349, 474);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 50);
            this.btnLimpiar.TabIndex = 112;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.activoCheck.Location = new System.Drawing.Point(603, 373);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(65, 21);
            this.activoCheck.TabIndex = 113;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            // 
            // cboHotel
            // 
            this.cboHotel.FormattingEnabled = true;
            this.cboHotel.Location = new System.Drawing.Point(545, 279);
            this.cboHotel.Name = "cboHotel";
            this.cboHotel.Size = new System.Drawing.Size(150, 21);
            this.cboHotel.TabIndex = 114;
            this.cboHotel.Text = "Seleccionar";
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblHotel.Location = new System.Drawing.Point(430, 280);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(41, 17);
            this.lblHotel.TabIndex = 115;
            this.lblHotel.Text = "Hotel";
            // 
            // AltaModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(731, 546);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.cboHotel);
            this.Controls.Add(this.activoCheck);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.nroCalleInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deptoInput);
            this.Controls.Add(this.lblDpto);
            this.Controls.Add(this.pisoInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPaisDir);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboTipoDoc);
            this.Controls.Add(this.telefonoInput);
            this.Controls.Add(this.localidadInput);
            this.Controls.Add(this.calleInput);
            this.Controls.Add(this.mailInput);
            this.Controls.Add(this.nroDocumentoInput);
            this.Controls.Add(this.apellidoInput);
            this.Controls.Add(this.cboRol);
            this.Controls.Add(this.nombreInput);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblFN);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblNId);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.fechaNacInput);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "AltaModificar";
            this.Text = "Alta o Modificado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.TextBox nroCalleInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox deptoInput;
        private System.Windows.Forms.Label lblDpto;
        private System.Windows.Forms.TextBox pisoInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPaisDir;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.TextBox telefonoInput;
        private System.Windows.Forms.TextBox localidadInput;
        private System.Windows.Forms.TextBox calleInput;
        private System.Windows.Forms.TextBox mailInput;
        private System.Windows.Forms.TextBox nroDocumentoInput;
        private System.Windows.Forms.TextBox apellidoInput;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblFN;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblNId;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.MaskedTextBox passwordInput;
        private System.Windows.Forms.DateTimePicker fechaNacInput;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox activoCheck;
        private System.Windows.Forms.ComboBox cboHotel;
        private System.Windows.Forms.Label lblHotel;
        
    }
}