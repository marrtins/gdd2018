namespace FrbaHotel.AbmRol
{
    partial class InsertarModificar
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
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.funcionalidadesGrid = new System.Windows.Forms.DataGridView();
            this.DescripcionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionalidadesCombo = new System.Windows.Forms.ComboBox();
            this.quitarBtn = new System.Windows.Forms.Button();
            this.agregarBtn = new System.Windows.Forms.Button();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreInput
            // 
            this.nombreInput.Location = new System.Drawing.Point(96, 13);
            this.nombreInput.Name = "nombreInput";
            this.nombreInput.Size = new System.Drawing.Size(173, 20);
            this.nombreInput.TabIndex = 0;
            // 
            // funcionalidadesGrid
            // 
            this.funcionalidadesGrid.AllowUserToAddRows = false;
            this.funcionalidadesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.funcionalidadesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.funcionalidadesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescripcionCol});
            this.funcionalidadesGrid.Location = new System.Drawing.Point(96, 56);
            this.funcionalidadesGrid.Name = "funcionalidadesGrid";
            this.funcionalidadesGrid.RowHeadersVisible = false;
            this.funcionalidadesGrid.Size = new System.Drawing.Size(173, 150);
            this.funcionalidadesGrid.TabIndex = 1;
            this.funcionalidadesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.funcionalidadesGrid_CellClick);
            // 
            // DescripcionCol
            // 
            this.DescripcionCol.DataPropertyName = "Descripcion";
            this.DescripcionCol.HeaderText = "Descripcion";
            this.DescripcionCol.Name = "DescripcionCol";
            // 
            // funcionalidadesCombo
            // 
            this.funcionalidadesCombo.DisplayMember = "Descripcion";
            this.funcionalidadesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.funcionalidadesCombo.FormattingEnabled = true;
            this.funcionalidadesCombo.Location = new System.Drawing.Point(96, 228);
            this.funcionalidadesCombo.Name = "funcionalidadesCombo";
            this.funcionalidadesCombo.Size = new System.Drawing.Size(173, 21);
            this.funcionalidadesCombo.TabIndex = 2;
            this.funcionalidadesCombo.ValueMember = "idFuncionalidad";
            this.funcionalidadesCombo.SelectedValueChanged += new System.EventHandler(this.funcionalidadesCombo_SelectedValueChanged);
            // 
            // quitarBtn
            // 
            this.quitarBtn.Location = new System.Drawing.Point(96, 256);
            this.quitarBtn.Name = "quitarBtn";
            this.quitarBtn.Size = new System.Drawing.Size(75, 23);
            this.quitarBtn.TabIndex = 3;
            this.quitarBtn.Text = "Quitar";
            this.quitarBtn.UseVisualStyleBackColor = true;
            this.quitarBtn.Click += new System.EventHandler(this.quitarBtn_Click);
            // 
            // agregarBtn
            // 
            this.agregarBtn.Location = new System.Drawing.Point(194, 256);
            this.agregarBtn.Name = "agregarBtn";
            this.agregarBtn.Size = new System.Drawing.Size(75, 23);
            this.agregarBtn.TabIndex = 3;
            this.agregarBtn.Text = "Agregar";
            this.agregarBtn.UseVisualStyleBackColor = true;
            this.agregarBtn.Click += new System.EventHandler(this.agregarBtn_Click);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Checked = true;
            this.activoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheck.Location = new System.Drawing.Point(9, 285);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(56, 17);
            this.activoCheck.TabIndex = 4;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Funcionalidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(199, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Aceptar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 320);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // InsertarModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 355);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.activoCheck);
            this.Controls.Add(this.agregarBtn);
            this.Controls.Add(this.quitarBtn);
            this.Controls.Add(this.funcionalidadesCombo);
            this.Controls.Add(this.funcionalidadesGrid);
            this.Controls.Add(this.nombreInput);
            this.Name = "InsertarModificar";
            this.Text = "Insertar";
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.DataGridView funcionalidadesGrid;
        private System.Windows.Forms.ComboBox funcionalidadesCombo;
        private System.Windows.Forms.Button quitarBtn;
        private System.Windows.Forms.Button agregarBtn;
        private System.Windows.Forms.CheckBox activoCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionCol;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}