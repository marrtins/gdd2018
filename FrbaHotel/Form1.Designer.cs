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
            this.rolButton = new System.Windows.Forms.Button();
            this.buttonHabitacion = new System.Windows.Forms.Button();
            this.buttonListadoEstadistico = new System.Windows.Forms.Button();
            this.abmUsuarioBtn = new System.Windows.Forms.Button();
            this.btnGenRes = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEstadia = new System.Windows.Forms.Button();
            this.btnConsumible = new System.Windows.Forms.Button();
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
            // rolButton
            // 
            this.rolButton.Location = new System.Drawing.Point(45, 122);
            this.rolButton.Name = "rolButton";
            this.rolButton.Size = new System.Drawing.Size(131, 57);
            this.rolButton.TabIndex = 2;
            this.rolButton.Text = "ABM Rol";
            this.rolButton.UseVisualStyleBackColor = true;
            this.rolButton.Click += new System.EventHandler(this.rolButton_Click);
            // 
            // buttonHabitacion
            // 
            this.buttonHabitacion.Location = new System.Drawing.Point(45, 185);
            this.buttonHabitacion.Name = "buttonHabitacion";
            this.buttonHabitacion.Size = new System.Drawing.Size(131, 57);
            this.buttonHabitacion.TabIndex = 3;
            this.buttonHabitacion.Text = "ABM Habitacion";
            this.buttonHabitacion.UseVisualStyleBackColor = true;
            this.buttonHabitacion.Click += new System.EventHandler(this.buttonHabitacion_Click);
            // 
            // buttonListadoEstadistico
            // 
            this.buttonListadoEstadistico.Location = new System.Drawing.Point(45, 311);
            this.buttonListadoEstadistico.Name = "buttonListadoEstadistico";
            this.buttonListadoEstadistico.Size = new System.Drawing.Size(131, 57);
            this.buttonListadoEstadistico.TabIndex = 4;
            this.buttonListadoEstadistico.Text = "Listado Estadistico";
            this.buttonListadoEstadistico.UseVisualStyleBackColor = true;
            this.buttonListadoEstadistico.Click += new System.EventHandler(this.buttonListadoEstadistico_Click);
            // 
            // abmUsuarioBtn
            // 
            this.abmUsuarioBtn.Location = new System.Drawing.Point(45, 248);
            this.abmUsuarioBtn.Name = "abmUsuarioBtn";
            this.abmUsuarioBtn.Size = new System.Drawing.Size(131, 57);
            this.abmUsuarioBtn.TabIndex = 5;
            this.abmUsuarioBtn.Text = "ABM Usuario";
            this.abmUsuarioBtn.UseVisualStyleBackColor = true;
            this.abmUsuarioBtn.Click += new System.EventHandler(this.abmUsuarioBtn_Click);
            // 
            // btnGenRes
            // 
            this.btnGenRes.Location = new System.Drawing.Point(266, 12);
            this.btnGenRes.Name = "btnGenRes";
            this.btnGenRes.Size = new System.Drawing.Size(129, 47);
            this.btnGenRes.TabIndex = 6;
            this.btnGenRes.Text = "Generar/Modificar Reserva";
            this.btnGenRes.UseVisualStyleBackColor = true;
            this.btnGenRes.Click += new System.EventHandler(this.btnGenRes_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(266, 67);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 44);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar Reserva";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEstadia
            // 
            this.btnEstadia.Location = new System.Drawing.Point(266, 122);
            this.btnEstadia.Name = "btnEstadia";
            this.btnEstadia.Size = new System.Drawing.Size(125, 44);
            this.btnEstadia.TabIndex = 8;
            this.btnEstadia.Text = "Registrar Estadía";
            this.btnEstadia.UseVisualStyleBackColor = true;
            this.btnEstadia.Click += new System.EventHandler(this.btnEstadia_Click);
            // 
            // btnConsumible
            // 
            this.btnConsumible.Location = new System.Drawing.Point(263, 185);
            this.btnConsumible.Name = "btnConsumible";
            this.btnConsumible.Size = new System.Drawing.Size(128, 41);
            this.btnConsumible.TabIndex = 9;
            this.btnConsumible.Text = "Registrar Consumible y Facturar";
            this.btnConsumible.UseVisualStyleBackColor = true;
            this.btnConsumible.Click += new System.EventHandler(this.btnConsumible_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 379);
            this.Controls.Add(this.btnConsumible);
            this.Controls.Add(this.btnEstadia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenRes);
            this.Controls.Add(this.abmUsuarioBtn);
            this.Controls.Add(this.buttonListadoEstadistico);
            this.Controls.Add(this.buttonHabitacion);
            this.Controls.Add(this.rolButton);
            this.Controls.Add(this.abmHotelBtn);
            this.Controls.Add(this.btnCliente);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button abmHotelBtn;
        private System.Windows.Forms.Button rolButton;
        private System.Windows.Forms.Button buttonHabitacion;
        private System.Windows.Forms.Button buttonListadoEstadistico;
        private System.Windows.Forms.Button abmUsuarioBtn;
        private System.Windows.Forms.Button btnGenRes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEstadia;
        private System.Windows.Forms.Button btnConsumible;
    }
}

