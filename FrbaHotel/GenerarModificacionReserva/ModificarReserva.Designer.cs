namespace FrbaHotel.GenerarModificacionReserva
{
    partial class ModificarReserva
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgPrecios = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRegimen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHotel = new System.Windows.Forms.Label();
            this.txtC4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtC3 = new System.Windows.Forms.TextBox();
            this.txtC2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtC1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkModificar = new System.Windows.Forms.CheckBox();
            this.lblBs = new System.Windows.Forms.Label();
            this.lblBd = new System.Windows.Forms.Label();
            this.lblBt = new System.Windows.Forms.Label();
            this.lblBc = new System.Windows.Forms.Label();
            this.lblBk = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtC5 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblc1 = new System.Windows.Forms.Label();
            this.lblc2 = new System.Windows.Forms.Label();
            this.lblc3 = new System.Windows.Forms.Label();
            this.lblc4 = new System.Windows.Forms.Label();
            this.lblc5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrecios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(464, 310);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(133, 40);
            this.btnModificar.TabIndex = 25;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgPrecios
            // 
            this.dgPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrecios.Location = new System.Drawing.Point(340, 29);
            this.dgPrecios.Name = "dgPrecios";
            this.dgPrecios.Size = new System.Drawing.Size(287, 181);
            this.dgPrecios.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 39);
            this.button1.TabIndex = 23;
            this.button1.Text = "Chequear Disponibilidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Hotel";
            // 
            // cboRegimen
            // 
            this.cboRegimen.FormattingEnabled = true;
            this.cboRegimen.Location = new System.Drawing.Point(188, 126);
            this.cboRegimen.Name = "cboRegimen";
            this.cboRegimen.Size = new System.Drawing.Size(137, 21);
            this.cboRegimen.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Regimen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Desde";
            // 
            // dtHasta
            // 
            this.dtHasta.Location = new System.Drawing.Point(125, 100);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(200, 20);
            this.dtHasta.TabIndex = 14;
            // 
            // dtDesde
            // 
            this.dtDesde.Location = new System.Drawing.Point(125, 62);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(200, 20);
            this.dtDesde.TabIndex = 13;
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(122, 32);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(35, 13);
            this.lblHotel.TabIndex = 26;
            this.lblHotel.Text = "label6";
            // 
            // txtC4
            // 
            this.txtC4.Location = new System.Drawing.Point(139, 139);
            this.txtC4.Name = "txtC4";
            this.txtC4.Size = new System.Drawing.Size(48, 20);
            this.txtC4.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(101, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Cant:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(101, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Cant:";
            // 
            // txtC3
            // 
            this.txtC3.Location = new System.Drawing.Point(139, 101);
            this.txtC3.Name = "txtC3";
            this.txtC3.Size = new System.Drawing.Size(48, 20);
            this.txtC3.TabIndex = 38;
            // 
            // txtC2
            // 
            this.txtC2.Location = new System.Drawing.Point(139, 61);
            this.txtC2.Name = "txtC2";
            this.txtC2.Size = new System.Drawing.Size(48, 20);
            this.txtC2.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Cant:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Cant:";
            // 
            // txtC1
            // 
            this.txtC1.Location = new System.Drawing.Point(139, 23);
            this.txtC1.Name = "txtC1";
            this.txtC1.Size = new System.Drawing.Size(48, 20);
            this.txtC1.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Habitaciones Reservadas:";
            // 
            // chkModificar
            // 
            this.chkModificar.AutoSize = true;
            this.chkModificar.Location = new System.Drawing.Point(35, 310);
            this.chkModificar.Name = "chkModificar";
            this.chkModificar.Size = new System.Drawing.Size(134, 17);
            this.chkModificar.TabIndex = 46;
            this.chkModificar.Text = "Modificar Habitaciones";
            this.chkModificar.UseVisualStyleBackColor = true;
            this.chkModificar.CheckedChanged += new System.EventHandler(this.chkModificar_CheckedChanged);
            // 
            // lblBs
            // 
            this.lblBs.AutoSize = true;
            this.lblBs.Location = new System.Drawing.Point(45, 192);
            this.lblBs.Name = "lblBs";
            this.lblBs.Size = new System.Drawing.Size(68, 13);
            this.lblBs.TabIndex = 47;
            this.lblBs.Text = "Base Simple:";
            // 
            // lblBd
            // 
            this.lblBd.AutoSize = true;
            this.lblBd.Location = new System.Drawing.Point(45, 217);
            this.lblBd.Name = "lblBd";
            this.lblBd.Size = new System.Drawing.Size(65, 13);
            this.lblBd.TabIndex = 48;
            this.lblBd.Text = "Base Doble:";
            // 
            // lblBt
            // 
            this.lblBt.AutoSize = true;
            this.lblBt.Location = new System.Drawing.Point(45, 236);
            this.lblBt.Name = "lblBt";
            this.lblBt.Size = new System.Drawing.Size(63, 13);
            this.lblBt.TabIndex = 49;
            this.lblBt.Text = "Base Triple:";
            // 
            // lblBc
            // 
            this.lblBc.AutoSize = true;
            this.lblBc.Location = new System.Drawing.Point(45, 262);
            this.lblBc.Name = "lblBc";
            this.lblBc.Size = new System.Drawing.Size(85, 13);
            this.lblBc.TabIndex = 50;
            this.lblBc.Text = "Base Cuadruple:";
            // 
            // lblBk
            // 
            this.lblBk.AutoSize = true;
            this.lblBk.Location = new System.Drawing.Point(46, 284);
            this.lblBk.Name = "lblBk";
            this.lblBk.Size = new System.Drawing.Size(31, 13);
            this.lblBk.TabIndex = 51;
            this.lblBk.Text = "King:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtC5);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtC1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtC2);
            this.groupBox1.Controls.Add(this.txtC4);
            this.groupBox1.Controls.Add(this.txtC3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(35, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 205);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // txtC5
            // 
            this.txtC5.Location = new System.Drawing.Point(139, 166);
            this.txtC5.Name = "txtC5";
            this.txtC5.Size = new System.Drawing.Size(48, 20);
            this.txtC5.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(101, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Cant:";
            // 
            // lblc1
            // 
            this.lblc1.AutoSize = true;
            this.lblc1.Location = new System.Drawing.Point(119, 192);
            this.lblc1.Name = "lblc1";
            this.lblc1.Size = new System.Drawing.Size(13, 13);
            this.lblc1.TabIndex = 53;
            this.lblc1.Text = "0";
            // 
            // lblc2
            // 
            this.lblc2.AutoSize = true;
            this.lblc2.Location = new System.Drawing.Point(119, 217);
            this.lblc2.Name = "lblc2";
            this.lblc2.Size = new System.Drawing.Size(13, 13);
            this.lblc2.TabIndex = 54;
            this.lblc2.Text = "0";
            // 
            // lblc3
            // 
            this.lblc3.AutoSize = true;
            this.lblc3.Location = new System.Drawing.Point(119, 236);
            this.lblc3.Name = "lblc3";
            this.lblc3.Size = new System.Drawing.Size(13, 13);
            this.lblc3.TabIndex = 55;
            this.lblc3.Text = "0";
            // 
            // lblc4
            // 
            this.lblc4.AutoSize = true;
            this.lblc4.Location = new System.Drawing.Point(136, 262);
            this.lblc4.Name = "lblc4";
            this.lblc4.Size = new System.Drawing.Size(13, 13);
            this.lblc4.TabIndex = 56;
            this.lblc4.Text = "0";
            // 
            // lblc5
            // 
            this.lblc5.AutoSize = true;
            this.lblc5.Location = new System.Drawing.Point(83, 284);
            this.lblc5.Name = "lblc5";
            this.lblc5.Size = new System.Drawing.Size(13, 13);
            this.lblc5.TabIndex = 57;
            this.lblc5.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "King";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Base Cuadruple";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Base Triple";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Base Doble";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Base Simple";
            // 
            // ModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 544);
            this.Controls.Add(this.lblc5);
            this.Controls.Add(this.lblc4);
            this.Controls.Add(this.lblc3);
            this.Controls.Add(this.lblc2);
            this.Controls.Add(this.lblc1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBk);
            this.Controls.Add(this.lblBc);
            this.Controls.Add(this.lblBt);
            this.Controls.Add(this.lblBd);
            this.Controls.Add(this.lblBs);
            this.Controls.Add(this.chkModificar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgPrecios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboRegimen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Name = "ModificarReserva";
            this.Text = "ModificarReserva";
            this.Load += new System.EventHandler(this.ModificarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrecios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgPrecios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRegimen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.TextBox txtC4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtC3;
        private System.Windows.Forms.TextBox txtC2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtC1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkModificar;
        private System.Windows.Forms.Label lblBs;
        private System.Windows.Forms.Label lblBd;
        private System.Windows.Forms.Label lblBt;
        private System.Windows.Forms.Label lblBc;
        private System.Windows.Forms.Label lblBk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblc1;
        private System.Windows.Forms.Label lblc2;
        private System.Windows.Forms.Label lblc3;
        private System.Windows.Forms.Label lblc4;
        private System.Windows.Forms.Label lblc5;
        private System.Windows.Forms.TextBox txtC5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}