namespace FrbaHotel.AbmHotel
{
    partial class Baja
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
            this.fechaInicioDtp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaFinDtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.motivoInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fechaInicioDtp
            // 
            this.fechaInicioDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicioDtp.Location = new System.Drawing.Point(98, 6);
            this.fechaInicioDtp.Name = "fechaInicioDtp";
            this.fechaInicioDtp.Size = new System.Drawing.Size(106, 20);
            this.fechaInicioDtp.TabIndex = 0;
            this.fechaInicioDtp.Value = new System.DateTime(2018, 6, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha de inicio";
            // 
            // fechaFinDtp
            // 
            this.fechaFinDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFinDtp.Location = new System.Drawing.Point(98, 49);
            this.fechaFinDtp.Name = "fechaFinDtp";
            this.fechaFinDtp.Size = new System.Drawing.Size(106, 20);
            this.fechaFinDtp.TabIndex = 0;
            this.fechaFinDtp.Value = new System.DateTime(2018, 6, 27, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de fin";
            // 
            // motivoInput
            // 
            this.motivoInput.Location = new System.Drawing.Point(98, 97);
            this.motivoInput.Multiline = true;
            this.motivoInput.Name = "motivoInput";
            this.motivoInput.Size = new System.Drawing.Size(200, 73);
            this.motivoInput.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Motivo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(12, 203);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarBtn.TabIndex = 3;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 238);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.motivoInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaFinDtp);
            this.Controls.Add(this.fechaInicioDtp);
            this.Name = "Baja";
            this.Text = "Baja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fechaInicioDtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechaFinDtp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox motivoInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelarBtn;
    }
}