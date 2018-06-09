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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.paisCombo = new System.Windows.Forms.ComboBox();
            this.cantidadEstrellasInput = new System.Windows.Forms.NumericUpDown();
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.ciudadInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.hotelesGridView = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.NombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadEstrellasCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaisCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeleccionarCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HabilitarCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadEstrellasInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.paisCombo);
            this.groupBox2.Controls.Add(this.cantidadEstrellasInput);
            this.groupBox2.Controls.Add(this.nombreInput);
            this.groupBox2.Controls.Add(this.ciudadInput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de búsqueda";
            // 
            // paisCombo
            // 
            this.paisCombo.FormattingEnabled = true;
            this.paisCombo.Location = new System.Drawing.Point(301, 39);
            this.paisCombo.Name = "paisCombo";
            this.paisCombo.Size = new System.Drawing.Size(149, 21);
            this.paisCombo.TabIndex = 3;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buscarBtn
            // 
            this.buscarBtn.Location = new System.Drawing.Point(568, 79);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(85, 23);
            this.buscarBtn.TabIndex = 2;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // hotelesGridView
            // 
            this.hotelesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hotelesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCol,
            this.CantidadEstrellasCol,
            this.MailCol,
            this.TelefonoCol,
            this.PaisCol,
            this.CiudadCol,
            this.CalleCol,
            this.NumeroCol,
            this.SeleccionarCol,
            this.HabilitarCol});
            this.hotelesGridView.Location = new System.Drawing.Point(9, 109);
            this.hotelesGridView.Name = "hotelesGridView";
            this.hotelesGridView.Size = new System.Drawing.Size(644, 290);
            this.hotelesGridView.TabIndex = 3;
            this.hotelesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hotelesGridView_CellClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(487, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Alta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NombreCol
            // 
            this.NombreCol.DataPropertyName = "Nombre";
            this.NombreCol.HeaderText = "Nombre";
            this.NombreCol.Name = "NombreCol";
            // 
            // CantidadEstrellasCol
            // 
            this.CantidadEstrellasCol.DataPropertyName = "CantidadEstrellas";
            this.CantidadEstrellasCol.HeaderText = "Cantidad Estrellas";
            this.CantidadEstrellasCol.Name = "CantidadEstrellasCol";
            // 
            // MailCol
            // 
            this.MailCol.DataPropertyName = "Mail";
            this.MailCol.HeaderText = "Mail";
            this.MailCol.Name = "MailCol";
            // 
            // TelefonoCol
            // 
            this.TelefonoCol.DataPropertyName = "Telefono";
            this.TelefonoCol.HeaderText = "Telefono";
            this.TelefonoCol.Name = "TelefonoCol";
            // 
            // PaisCol
            // 
            this.PaisCol.DataPropertyName = "NombrePais";
            this.PaisCol.HeaderText = "Pais";
            this.PaisCol.Name = "PaisCol";
            // 
            // CiudadCol
            // 
            this.CiudadCol.DataPropertyName = "Ciudad";
            this.CiudadCol.HeaderText = "Ciudad";
            this.CiudadCol.Name = "CiudadCol";
            // 
            // CalleCol
            // 
            this.CalleCol.DataPropertyName = "Calle";
            this.CalleCol.HeaderText = "Calle";
            this.CalleCol.Name = "CalleCol";
            // 
            // NumeroCol
            // 
            this.NumeroCol.DataPropertyName = "NroCalle";
            this.NumeroCol.HeaderText = "Numero";
            this.NumeroCol.Name = "NumeroCol";
            // 
            // SeleccionarCol
            // 
            this.SeleccionarCol.HeaderText = "Seleccionar";
            this.SeleccionarCol.Name = "SeleccionarCol";
            // 
            // HabilitarCol
            // 
            this.HabilitarCol.HeaderText = "Habilitado";
            this.HabilitarCol.Name = "HabilitarCol";
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 411);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.hotelesGridView);
            this.Controls.Add(this.buscarBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Listado";
            this.Text = "Listado";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadEstrellasInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.TextBox ciudadInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cantidadEstrellasInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox paisCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.DataGridView hotelesGridView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadEstrellasCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaisCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeleccionarCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HabilitarCol;
    }
}