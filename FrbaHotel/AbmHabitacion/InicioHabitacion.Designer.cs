namespace FrbaHotel.AbmHabitacion
{
    partial class InicioHabitacion
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.habilitadoInput = new System.Windows.Forms.TextBox();
            this.hotelInput = new System.Windows.Forms.TextBox();
            this.numHabInput = new System.Windows.Forms.TextBox();
            this.vistaExtInput = new System.Windows.Forms.TextBox();
            this.pisoInput = new System.Windows.Forms.TextBox();
            this.tipoHabInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numeroHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaAlExterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.habilitadoInput);
            this.groupBox1.Controls.Add(this.hotelInput);
            this.groupBox1.Controls.Add(this.numHabInput);
            this.groupBox1.Controls.Add(this.vistaExtInput);
            this.groupBox1.Controls.Add(this.pisoInput);
            this.groupBox1.Controls.Add(this.tipoHabInput);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 104);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // habilitadoInput
            // 
            this.habilitadoInput.Location = new System.Drawing.Point(457, 78);
            this.habilitadoInput.Name = "habilitadoInput";
            this.habilitadoInput.Size = new System.Drawing.Size(100, 20);
            this.habilitadoInput.TabIndex = 10;
            // 
            // hotelInput
            // 
            this.hotelInput.Location = new System.Drawing.Point(457, 53);
            this.hotelInput.Name = "hotelInput";
            this.hotelInput.Size = new System.Drawing.Size(100, 20);
            this.hotelInput.TabIndex = 9;
            // 
            // numHabInput
            // 
            this.numHabInput.Location = new System.Drawing.Point(457, 25);
            this.numHabInput.Name = "numHabInput";
            this.numHabInput.Size = new System.Drawing.Size(100, 20);
            this.numHabInput.TabIndex = 8;
            // 
            // vistaExtInput
            // 
            this.vistaExtInput.Location = new System.Drawing.Point(109, 76);
            this.vistaExtInput.Name = "vistaExtInput";
            this.vistaExtInput.Size = new System.Drawing.Size(100, 20);
            this.vistaExtInput.TabIndex = 8;
            // 
            // pisoInput
            // 
            this.pisoInput.Location = new System.Drawing.Point(109, 50);
            this.pisoInput.Name = "pisoInput";
            this.pisoInput.Size = new System.Drawing.Size(100, 20);
            this.pisoInput.TabIndex = 7;
            // 
            // tipoHabInput
            // 
            this.tipoHabInput.Location = new System.Drawing.Point(109, 19);
            this.tipoHabInput.Name = "tipoHabInput";
            this.tipoHabInput.Size = new System.Drawing.Size(100, 20);
            this.tipoHabInput.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Habilitado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Hotel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Numero de habitacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Vista al Exterior";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Piso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo de Habitacion";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(587, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Alta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroHabitacion,
            this.piso,
            this.idHotel,
            this.vistaAlExterior,
            this.tipoHabitacion,
            this.descripcion,
            this.habilitado});
            this.dataGridView1.Location = new System.Drawing.Point(15, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(748, 279);
            this.dataGridView1.TabIndex = 4;
            // 
            // numeroHabitacion
            // 
            this.numeroHabitacion.HeaderText = "Numero Habitacion";
            this.numeroHabitacion.Name = "numeroHabitacion";
            // 
            // piso
            // 
            this.piso.HeaderText = "Piso";
            this.piso.Name = "piso";
            // 
            // idHotel
            // 
            this.idHotel.HeaderText = "Hotel";
            this.idHotel.Name = "idHotel";
            // 
            // vistaAlExterior
            // 
            this.vistaAlExterior.HeaderText = "Vista al Exterior";
            this.vistaAlExterior.Name = "vistaAlExterior";
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.HeaderText = "Tipo de Habitacion";
            this.tipoHabitacion.Name = "tipoHabitacion";
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            // 
            // habilitado
            // 
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            // 
            // InicioHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "InicioHabitacion";
            this.Text = "AltaHabitacion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox habilitadoInput;
        private System.Windows.Forms.TextBox hotelInput;
        private System.Windows.Forms.TextBox numHabInput;
        private System.Windows.Forms.TextBox vistaExtInput;
        private System.Windows.Forms.TextBox pisoInput;
        private System.Windows.Forms.TextBox tipoHabInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn vistaAlExterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
    }
}