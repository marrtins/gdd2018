﻿namespace FrbaHotel.AbmHabitacion
{
    partial class AltaHabitacion
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
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descripcionInput = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pisoInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btnSi = new System.Windows.Forms.RadioButton();
            this.btnNo = new System.Windows.Forms.RadioButton();
            this.hotelInput = new System.Windows.Forms.TextBox();
            this.seleccionarHotelBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(20, 325);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(75, 23);
            this.limpiarBtn.TabIndex = 47;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.limpiarBtn_Click);
            // 
            // modificarBtn
            // 
            this.modificarBtn.Location = new System.Drawing.Point(328, 325);
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.Size = new System.Drawing.Size(75, 23);
            this.modificarBtn.TabIndex = 46;
            this.modificarBtn.Text = "Guardar";
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // numHabInput
            // 
            this.numHabInput.Location = new System.Drawing.Point(127, 10);
            this.numHabInput.Name = "numHabInput";
            this.numHabInput.Size = new System.Drawing.Size(181, 20);
            this.numHabInput.TabIndex = 45;
            // 
            // habilitadoInput
            // 
            this.habilitadoInput.AutoSize = true;
            this.habilitadoInput.Location = new System.Drawing.Point(127, 169);
            this.habilitadoInput.Name = "habilitadoInput";
            this.habilitadoInput.Size = new System.Drawing.Size(15, 14);
            this.habilitadoInput.TabIndex = 44;
            this.habilitadoInput.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Habilitado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descripcionInput);
            this.groupBox1.Location = new System.Drawing.Point(14, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 113);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descripcion";
            // 
            // descripcionInput
            // 
            this.descripcionInput.Location = new System.Drawing.Point(6, 19);
            this.descripcionInput.Name = "descripcionInput";
            this.descripcionInput.Size = new System.Drawing.Size(377, 90);
            this.descripcionInput.TabIndex = 0;
            this.descripcionInput.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Vista al Exterior";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Piso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tipo Habitacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Numero Habitacion";
            // 
            // pisoInput
            // 
            this.pisoInput.Location = new System.Drawing.Point(126, 100);
            this.pisoInput.Name = "pisoInput";
            this.pisoInput.Size = new System.Drawing.Size(182, 20);
            this.pisoInput.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 54;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(126, 36);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(182, 21);
            this.cboTipo.TabIndex = 55;
            // 
            // btnSi
            // 
            this.btnSi.AutoSize = true;
            this.btnSi.Location = new System.Drawing.Point(126, 134);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(34, 17);
            this.btnSi.TabIndex = 56;
            this.btnSi.TabStop = true;
            this.btnSi.Text = "Si";
            this.btnSi.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.AutoSize = true;
            this.btnNo.Location = new System.Drawing.Point(166, 134);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(39, 17);
            this.btnNo.TabIndex = 57;
            this.btnNo.TabStop = true;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // hotelInput
            // 
            this.hotelInput.Location = new System.Drawing.Point(127, 70);
            this.hotelInput.Name = "hotelInput";
            this.hotelInput.ReadOnly = true;
            this.hotelInput.Size = new System.Drawing.Size(181, 20);
            this.hotelInput.TabIndex = 58;
            this.hotelInput.TextChanged += new System.EventHandler(this.hotelInput_TextChanged);
            // 
            // seleccionarHotelBtn
            // 
            this.seleccionarHotelBtn.Location = new System.Drawing.Point(314, 68);
            this.seleccionarHotelBtn.Name = "seleccionarHotelBtn";
            this.seleccionarHotelBtn.Size = new System.Drawing.Size(89, 23);
            this.seleccionarHotelBtn.TabIndex = 59;
            this.seleccionarHotelBtn.Text = "Seleccionar";
            this.seleccionarHotelBtn.UseVisualStyleBackColor = true;
            this.seleccionarHotelBtn.Click += new System.EventHandler(this.seleccionarHotelBtn_Click);
            // 
            // AltaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 387);
            this.Controls.Add(this.seleccionarHotelBtn);
            this.Controls.Add(this.hotelInput);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pisoInput);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.modificarBtn);
            this.Controls.Add(this.numHabInput);
            this.Controls.Add(this.habilitadoInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaHabitacion";
            this.Text = "Alta Habitacion";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button modificarBtn;
        private System.Windows.Forms.TextBox numHabInput;
        private System.Windows.Forms.CheckBox habilitadoInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox descripcionInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pisoInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.RadioButton btnSi;
        private System.Windows.Forms.RadioButton btnNo;
        private System.Windows.Forms.TextBox hotelInput;
        private System.Windows.Forms.Button seleccionarHotelBtn;
    }
}