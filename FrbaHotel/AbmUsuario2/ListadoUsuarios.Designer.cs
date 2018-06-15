namespace FrbaHotel.AbmUsuario2
{
    partial class ListadoUsuarios
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
            this.usuariosGridView = new System.Windows.Forms.DataGridView();
            this.NombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadEstrellasCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaisCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HabilitadoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeleccionarCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpoFiltros = new System.Windows.Forms.GroupBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.mailInput = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.nroDocumentoInput = new System.Windows.Forms.TextBox();
            this.lblNro = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblTipoId = new System.Windows.Forms.Label();
            this.apellidoInput = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.idRol = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosGridView)).BeginInit();
            this.gpoFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // usuariosGridView
            // 
            this.usuariosGridView.AllowUserToAddRows = false;
            this.usuariosGridView.AllowUserToDeleteRows = false;
            this.usuariosGridView.AllowUserToOrderColumns = true;
            this.usuariosGridView.AllowUserToResizeRows = false;
            this.usuariosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuariosGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCol,
            this.CantidadEstrellasCol,
            this.MailCol,
            this.NumeroCol,
            this.NroDocumento,
            this.TelefonoCol,
            this.PaisCol,
            this.CiudadCol,
            this.CalleCol,
            this.HabilitadoCol,
            this.SeleccionarCol});
            this.usuariosGridView.Location = new System.Drawing.Point(12, 215);
            this.usuariosGridView.Name = "usuariosGridView";
            this.usuariosGridView.ReadOnly = true;
            this.usuariosGridView.RowHeadersWidth = 40;
            this.usuariosGridView.Size = new System.Drawing.Size(842, 290);
            this.usuariosGridView.TabIndex = 4;
            // 
            // NombreCol
            // 
            this.NombreCol.DataPropertyName = "Username";
            this.NombreCol.HeaderText = "Username";
            this.NombreCol.Name = "NombreCol";
            this.NombreCol.ReadOnly = true;
            // 
            // CantidadEstrellasCol
            // 
            this.CantidadEstrellasCol.DataPropertyName = "Nombre";
            this.CantidadEstrellasCol.HeaderText = "Nombre";
            this.CantidadEstrellasCol.Name = "CantidadEstrellasCol";
            this.CantidadEstrellasCol.ReadOnly = true;
            // 
            // MailCol
            // 
            this.MailCol.DataPropertyName = "Apellido";
            this.MailCol.HeaderText = "Apellido";
            this.MailCol.Name = "MailCol";
            this.MailCol.ReadOnly = true;
            // 
            // NumeroCol
            // 
            this.NumeroCol.DataPropertyName = "tipoDocumento";
            this.NumeroCol.HeaderText = "Tipo Documento";
            this.NumeroCol.Name = "NumeroCol";
            this.NumeroCol.ReadOnly = true;
            // 
            // NroDocumento
            // 
            this.NroDocumento.HeaderText = "Numero de Documento";
            this.NroDocumento.Name = "NroDocumento";
            this.NroDocumento.ReadOnly = true;
            // 
            // TelefonoCol
            // 
            this.TelefonoCol.DataPropertyName = "Mail";
            this.TelefonoCol.HeaderText = "Mail";
            this.TelefonoCol.Name = "TelefonoCol";
            this.TelefonoCol.ReadOnly = true;
            // 
            // PaisCol
            // 
            this.PaisCol.DataPropertyName = "NombreRol";
            this.PaisCol.HeaderText = "Rol";
            this.PaisCol.Name = "PaisCol";
            this.PaisCol.ReadOnly = true;
            // 
            // CiudadCol
            // 
            this.CiudadCol.DataPropertyName = "Calle";
            this.CiudadCol.HeaderText = "Calle";
            this.CiudadCol.Name = "CiudadCol";
            this.CiudadCol.ReadOnly = true;
            // 
            // CalleCol
            // 
            this.CalleCol.DataPropertyName = "NroCalle";
            this.CalleCol.HeaderText = "NroCalle";
            this.CalleCol.Name = "CalleCol";
            this.CalleCol.ReadOnly = true;
            // 
            // HabilitadoCol
            // 
            this.HabilitadoCol.DataPropertyName = "ActivoTexto";
            this.HabilitadoCol.HeaderText = "Activo";
            this.HabilitadoCol.Name = "HabilitadoCol";
            this.HabilitadoCol.ReadOnly = true;
            // 
            // SeleccionarCol
            // 
            this.SeleccionarCol.HeaderText = "Seleccionar";
            this.SeleccionarCol.Name = "SeleccionarCol";
            this.SeleccionarCol.ReadOnly = true;
            // 
            // gpoFiltros
            // 
            this.gpoFiltros.Controls.Add(this.btnAlta);
            this.gpoFiltros.Controls.Add(this.cboRol);
            this.gpoFiltros.Controls.Add(this.idRol);
            this.gpoFiltros.Controls.Add(this.usernameInput);
            this.gpoFiltros.Controls.Add(this.lblUsername);
            this.gpoFiltros.Controls.Add(this.btnLimpiar);
            this.gpoFiltros.Controls.Add(this.btnBuscar);
            this.gpoFiltros.Controls.Add(this.mailInput);
            this.gpoFiltros.Controls.Add(this.lblMail);
            this.gpoFiltros.Controls.Add(this.nroDocumentoInput);
            this.gpoFiltros.Controls.Add(this.lblNro);
            this.gpoFiltros.Controls.Add(this.cboTipoDoc);
            this.gpoFiltros.Controls.Add(this.lblTipoId);
            this.gpoFiltros.Controls.Add(this.apellidoInput);
            this.gpoFiltros.Controls.Add(this.lblApellido);
            this.gpoFiltros.Controls.Add(this.nombreInput);
            this.gpoFiltros.Controls.Add(this.lblNombre);
            this.gpoFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gpoFiltros.Location = new System.Drawing.Point(12, 12);
            this.gpoFiltros.Name = "gpoFiltros";
            this.gpoFiltros.Size = new System.Drawing.Size(842, 194);
            this.gpoFiltros.TabIndex = 5;
            this.gpoFiltros.TabStop = false;
            this.gpoFiltros.Text = "Filtros de b�squeda";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(105, 30);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(139, 23);
            this.usernameInput.TabIndex = 13;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(17, 33);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Username";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(105, 144);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(125, 35);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(670, 144);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(125, 35);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // mailInput
            // 
            this.mailInput.Location = new System.Drawing.Point(137, 68);
            this.mailInput.Name = "mailInput";
            this.mailInput.Size = new System.Drawing.Size(107, 23);
            this.mailInput.TabIndex = 9;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(17, 71);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(33, 17);
            this.lblMail.TabIndex = 8;
            this.lblMail.Text = "Mail";
            // 
            // nroDocumentoInput
            // 
            this.nroDocumentoInput.Location = new System.Drawing.Point(670, 60);
            this.nroDocumentoInput.Name = "nroDocumentoInput";
            this.nroDocumentoInput.Size = new System.Drawing.Size(107, 23);
            this.nroDocumentoInput.TabIndex = 7;
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(510, 63);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(141, 17);
            this.lblNro.TabIndex = 6;
            this.lblNro.Text = "Nro. de Identificaci�n";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(670, 30);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(107, 24);
            this.cboTipoDoc.TabIndex = 5;
            this.cboTipoDoc.Text = "Seleccionar";
            // 
            // lblTipoId
            // 
            this.lblTipoId.AutoSize = true;
            this.lblTipoId.Location = new System.Drawing.Point(510, 33);
            this.lblTipoId.Name = "lblTipoId";
            this.lblTipoId.Size = new System.Drawing.Size(142, 17);
            this.lblTipoId.TabIndex = 4;
            this.lblTipoId.Text = "Tipo de Identificaci�n";
            // 
            // apellidoInput
            // 
            this.apellidoInput.Location = new System.Drawing.Point(349, 65);
            this.apellidoInput.Name = "apellidoInput";
            this.apellidoInput.Size = new System.Drawing.Size(139, 23);
            this.apellidoInput.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(270, 71);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // nombreInput
            // 
            this.nombreInput.Location = new System.Drawing.Point(349, 30);
            this.nombreInput.Name = "nombreInput";
            this.nombreInput.Size = new System.Drawing.Size(139, 23);
            this.nombreInput.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(270, 33);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // cboRol
            // 
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(670, 99);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(107, 24);
            this.cboRol.TabIndex = 15;
            this.cboRol.Text = "Seleccionar";
            // 
            // idRol
            // 
            this.idRol.AutoSize = true;
            this.idRol.Location = new System.Drawing.Point(510, 102);
            this.idRol.Name = "idRol";
            this.idRol.Size = new System.Drawing.Size(29, 17);
            this.idRol.TabIndex = 14;
            this.idRol.Text = "Rol";
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(498, 144);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(125, 35);
            this.btnAlta.TabIndex = 16;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            // 
            // ListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(870, 517);
            this.Controls.Add(this.gpoFiltros);
            this.Controls.Add(this.usuariosGridView);
            this.Name = "ListadoUsuarios";
            this.Text = "Listado de Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.usuariosGridView)).EndInit();
            this.gpoFiltros.ResumeLayout(false);
            this.gpoFiltros.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.DataGridView usuariosGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadEstrellasCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaisCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HabilitadoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeleccionarCol;
        private System.Windows.Forms.GroupBox gpoFiltros;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox mailInput;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox nroDocumentoInput;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.Label lblTipoId;
        private System.Windows.Forms.TextBox apellidoInput;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label idRol;
        private System.Windows.Forms.Button btnAlta;
        
    }
}