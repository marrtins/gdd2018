namespace FrbaHotel.AbmHotel
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.limpiarBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cantidadEstrellasInput = new System.Windows.Forms.NumericUpDown();
            this.telefonoInput = new System.Windows.Forms.TextBox();
            this.mailInput = new System.Windows.Forms.TextBox();
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paisCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nroInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.calleInput = new System.Windows.Forms.TextBox();
            this.ciudadInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.recEstrellasInput = new System.Windows.Forms.TextBox();
            this.FechaCreacionDtp = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadEstrellasInput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(407, 227);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(322, 227);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(75, 23);
            this.limpiarBtn.TabIndex = 2;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.limpiarBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cantidadEstrellasInput
            // 
            this.cantidadEstrellasInput.Location = new System.Drawing.Point(397, 55);
            this.cantidadEstrellasInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cantidadEstrellasInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidadEstrellasInput.Name = "cantidadEstrellasInput";
            this.cantidadEstrellasInput.Size = new System.Drawing.Size(85, 20);
            this.cantidadEstrellasInput.TabIndex = 12;
            this.cantidadEstrellasInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // telefonoInput
            // 
            this.telefonoInput.Location = new System.Drawing.Point(312, 12);
            this.telefonoInput.Name = "telefonoInput";
            this.telefonoInput.Size = new System.Drawing.Size(170, 20);
            this.telefonoInput.TabIndex = 11;
            // 
            // mailInput
            // 
            this.mailInput.Location = new System.Drawing.Point(80, 55);
            this.mailInput.Name = "mailInput";
            this.mailInput.Size = new System.Drawing.Size(158, 20);
            this.mailInput.TabIndex = 9;
            // 
            // nombreInput
            // 
            this.nombreInput.Location = new System.Drawing.Point(80, 12);
            this.nombreInput.Name = "nombreInput";
            this.nombreInput.Size = new System.Drawing.Size(158, 20);
            this.nombreInput.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cantidad de estrellas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Telefono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // paisCombo
            // 
            this.paisCombo.DisplayMember = "Nombre";
            this.paisCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paisCombo.FormattingEnabled = true;
            this.paisCombo.Location = new System.Drawing.Point(312, 97);
            this.paisCombo.Name = "paisCombo";
            this.paisCombo.Size = new System.Drawing.Size(170, 21);
            this.paisCombo.TabIndex = 20;
            this.paisCombo.ValueMember = "idPais";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Pais";
            // 
            // nroInput
            // 
            this.nroInput.Location = new System.Drawing.Point(397, 137);
            this.nroInput.Name = "nroInput";
            this.nroInput.Size = new System.Drawing.Size(85, 20);
            this.nroInput.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Numero";
            // 
            // calleInput
            // 
            this.calleInput.Location = new System.Drawing.Point(80, 141);
            this.calleInput.Name = "calleInput";
            this.calleInput.Size = new System.Drawing.Size(158, 20);
            this.calleInput.TabIndex = 15;
            // 
            // ciudadInput
            // 
            this.ciudadInput.Location = new System.Drawing.Point(80, 97);
            this.ciudadInput.Name = "ciudadInput";
            this.ciudadInput.Size = new System.Drawing.Size(158, 20);
            this.ciudadInput.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Calle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ciudad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Recarga Estrellas";
            // 
            // recEstrellasInput
            // 
            this.recEstrellasInput.Location = new System.Drawing.Point(153, 181);
            this.recEstrellasInput.Name = "recEstrellasInput";
            this.recEstrellasInput.Size = new System.Drawing.Size(85, 20);
            this.recEstrellasInput.TabIndex = 23;
            // 
            // FechaCreacionDtp
            // 
            this.FechaCreacionDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaCreacionDtp.Location = new System.Drawing.Point(397, 181);
            this.FechaCreacionDtp.Name = "FechaCreacionDtp";
            this.FechaCreacionDtp.Size = new System.Drawing.Size(85, 20);
            this.FechaCreacionDtp.TabIndex = 24;
            this.FechaCreacionDtp.Value = new System.DateTime(2018, 6, 28, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Fecha de creacion";
            // 
            // InsertarModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 262);
            this.Controls.Add(this.FechaCreacionDtp);
            this.Controls.Add(this.recEstrellasInput);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.paisCombo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nroInput);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.calleInput);
            this.Controls.Add(this.ciudadInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cantidadEstrellasInput);
            this.Controls.Add(this.telefonoInput);
            this.Controls.Add(this.mailInput);
            this.Controls.Add(this.nombreInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.btnAceptar);
            this.Name = "InsertarModificar";
            this.Text = "Insertar";
            ((System.ComponentModel.ISupportInitialize)(this.cantidadEstrellasInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown cantidadEstrellasInput;
        private System.Windows.Forms.TextBox telefonoInput;
        private System.Windows.Forms.TextBox mailInput;
        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox paisCombo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nroInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox calleInput;
        private System.Windows.Forms.TextBox ciudadInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox recEstrellasInput;
        private System.Windows.Forms.DateTimePicker FechaCreacionDtp;
        private System.Windows.Forms.Label label9;
    }
}