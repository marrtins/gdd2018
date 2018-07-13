namespace FrbaHotel.RegistrarConsumible
{
    partial class AgregarConsumible
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
            this.cboConsumible = new System.Windows.Forms.ComboBox();
            this.lblConsumible = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboConsumible
            // 
            this.cboConsumible.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboConsumible.FormattingEnabled = true;
            this.cboConsumible.Location = new System.Drawing.Point(123, 15);
            this.cboConsumible.Name = "cboConsumible";
            this.cboConsumible.Size = new System.Drawing.Size(121, 24);
            this.cboConsumible.TabIndex = 0;
            this.cboConsumible.Text = "Seleccionar";
            // 
            // lblConsumible
            // 
            this.lblConsumible.AutoSize = true;
            this.lblConsumible.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblConsumible.Location = new System.Drawing.Point(20, 18);
            this.lblConsumible.Name = "lblConsumible";
            this.lblConsumible.Size = new System.Drawing.Size(81, 17);
            this.lblConsumible.TabIndex = 1;
            this.lblConsumible.Text = "Consumible";
            this.lblConsumible.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAceptar.Location = new System.Drawing.Point(68, 57);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(115, 35);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // AgregarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 107);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblConsumible);
            this.Controls.Add(this.cboConsumible);
            this.Name = "AgregarConsumible";
            this.Text = "Agregar Consumible";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboConsumible;
        private System.Windows.Forms.Label lblConsumible;
        private System.Windows.Forms.Button btnAceptar;
    }
}