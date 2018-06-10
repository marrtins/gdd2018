namespace FrbaHotel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCliente = new System.Windows.Forms.Button();
            this.abmHotelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(45, 12);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(131, 49);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "ABM Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // abmHotelBtn
            // 
            this.abmHotelBtn.Location = new System.Drawing.Point(45, 67);
            this.abmHotelBtn.Name = "abmHotelBtn";
            this.abmHotelBtn.Size = new System.Drawing.Size(131, 48);
            this.abmHotelBtn.TabIndex = 1;
            this.abmHotelBtn.Text = "ABM Hotel";
            this.abmHotelBtn.UseVisualStyleBackColor = true;
            this.abmHotelBtn.Click += new System.EventHandler(this.abmHotelBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 136);
            this.Controls.Add(this.abmHotelBtn);
            this.Controls.Add(this.btnCliente);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button abmHotelBtn;
    }
}

