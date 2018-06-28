namespace FrbaHotel.RegistrarEstadia
{
    partial class ModificarCheckInInconsistente
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCheckInActual = new System.Windows.Forms.Label();
            this.lblFechaCheckOut = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(95, 256);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 35);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(377, 255);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(135, 36);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Aceptar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "La estadia para la reserva seleccionada, presenta información inconsistente.";
            // 
            // lblCheckInActual
            // 
            this.lblCheckInActual.AutoSize = true;
            this.lblCheckInActual.Location = new System.Drawing.Point(93, 108);
            this.lblCheckInActual.Name = "lblCheckInActual";
            this.lblCheckInActual.Size = new System.Drawing.Size(89, 13);
            this.lblCheckInActual.TabIndex = 8;
            this.lblCheckInActual.Text = "Fecha Check In: ";
            // 
            // lblFechaCheckOut
            // 
            this.lblFechaCheckOut.AutoSize = true;
            this.lblFechaCheckOut.Location = new System.Drawing.Point(92, 134);
            this.lblFechaCheckOut.Name = "lblFechaCheckOut";
            this.lblFechaCheckOut.Size = new System.Drawing.Size(94, 13);
            this.lblFechaCheckOut.TabIndex = 9;
            this.lblFechaCheckOut.Text = "Fecha Check Out:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Para dejar la estadia en un estado consistente, se modificará la fecha de check i" +
    "n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(448, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = " y se eliminará la fecha de check out a fin de poder estipularla cuando sea neces" +
    "aria. Gracias";
            // 
            // ModificarCheckInInconsistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 334);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFechaCheckOut);
            this.Controls.Add(this.lblCheckInActual);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label1);
            this.Name = "ModificarCheckInInconsistente";
            this.Text = "ModificarCheckInInconsistente";
            this.Load += new System.EventHandler(this.ModificarCheckInInconsistente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCheckInActual;
        private System.Windows.Forms.Label lblFechaCheckOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}