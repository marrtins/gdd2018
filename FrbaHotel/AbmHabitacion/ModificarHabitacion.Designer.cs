namespace FrbaHotel.AbmHabitacion
{
    partial class ModificarHabitacion
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
            this.limpiarBtn = new System.Windows.Forms.Button();
            this.modificarBtn = new System.Windows.Forms.Button();
            this.numHabInput = new System.Windows.Forms.TextBox();
            this.habilitadoInput = new System.Windows.Forms.CheckBox();
            this.hotelInput = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descripcionInput = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pisoInput = new System.Windows.Forms.TextBox();
            this.tipoHabInput = new System.Windows.Forms.TextBox();
            this.visExtInput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(11, 325);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(75, 23);
            this.limpiarBtn.TabIndex = 32;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.limpiarBtn_Click);
            // 
            // modificarBtn
            // 
            this.modificarBtn.Location = new System.Drawing.Point(173, 325);
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.Size = new System.Drawing.Size(75, 23);
            this.modificarBtn.TabIndex = 31;
            this.modificarBtn.Text = "Modificar";
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // numHabInput
            // 
            this.numHabInput.Location = new System.Drawing.Point(127, 10);
            this.numHabInput.Name = "numHabInput";
            this.numHabInput.Size = new System.Drawing.Size(121, 20);
            this.numHabInput.TabIndex = 30;
            // 
            // habilitadoInput
            // 
            this.habilitadoInput.AutoSize = true;
            this.habilitadoInput.Location = new System.Drawing.Point(127, 169);
            this.habilitadoInput.Name = "habilitadoInput";
            this.habilitadoInput.Size = new System.Drawing.Size(15, 14);
            this.habilitadoInput.TabIndex = 29;
            this.habilitadoInput.UseVisualStyleBackColor = true;
            // 
            // hotelInput
            // 
            this.hotelInput.FormattingEnabled = true;
            this.hotelInput.Location = new System.Drawing.Point(127, 67);
            this.hotelInput.Name = "hotelInput";
            this.hotelInput.Size = new System.Drawing.Size(121, 21);
            this.hotelInput.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Habilitado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descripcionInput);
            this.groupBox1.Location = new System.Drawing.Point(14, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 113);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descripcion";
            // 
            // descripcionInput
            // 
            this.descripcionInput.Location = new System.Drawing.Point(6, 19);
            this.descripcionInput.Name = "descripcionInput";
            this.descripcionInput.Size = new System.Drawing.Size(221, 90);
            this.descripcionInput.TabIndex = 0;
            this.descripcionInput.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Vista al Exterior";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Piso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tipo Habitacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Numero Habitacion";
            // 
            // pisoInput
            // 
            this.pisoInput.Location = new System.Drawing.Point(127, 100);
            this.pisoInput.Name = "pisoInput";
            this.pisoInput.Size = new System.Drawing.Size(121, 20);
            this.pisoInput.TabIndex = 43;
            // 
            // tipoHabInput
            // 
            this.tipoHabInput.Location = new System.Drawing.Point(127, 41);
            this.tipoHabInput.Name = "tipoHabInput";
            this.tipoHabInput.Size = new System.Drawing.Size(121, 20);
            this.tipoHabInput.TabIndex = 44;
            // 
            // visExtInput
            // 
            this.visExtInput.Location = new System.Drawing.Point(127, 134);
            this.visExtInput.Name = "visExtInput";
            this.visExtInput.Size = new System.Drawing.Size(121, 20);
            this.visExtInput.TabIndex = 45;
            // 
            // ModificarHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 361);
            this.Controls.Add(this.visExtInput);
            this.Controls.Add(this.tipoHabInput);
            this.Controls.Add(this.pisoInput);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.modificarBtn);
            this.Controls.Add(this.numHabInput);
            this.Controls.Add(this.habilitadoInput);
            this.Controls.Add(this.hotelInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificarHabitacion";
            this.Text = "ModificarHabitacion";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button modificarBtn;
        private System.Windows.Forms.TextBox numHabInput;
        private System.Windows.Forms.CheckBox habilitadoInput;
        private System.Windows.Forms.ComboBox hotelInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox descripcionInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pisoInput;
        private System.Windows.Forms.TextBox tipoHabInput;
        private System.Windows.Forms.TextBox visExtInput;
    }
}