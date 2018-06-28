namespace FrbaHotel.RegistrarConsumible
{
    partial class MainRegCons
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboHabitaciones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboConsumibles = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOtroConsumible = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCodRes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo Reserva:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboHabitaciones
            // 
            this.cboHabitaciones.FormattingEnabled = true;
            this.cboHabitaciones.Location = new System.Drawing.Point(1, 373);
            this.cboHabitaciones.Name = "cboHabitaciones";
            this.cboHabitaciones.Size = new System.Drawing.Size(10, 21);
            this.cboHabitaciones.TabIndex = 2;
            this.cboHabitaciones.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Consumible";
            // 
            // cboConsumibles
            // 
            this.cboConsumibles.FormattingEnabled = true;
            this.cboConsumibles.Location = new System.Drawing.Point(146, 111);
            this.cboConsumibles.Name = "cboConsumibles";
            this.cboConsumibles.Size = new System.Drawing.Size(160, 21);
            this.cboConsumibles.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad:";
            // 
            // btnOtroConsumible
            // 
            this.btnOtroConsumible.Location = new System.Drawing.Point(312, 111);
            this.btnOtroConsumible.Name = "btnOtroConsumible";
            this.btnOtroConsumible.Size = new System.Drawing.Size(51, 19);
            this.btnOtroConsumible.TabIndex = 7;
            this.btnOtroConsumible.Text = "Otro...";
            this.btnOtroConsumible.UseVisualStyleBackColor = true;
            this.btnOtroConsumible.Click += new System.EventHandler(this.btnOtroConsumible_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(284, 189);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(115, 41);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "Registrar Consumible/s";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(68, 304);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(76, 38);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ver Consumibles y Continuar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCodRes
            // 
            this.txtCodRes.Location = new System.Drawing.Point(146, 80);
            this.txtCodRes.Name = "txtCodRes";
            this.txtCodRes.Size = new System.Drawing.Size(163, 20);
            this.txtCodRes.TabIndex = 11;
            // 
            // MainRegCons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 395);
            this.Controls.Add(this.txtCodRes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnOtroConsumible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cboConsumibles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboHabitaciones);
            this.Controls.Add(this.label1);
            this.Name = "MainRegCons";
            this.Text = "MainRegCons";
            this.Load += new System.EventHandler(this.MainRegCons_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHabitaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboConsumibles;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOtroConsumible;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCodRes;
    }
}