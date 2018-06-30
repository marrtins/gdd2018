namespace FrbaHotel.GenerarModificacionReserva
{
    partial class ConfirmarReserva
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
            this.lblTot = new System.Windows.Forms.Label();
            this.grMain = new System.Windows.Forms.GroupBox();
            this.lblReg = new System.Windows.Forms.Label();
            this.lblHab = new System.Windows.Forms.Label();
            this.lblHotel = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.optNuevo = new System.Windows.Forms.RadioButton();
            this.optRegis = new System.Windows.Forms.RadioButton();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.grNuevoCliente = new System.Windows.Forms.GroupBox();
            this.txtNroCalle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPaisDirNuevo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNacionalidadNuevo = new System.Windows.Forms.ComboBox();
            this.dtfn2 = new System.Windows.Forms.DateTimePicker();
            this.lblFNac = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNroId = new System.Windows.Forms.TextBox();
            this.lblNroId = new System.Windows.Forms.Label();
            this.cboTipoIdNuevo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.grpIdentificarse = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtidnro = new System.Windows.Forms.TextBox();
            this.cboidtipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtidmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grMain.SuspendLayout();
            this.grNuevoCliente.SuspendLayout();
            this.grpIdentificarse.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTot
            // 
            this.lblTot.AutoSize = true;
            this.lblTot.Location = new System.Drawing.Point(26, 175);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(127, 13);
            this.lblTot.TabIndex = 0;
            this.lblTot.Text = "Costo total de la reserva: ";
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.lblReg);
            this.grMain.Controls.Add(this.lblTot);
            this.grMain.Controls.Add(this.lblHab);
            this.grMain.Controls.Add(this.lblHotel);
            this.grMain.Controls.Add(this.lblHasta);
            this.grMain.Controls.Add(this.lblDesde);
            this.grMain.Location = new System.Drawing.Point(53, 31);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(308, 215);
            this.grMain.TabIndex = 1;
            this.grMain.TabStop = false;
            this.grMain.Text = "Su reserva: ";
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Location = new System.Drawing.Point(26, 141);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(55, 13);
            this.lblReg.TabIndex = 4;
            this.lblReg.Text = "Regimen: ";
            // 
            // lblHab
            // 
            this.lblHab.AutoSize = true;
            this.lblHab.Location = new System.Drawing.Point(26, 116);
            this.lblHab.Name = "lblHab";
            this.lblHab.Size = new System.Drawing.Size(88, 13);
            this.lblHab.TabIndex = 3;
            this.lblHab.Text = "Tipo Habitacion: ";
            this.lblHab.Click += new System.EventHandler(this.lblHab_Click);
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(26, 43);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(38, 13);
            this.lblHotel.TabIndex = 2;
            this.lblHotel.Text = "Hotel: ";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(26, 93);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(26, 68);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Click += new System.EventHandler(this.label2_Click);
            // 
            // optNuevo
            // 
            this.optNuevo.AutoSize = true;
            this.optNuevo.Location = new System.Drawing.Point(82, 268);
            this.optNuevo.Name = "optNuevo";
            this.optNuevo.Size = new System.Drawing.Size(92, 17);
            this.optNuevo.TabIndex = 2;
            this.optNuevo.TabStop = true;
            this.optNuevo.Text = "Nuevo Cliente";
            this.optNuevo.UseVisualStyleBackColor = true;
            this.optNuevo.CheckedChanged += new System.EventHandler(this.optNuevo_CheckedChanged);
            // 
            // optRegis
            // 
            this.optRegis.AutoSize = true;
            this.optRegis.Location = new System.Drawing.Point(186, 267);
            this.optRegis.Name = "optRegis";
            this.optRegis.Size = new System.Drawing.Size(111, 17);
            this.optRegis.TabIndex = 3;
            this.optRegis.TabStop = true;
            this.optRegis.Text = "Cliente Registrado";
            this.optRegis.UseVisualStyleBackColor = true;
            this.optRegis.CheckedChanged += new System.EventHandler(this.optRegis_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(417, 480);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(99, 35);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar Reserva";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(82, 480);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(99, 34);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // grNuevoCliente
            // 
            this.grNuevoCliente.Controls.Add(this.txtNroCalle);
            this.grNuevoCliente.Controls.Add(this.label4);
            this.grNuevoCliente.Controls.Add(this.txtDepto);
            this.grNuevoCliente.Controls.Add(this.label3);
            this.grNuevoCliente.Controls.Add(this.txtPiso);
            this.grNuevoCliente.Controls.Add(this.label2);
            this.grNuevoCliente.Controls.Add(this.cboPaisDirNuevo);
            this.grNuevoCliente.Controls.Add(this.label1);
            this.grNuevoCliente.Controls.Add(this.cboNacionalidadNuevo);
            this.grNuevoCliente.Controls.Add(this.dtfn2);
            this.grNuevoCliente.Controls.Add(this.lblFNac);
            this.grNuevoCliente.Controls.Add(this.txtLocalidad);
            this.grNuevoCliente.Controls.Add(this.txtCalle);
            this.grNuevoCliente.Controls.Add(this.lblPais);
            this.grNuevoCliente.Controls.Add(this.lblLocalidad);
            this.grNuevoCliente.Controls.Add(this.lblCalle);
            this.grNuevoCliente.Controls.Add(this.txtTel);
            this.grNuevoCliente.Controls.Add(this.lblTel);
            this.grNuevoCliente.Controls.Add(this.txtEmail);
            this.grNuevoCliente.Controls.Add(this.lblEmail);
            this.grNuevoCliente.Controls.Add(this.txtNroId);
            this.grNuevoCliente.Controls.Add(this.lblNroId);
            this.grNuevoCliente.Controls.Add(this.cboTipoIdNuevo);
            this.grNuevoCliente.Controls.Add(this.lblTipo);
            this.grNuevoCliente.Controls.Add(this.txtApellido);
            this.grNuevoCliente.Controls.Add(this.lblApellido);
            this.grNuevoCliente.Controls.Add(this.txtNombre);
            this.grNuevoCliente.Controls.Add(this.lblNombre);
            this.grNuevoCliente.Location = new System.Drawing.Point(430, 31);
            this.grNuevoCliente.Name = "grNuevoCliente";
            this.grNuevoCliente.Size = new System.Drawing.Size(311, 425);
            this.grNuevoCliente.TabIndex = 6;
            this.grNuevoCliente.TabStop = false;
            this.grNuevoCliente.Text = "Nuevo Cliente";
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.Location = new System.Drawing.Point(35, 321);
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.Size = new System.Drawing.Size(34, 20);
            this.txtNroCalle.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Nro";
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(180, 321);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(29, 20);
            this.txtDepto.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Dpto";
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(117, 321);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(29, 20);
            this.txtPiso.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Piso";
            // 
            // cboPaisDirNuevo
            // 
            this.cboPaisDirNuevo.FormattingEnabled = true;
            this.cboPaisDirNuevo.Location = new System.Drawing.Point(64, 386);
            this.cboPaisDirNuevo.Name = "cboPaisDirNuevo";
            this.cboPaisDirNuevo.Size = new System.Drawing.Size(145, 21);
            this.cboPaisDirNuevo.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nacionalidad";
            // 
            // cboNacionalidadNuevo
            // 
            this.cboNacionalidadNuevo.FormattingEnabled = true;
            this.cboNacionalidadNuevo.Location = new System.Drawing.Point(77, 194);
            this.cboNacionalidadNuevo.Name = "cboNacionalidadNuevo";
            this.cboNacionalidadNuevo.Size = new System.Drawing.Size(132, 21);
            this.cboNacionalidadNuevo.TabIndex = 50;
            // 
            // dtfn2
            // 
            this.dtfn2.Location = new System.Drawing.Point(117, 154);
            this.dtfn2.Name = "dtfn2";
            this.dtfn2.Size = new System.Drawing.Size(194, 20);
            this.dtfn2.TabIndex = 49;
            // 
            // lblFNac
            // 
            this.lblFNac.AutoSize = true;
            this.lblFNac.Location = new System.Drawing.Point(0, 161);
            this.lblFNac.Name = "lblFNac";
            this.lblFNac.Size = new System.Drawing.Size(108, 13);
            this.lblFNac.TabIndex = 48;
            this.lblFNac.Text = "Fecha de Nacimiento";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(62, 356);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(147, 20);
            this.txtLocalidad.TabIndex = 47;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(62, 282);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(147, 20);
            this.txtCalle.TabIndex = 46;
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(4, 394);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(27, 13);
            this.lblPais.TabIndex = 45;
            this.lblPais.Text = "Pais";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(4, 359);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 44;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(4, 289);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(30, 13);
            this.lblCalle.TabIndex = 43;
            this.lblCalle.Text = "Calle";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(62, 252);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(147, 20);
            this.txtTel.TabIndex = 42;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(2, 252);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(49, 13);
            this.lblTel.TabIndex = 41;
            this.lblTel.Text = "Telefono";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(62, 225);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 20);
            this.txtEmail.TabIndex = 40;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(5, 228);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 39;
            this.lblEmail.Text = "Email";
            // 
            // txtNroId
            // 
            this.txtNroId.Location = new System.Drawing.Point(117, 118);
            this.txtNroId.Name = "txtNroId";
            this.txtNroId.Size = new System.Drawing.Size(91, 20);
            this.txtNroId.TabIndex = 38;
            // 
            // lblNroId
            // 
            this.lblNroId.AutoSize = true;
            this.lblNroId.Location = new System.Drawing.Point(3, 121);
            this.lblNroId.Name = "lblNroId";
            this.lblNroId.Size = new System.Drawing.Size(105, 13);
            this.lblNroId.TabIndex = 37;
            this.lblNroId.Text = "Nro de Identificación";
            // 
            // cboTipoIdNuevo
            // 
            this.cboTipoIdNuevo.FormattingEnabled = true;
            this.cboTipoIdNuevo.Location = new System.Drawing.Point(117, 91);
            this.cboTipoIdNuevo.Name = "cboTipoIdNuevo";
            this.cboTipoIdNuevo.Size = new System.Drawing.Size(92, 21);
            this.cboTipoIdNuevo.TabIndex = 36;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(2, 94);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(109, 13);
            this.lblTipo.TabIndex = 35;
            this.lblTipo.Text = "Tipo de Identificacion";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(62, 65);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(147, 20);
            this.txtApellido.TabIndex = 34;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(2, 68);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 33;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(62, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(147, 20);
            this.txtNombre.TabIndex = 32;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(2, 40);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 31;
            this.lblNombre.Text = "Nombre";
            // 
            // grpIdentificarse
            // 
            this.grpIdentificarse.Controls.Add(this.groupBox3);
            this.grpIdentificarse.Controls.Add(this.groupBox2);
            this.grpIdentificarse.Location = new System.Drawing.Point(430, 31);
            this.grpIdentificarse.Name = "grpIdentificarse";
            this.grpIdentificarse.Size = new System.Drawing.Size(311, 283);
            this.grpIdentificarse.TabIndex = 7;
            this.grpIdentificarse.TabStop = false;
            this.grpIdentificarse.Text = "Identificarse";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtidnro);
            this.groupBox3.Controls.Add(this.cboidtipo);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(21, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 95);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // txtidnro
            // 
            this.txtidnro.Location = new System.Drawing.Point(59, 51);
            this.txtidnro.Name = "txtidnro";
            this.txtidnro.Size = new System.Drawing.Size(200, 20);
            this.txtidnro.TabIndex = 3;
            // 
            // cboidtipo
            // 
            this.cboidtipo.FormattingEnabled = true;
            this.cboidtipo.Location = new System.Drawing.Point(56, 24);
            this.cboidtipo.Name = "cboidtipo";
            this.cboidtipo.Size = new System.Drawing.Size(203, 21);
            this.cboidtipo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Numero";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tipo Id";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtidmail);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(21, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 101);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txtidmail
            // 
            this.txtidmail.Location = new System.Drawing.Point(54, 45);
            this.txtidmail.Name = "txtidmail";
            this.txtidmail.Size = new System.Drawing.Size(140, 20);
            this.txtidmail.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mail";
            // 
            // ConfirmarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 548);
            this.Controls.Add(this.grpIdentificarse);
            this.Controls.Add(this.grNuevoCliente);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.optRegis);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.optNuevo);
            this.Name = "ConfirmarReserva";
            this.Text = "ConfirmarReserva";
            this.Load += new System.EventHandler(this.ConfirmarReserva_Load);
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            this.grNuevoCliente.ResumeLayout(false);
            this.grNuevoCliente.PerformLayout();
            this.grpIdentificarse.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.GroupBox grMain;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.Label lblHab;
        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.RadioButton optNuevo;
        private System.Windows.Forms.RadioButton optRegis;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.GroupBox grNuevoCliente;
        private System.Windows.Forms.TextBox txtNroCalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPaisDirNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNacionalidadNuevo;
        private System.Windows.Forms.DateTimePicker dtfn2;
        private System.Windows.Forms.Label lblFNac;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNroId;
        private System.Windows.Forms.Label lblNroId;
        private System.Windows.Forms.ComboBox cboTipoIdNuevo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox grpIdentificarse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtidnro;
        private System.Windows.Forms.ComboBox cboidtipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtidmail;
        private System.Windows.Forms.Label label7;
    }
}