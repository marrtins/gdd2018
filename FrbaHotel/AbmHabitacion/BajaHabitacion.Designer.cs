namespace FrbaHotel.AbmHabitacion
{
    partial class BajaHabitacion
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
            this.borrarBtn = new System.Windows.Forms.Button();
            this.numHabInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoHabInput = new System.Windows.Forms.TextBox();
            this.vistaExtInput = new System.Windows.Forms.TextBox();
            this.hotelInput = new System.Windows.Forms.ComboBox();
            this.pisoInput = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descripcionInput = new System.Windows.Forms.RichTextBox();
            this.habitacionInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(9, 290);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(75, 23);
            this.limpiarBtn.TabIndex = 32;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.limpiarBtn_Click);
            // 
            // borrarBtn
            // 
            this.borrarBtn.Location = new System.Drawing.Point(171, 290);
            this.borrarBtn.Name = "borrarBtn";
            this.borrarBtn.Size = new System.Drawing.Size(75, 23);
            this.borrarBtn.TabIndex = 31;
            this.borrarBtn.Text = "Borrar";
            this.borrarBtn.UseVisualStyleBackColor = true;
            this.borrarBtn.Click += new System.EventHandler(this.borrarBtn_Click);
            // 
            // numHabInput
            // 
            this.numHabInput.Location = new System.Drawing.Point(125, 43);
            this.numHabInput.Name = "numHabInput";
            this.numHabInput.Size = new System.Drawing.Size(121, 20);
            this.numHabInput.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Vista al Exterior";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Piso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tipo Habitacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Numero Habitacion";
            // 
            // tipoHabInput
            // 
            this.tipoHabInput.Location = new System.Drawing.Point(125, 72);
            this.tipoHabInput.Name = "tipoHabInput";
            this.tipoHabInput.Size = new System.Drawing.Size(121, 20);
            this.tipoHabInput.TabIndex = 33;
            // 
            // vistaExtInput
            // 
            this.vistaExtInput.Location = new System.Drawing.Point(125, 160);
            this.vistaExtInput.Name = "vistaExtInput";
            this.vistaExtInput.Size = new System.Drawing.Size(121, 20);
            this.vistaExtInput.TabIndex = 36;
            // 
            // hotelInput
            // 
            this.hotelInput.FormattingEnabled = true;
            this.hotelInput.Location = new System.Drawing.Point(125, 103);
            this.hotelInput.Name = "hotelInput";
            this.hotelInput.Size = new System.Drawing.Size(121, 21);
            this.hotelInput.TabIndex = 37;
            // 
            // pisoInput
            // 
            this.pisoInput.FormattingEnabled = true;
            this.pisoInput.Location = new System.Drawing.Point(125, 133);
            this.pisoInput.Name = "pisoInput";
            this.pisoInput.Size = new System.Drawing.Size(121, 21);
            this.pisoInput.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descripcionInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 78);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descripcion";
            // 
            // descripcionInput
            // 
            this.descripcionInput.Location = new System.Drawing.Point(6, 17);
            this.descripcionInput.Name = "descripcionInput";
            this.descripcionInput.Size = new System.Drawing.Size(221, 48);
            this.descripcionInput.TabIndex = 0;
            this.descripcionInput.Text = "";
            // 
            // habitacionInput
            // 
            this.habitacionInput.Location = new System.Drawing.Point(125, 12);
            this.habitacionInput.Name = "habitacionInput";
            this.habitacionInput.Size = new System.Drawing.Size(121, 20);
            this.habitacionInput.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Habitacion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 21);
            this.button1.TabIndex = 42;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BajaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.habitacionInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pisoInput);
            this.Controls.Add(this.hotelInput);
            this.Controls.Add(this.vistaExtInput);
            this.Controls.Add(this.tipoHabInput);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.borrarBtn);
            this.Controls.Add(this.numHabInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BajaHabitacion";
            this.Text = "BajaHabitacion";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button borrarBtn;
        private System.Windows.Forms.TextBox numHabInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tipoHabInput;
        private System.Windows.Forms.TextBox vistaExtInput;
        private System.Windows.Forms.ComboBox hotelInput;
        private System.Windows.Forms.ComboBox pisoInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox descripcionInput;
        private System.Windows.Forms.TextBox habitacionInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}