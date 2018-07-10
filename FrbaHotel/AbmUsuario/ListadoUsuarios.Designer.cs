namespace FrbaHotel.AbmUsuario
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
            this.UsernameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumentoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumentoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreRolCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeleccionarCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosGridView)).BeginInit();
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
            this.UsernameCol,
            this.NombreCol,
            this.ApellidoCol,
            this.MailCol,
            this.NroDocumentoCol,
            this.TipoDocumentoCol,
            this.NombreRolCol,
            this.SeleccionarCol});
            this.usuariosGridView.Location = new System.Drawing.Point(12, 12);
            this.usuariosGridView.Name = "usuariosGridView";
            this.usuariosGridView.ReadOnly = true;
            this.usuariosGridView.RowHeadersWidth = 40;
            this.usuariosGridView.Size = new System.Drawing.Size(842, 290);
            this.usuariosGridView.TabIndex = 4;
            // 
            // UsernameCol
            // 
            this.UsernameCol.DataPropertyName = "Username";
            this.UsernameCol.HeaderText = "Username";
            this.UsernameCol.Name = "UsernameCol";
            this.UsernameCol.ReadOnly = true;
            // 
            // NombreCol
            // 
            this.NombreCol.DataPropertyName = "Nombre";
            this.NombreCol.HeaderText = "Nombre";
            this.NombreCol.Name = "NombreCol";
            this.NombreCol.ReadOnly = true;
            // 
            // ApellidoCol
            // 
            this.ApellidoCol.DataPropertyName = "Apellido";
            this.ApellidoCol.HeaderText = "Apellido";
            this.ApellidoCol.Name = "ApellidoCol";
            this.ApellidoCol.ReadOnly = true;
            // 
            // MailCol
            // 
            this.MailCol.DataPropertyName = "Mail";
            this.MailCol.HeaderText = "Mail";
            this.MailCol.Name = "MailCol";
            this.MailCol.ReadOnly = true;
            // 
            // NroDocumentoCol
            // 
            this.NroDocumentoCol.DataPropertyName = "NroDocumento";
            this.NroDocumentoCol.HeaderText = "Numero de Documento";
            this.NroDocumentoCol.Name = "NroDocumentoCol";
            this.NroDocumentoCol.ReadOnly = true;
            // 
            // TipoDocumentoCol
            // 
            this.TipoDocumentoCol.DataPropertyName = "TipoDocumento";
            this.TipoDocumentoCol.HeaderText = "Tipo Documento";
            this.TipoDocumentoCol.Name = "TipoDocumentoCol";
            this.TipoDocumentoCol.ReadOnly = true;
            // 
            // NombreRolCol
            // 
            this.NombreRolCol.DataPropertyName = "NombreRol";
            this.NombreRolCol.HeaderText = "Rol";
            this.NombreRolCol.Name = "NombreRolCol";
            this.NombreRolCol.ReadOnly = true;
            // 
            // SeleccionarCol
            // 
            this.SeleccionarCol.HeaderText = "Seleccionar";
            this.SeleccionarCol.Name = "SeleccionarCol";
            this.SeleccionarCol.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(870, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usuariosGridView);
            this.Name = "ListadoUsuarios";
            this.Text = "Listado de Usuarios";
            this.Shown += new System.EventHandler(this.ListadoUsuarios_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosGridView)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.DataGridView usuariosGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsernameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumentoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumentoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreRolCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeleccionarCol;
        private System.Windows.Forms.Button button1;
    }
}