namespace FrbaHotel.AbmHotel
{
    partial class Listado
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
            this.filtrosGroup = new System.Windows.Forms.GroupBox();
            this.paisCombo = new System.Windows.Forms.ComboBox();
            this.cantidadEstrellasInput = new System.Windows.Forms.NumericUpDown();
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.ciudadInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.limpiarBtn = new System.Windows.Forms.Button();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.hotelesGridView = new System.Windows.Forms.DataGridView();
            this.NombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecargaEstrellasCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadEstrellasCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaisCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeleccionarCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BajaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.seleccionarBtn = new System.Windows.Forms.Button();
            this.filtrosGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadEstrellasInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filtrosGroup
            // 
            this.filtrosGroup.Controls.Add(this.paisCombo);
            this.filtrosGroup.Controls.Add(this.cantidadEstrellasInput);
            this.filtrosGroup.Controls.Add(this.nombreInput);
            this.filtrosGroup.Controls.Add(this.ciudadInput);
            this.filtrosGroup.Controls.Add(this.label3);
            this.filtrosGroup.Controls.Add(this.label6);
            this.filtrosGroup.Controls.Add(this.label5);
            this.filtrosGroup.Controls.Add(this.label4);
            this.filtrosGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtrosGroup.Location = new System.Drawing.Point(0, 0);
            this.filtrosGroup.Name = "filtrosGroup";
            this.filtrosGroup.Size = new System.Drawing.Size(977, 73);
            this.filtrosGroup.TabIndex = 1;
            this.filtrosGroup.TabStop = false;
            this.filtrosGroup.Text = "Filtros de búsqueda";
            // 
            // paisCombo
            // 
            this.paisCombo.DisplayMember = "Nombre";
            this.paisCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paisCombo.FormattingEnabled = true;
            this.paisCombo.Location = new System.Drawing.Point(301, 39);
            this.paisCombo.Name = "paisCombo";
            this.paisCombo.Size = new System.Drawing.Size(149, 21);
            this.paisCombo.TabIndex = 3;
            this.paisCombo.ValueMember = "idPais";
            // 
            // cantidadEstrellasInput
            // 
            this.cantidadEstrellasInput.Location = new System.Drawing.Point(117, 40);
            this.cantidadEstrellasInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cantidadEstrellasInput.Name = "cantidadEstrellasInput";
            this.cantidadEstrellasInput.Size = new System.Drawing.Size(88, 20);
            this.cantidadEstrellasInput.TabIndex = 2;
            this.cantidadEstrellasInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nombreInput
            // 
            this.nombreInput.Location = new System.Drawing.Point(56, 13);
            this.nombreInput.Name = "nombreInput";
            this.nombreInput.Size = new System.Drawing.Size(149, 20);
            this.nombreInput.TabIndex = 1;
            // 
            // ciudadInput
            // 
            this.ciudadInput.Location = new System.Drawing.Point(301, 13);
            this.ciudadInput.Name = "ciudadInput";
            this.ciudadInput.Size = new System.Drawing.Size(149, 20);
            this.ciudadInput.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cantidad de estrellas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pais";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ciudad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre";
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(9, 79);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(85, 23);
            this.limpiarBtn.TabIndex = 2;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.limpiarBtn_Click);
            // 
            // buscarBtn
            // 
            this.buscarBtn.Location = new System.Drawing.Point(880, 79);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(85, 23);
            this.buscarBtn.TabIndex = 2;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // hotelesGridView
            // 
            this.hotelesGridView.AllowUserToAddRows = false;
            this.hotelesGridView.AllowUserToDeleteRows = false;
            this.hotelesGridView.AllowUserToOrderColumns = true;
            this.hotelesGridView.AllowUserToResizeRows = false;
            this.hotelesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hotelesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCol,
            this.RecargaEstrellasCol,
            this.CantidadEstrellasCol,
            this.MailCol,
            this.TelefonoCol,
            this.PaisCol,
            this.CiudadCol,
            this.CalleCol,
            this.NumeroCol,
            this.FechaCreacionCol,
            this.SeleccionarCol,
            this.BajaCol});
            this.hotelesGridView.Location = new System.Drawing.Point(9, 109);
            this.hotelesGridView.MultiSelect = false;
            this.hotelesGridView.Name = "hotelesGridView";
            this.hotelesGridView.ReadOnly = true;
            this.hotelesGridView.RowHeadersWidth = 40;
            this.hotelesGridView.Size = new System.Drawing.Size(956, 290);
            this.hotelesGridView.TabIndex = 3;
            this.hotelesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hotelesGridView_CellClick);
            // 
            // NombreCol
            // 
            this.NombreCol.DataPropertyName = "Nombre";
            this.NombreCol.HeaderText = "Nombre";
            this.NombreCol.Name = "NombreCol";
            this.NombreCol.ReadOnly = true;
            // 
            // RecargaEstrellasCol
            // 
            this.RecargaEstrellasCol.DataPropertyName = "RecargaEstrellas";
            this.RecargaEstrellasCol.HeaderText = "Recarga Estrellas";
            this.RecargaEstrellasCol.Name = "RecargaEstrellasCol";
            this.RecargaEstrellasCol.ReadOnly = true;
            // 
            // CantidadEstrellasCol
            // 
            this.CantidadEstrellasCol.DataPropertyName = "CantidadEstrellas";
            this.CantidadEstrellasCol.HeaderText = "Cantidad Estrellas";
            this.CantidadEstrellasCol.Name = "CantidadEstrellasCol";
            this.CantidadEstrellasCol.ReadOnly = true;
            // 
            // MailCol
            // 
            this.MailCol.DataPropertyName = "Mail";
            this.MailCol.HeaderText = "Mail";
            this.MailCol.Name = "MailCol";
            this.MailCol.ReadOnly = true;
            // 
            // TelefonoCol
            // 
            this.TelefonoCol.DataPropertyName = "Telefono";
            this.TelefonoCol.HeaderText = "Telefono";
            this.TelefonoCol.Name = "TelefonoCol";
            this.TelefonoCol.ReadOnly = true;
            // 
            // PaisCol
            // 
            this.PaisCol.DataPropertyName = "NombrePais";
            this.PaisCol.HeaderText = "Pais";
            this.PaisCol.Name = "PaisCol";
            this.PaisCol.ReadOnly = true;
            // 
            // CiudadCol
            // 
            this.CiudadCol.DataPropertyName = "Ciudad";
            this.CiudadCol.HeaderText = "Ciudad";
            this.CiudadCol.Name = "CiudadCol";
            this.CiudadCol.ReadOnly = true;
            // 
            // CalleCol
            // 
            this.CalleCol.DataPropertyName = "Calle";
            this.CalleCol.HeaderText = "Calle";
            this.CalleCol.Name = "CalleCol";
            this.CalleCol.ReadOnly = true;
            // 
            // NumeroCol
            // 
            this.NumeroCol.DataPropertyName = "NroCalle";
            this.NumeroCol.HeaderText = "Numero";
            this.NumeroCol.Name = "NumeroCol";
            this.NumeroCol.ReadOnly = true;
            // 
            // FechaCreacionCol
            // 
            this.FechaCreacionCol.DataPropertyName = "FechaDeCreacion";
            this.FechaCreacionCol.HeaderText = "Fecha de Creacion";
            this.FechaCreacionCol.Name = "FechaCreacionCol";
            this.FechaCreacionCol.ReadOnly = true;
            // 
            // SeleccionarCol
            // 
            this.SeleccionarCol.HeaderText = "Seleccionar";
            this.SeleccionarCol.Name = "SeleccionarCol";
            this.SeleccionarCol.ReadOnly = true;
            // 
            // BajaCol
            // 
            this.BajaCol.HeaderText = "Baja";
            this.BajaCol.Name = "BajaCol";
            this.BajaCol.ReadOnly = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(799, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Alta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // seleccionarBtn
            // 
            this.seleccionarBtn.Location = new System.Drawing.Point(860, 405);
            this.seleccionarBtn.Name = "seleccionarBtn";
            this.seleccionarBtn.Size = new System.Drawing.Size(105, 23);
            this.seleccionarBtn.TabIndex = 6;
            this.seleccionarBtn.Text = "Seleccionar";
            this.seleccionarBtn.UseVisualStyleBackColor = true;
            this.seleccionarBtn.Click += new System.EventHandler(this.seleccionarBtn_Click);
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 435);
            this.Controls.Add(this.seleccionarBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.hotelesGridView);
            this.Controls.Add(this.buscarBtn);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.filtrosGroup);
            this.Name = "Listado";
            this.Text = "ABM de Hoteles";
            this.filtrosGroup.ResumeLayout(false);
            this.filtrosGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadEstrellasInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filtrosGroup;
        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.TextBox ciudadInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cantidadEstrellasInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox paisCombo;
        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.DataGridView hotelesGridView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecargaEstrellasCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadEstrellasCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaisCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeleccionarCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BajaCol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button seleccionarBtn;
    }
}