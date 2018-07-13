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
            this.clienteBtn = new System.Windows.Forms.Button();
            this.hotelBtn = new System.Windows.Forms.Button();
            this.rolBtn = new System.Windows.Forms.Button();
            this.habitacionBtn = new System.Windows.Forms.Button();
            this.estadisticoBtn = new System.Windows.Forms.Button();
            this.usuarioBtn = new System.Windows.Forms.Button();
            this.reservaAbmBtn = new System.Windows.Forms.Button();
            this.reservaCancelBtn = new System.Windows.Forms.Button();
            this.estadiaBtn = new System.Windows.Forms.Button();
            this.consumibleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clienteBtn
            // 
            this.clienteBtn.Location = new System.Drawing.Point(45, 12);
            this.clienteBtn.Name = "clienteBtn";
            this.clienteBtn.Size = new System.Drawing.Size(131, 49);
            this.clienteBtn.TabIndex = 0;
            this.clienteBtn.Text = "ABM Cliente";
            this.clienteBtn.UseVisualStyleBackColor = true;
            this.clienteBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // hotelBtn
            // 
            this.hotelBtn.Location = new System.Drawing.Point(45, 67);
            this.hotelBtn.Name = "hotelBtn";
            this.hotelBtn.Size = new System.Drawing.Size(131, 48);
            this.hotelBtn.TabIndex = 1;
            this.hotelBtn.Text = "ABM Hotel";
            this.hotelBtn.UseVisualStyleBackColor = true;
            this.hotelBtn.Click += new System.EventHandler(this.abmHotelBtn_Click);
            // 
            // rolBtn
            // 
            this.rolBtn.Location = new System.Drawing.Point(45, 122);
            this.rolBtn.Name = "rolBtn";
            this.rolBtn.Size = new System.Drawing.Size(131, 57);
            this.rolBtn.TabIndex = 2;
            this.rolBtn.Text = "ABM Rol";
            this.rolBtn.UseVisualStyleBackColor = true;
            this.rolBtn.Click += new System.EventHandler(this.rolButton_Click);
            // 
            // habitacionBtn
            // 
            this.habitacionBtn.Location = new System.Drawing.Point(45, 185);
            this.habitacionBtn.Name = "habitacionBtn";
            this.habitacionBtn.Size = new System.Drawing.Size(131, 57);
            this.habitacionBtn.TabIndex = 3;
            this.habitacionBtn.Text = "ABM Habitacion";
            this.habitacionBtn.UseVisualStyleBackColor = true;
            this.habitacionBtn.Click += new System.EventHandler(this.buttonHabitacion_Click);
            // 
            // estadisticoBtn
            // 
            this.estadisticoBtn.Location = new System.Drawing.Point(45, 311);
            this.estadisticoBtn.Name = "estadisticoBtn";
            this.estadisticoBtn.Size = new System.Drawing.Size(131, 57);
            this.estadisticoBtn.TabIndex = 4;
            this.estadisticoBtn.Text = "Listado Estadistico";
            this.estadisticoBtn.UseVisualStyleBackColor = true;
            this.estadisticoBtn.Click += new System.EventHandler(this.buttonListadoEstadistico_Click);
            // 
            // usuarioBtn
            // 
            this.usuarioBtn.Location = new System.Drawing.Point(45, 248);
            this.usuarioBtn.Name = "usuarioBtn";
            this.usuarioBtn.Size = new System.Drawing.Size(131, 57);
            this.usuarioBtn.TabIndex = 5;
            this.usuarioBtn.Text = "ABM Usuario";
            this.usuarioBtn.UseVisualStyleBackColor = true;
            this.usuarioBtn.Click += new System.EventHandler(this.abmUsuarioBtn_Click);
            // 
            // reservaAbmBtn
            // 
            this.reservaAbmBtn.Location = new System.Drawing.Point(266, 12);
            this.reservaAbmBtn.Name = "reservaAbmBtn";
            this.reservaAbmBtn.Size = new System.Drawing.Size(129, 47);
            this.reservaAbmBtn.TabIndex = 6;
            this.reservaAbmBtn.Text = "Generar/Modificar Reserva";
            this.reservaAbmBtn.UseVisualStyleBackColor = true;
            this.reservaAbmBtn.Click += new System.EventHandler(this.btnGenRes_Click);
            // 
            // reservaCancelBtn
            // 
            this.reservaCancelBtn.Location = new System.Drawing.Point(266, 67);
            this.reservaCancelBtn.Name = "reservaCancelBtn";
            this.reservaCancelBtn.Size = new System.Drawing.Size(125, 44);
            this.reservaCancelBtn.TabIndex = 7;
            this.reservaCancelBtn.Text = "Cancelar Reserva";
            this.reservaCancelBtn.UseVisualStyleBackColor = true;
            this.reservaCancelBtn.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // estadiaBtn
            // 
            this.estadiaBtn.Location = new System.Drawing.Point(266, 122);
            this.estadiaBtn.Name = "estadiaBtn";
            this.estadiaBtn.Size = new System.Drawing.Size(125, 44);
            this.estadiaBtn.TabIndex = 8;
            this.estadiaBtn.Text = "Registrar Estadía";
            this.estadiaBtn.UseVisualStyleBackColor = true;
            this.estadiaBtn.Click += new System.EventHandler(this.btnEstadia_Click);
            // 
            // consumibleBtn
            // 
            this.consumibleBtn.Location = new System.Drawing.Point(263, 185);
            this.consumibleBtn.Name = "consumibleBtn";
            this.consumibleBtn.Size = new System.Drawing.Size(128, 41);
            this.consumibleBtn.TabIndex = 9;
            this.consumibleBtn.Text = "Registrar Consumible y Facturar";
            this.consumibleBtn.UseVisualStyleBackColor = true;
            this.consumibleBtn.Click += new System.EventHandler(this.btnConsumible_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 379);
            this.Controls.Add(this.consumibleBtn);
            this.Controls.Add(this.estadiaBtn);
            this.Controls.Add(this.reservaCancelBtn);
            this.Controls.Add(this.reservaAbmBtn);
            this.Controls.Add(this.usuarioBtn);
            this.Controls.Add(this.estadisticoBtn);
            this.Controls.Add(this.habitacionBtn);
            this.Controls.Add(this.rolBtn);
            this.Controls.Add(this.hotelBtn);
            this.Controls.Add(this.clienteBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clienteBtn;
        private System.Windows.Forms.Button hotelBtn;
        private System.Windows.Forms.Button rolBtn;
        private System.Windows.Forms.Button habitacionBtn;
        private System.Windows.Forms.Button estadisticoBtn;
        private System.Windows.Forms.Button usuarioBtn;
        private System.Windows.Forms.Button reservaAbmBtn;
        private System.Windows.Forms.Button reservaCancelBtn;
        private System.Windows.Forms.Button estadiaBtn;
        private System.Windows.Forms.Button consumibleBtn;
    }
}

