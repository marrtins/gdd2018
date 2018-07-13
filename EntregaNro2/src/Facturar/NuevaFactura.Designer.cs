namespace FrbaHotel.Facturar
{
    partial class NuevaFactura
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
            this.button2 = new System.Windows.Forms.Button();
            this.lblFCHOUT = new System.Windows.Forms.Label();
            this.lblFCHIN = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFormaDePago = new System.Windows.Forms.ComboBox();
            this.lblTotalAct = new System.Windows.Forms.Label();
            this.lbldnu = new System.Windows.Forms.Label();
            this.lbldaloj = new System.Windows.Forms.Label();
            this.lblDtoACt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstConsAct = new System.Windows.Forms.ListBox();
            this.lblVCAct = new System.Windows.Forms.Label();
            this.lblVBActual = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(365, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Facturar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblFCHOUT
            // 
            this.lblFCHOUT.AutoSize = true;
            this.lblFCHOUT.Location = new System.Drawing.Point(76, 39);
            this.lblFCHOUT.Name = "lblFCHOUT";
            this.lblFCHOUT.Size = new System.Drawing.Size(100, 13);
            this.lblFCHOUT.TabIndex = 9;
            this.lblFCHOUT.Text = "Fecha Check OUT:";
            // 
            // lblFCHIN
            // 
            this.lblFCHIN.AutoSize = true;
            this.lblFCHIN.Location = new System.Drawing.Point(76, 9);
            this.lblFCHIN.Name = "lblFCHIN";
            this.lblFCHIN.Size = new System.Drawing.Size(88, 13);
            this.lblFCHIN.TabIndex = 7;
            this.lblFCHIN.Text = "Fecha Check IN:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboFormaDePago);
            this.groupBox1.Controls.Add(this.lblTotalAct);
            this.groupBox1.Controls.Add(this.lbldnu);
            this.groupBox1.Controls.Add(this.lbldaloj);
            this.groupBox1.Controls.Add(this.lblDtoACt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lstConsAct);
            this.groupBox1.Controls.Add(this.lblVCAct);
            this.groupBox1.Controls.Add(this.lblVBActual);
            this.groupBox1.Location = new System.Drawing.Point(79, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 332);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Factura Actual";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Forma de Pago";
            // 
            // cboFormaDePago
            // 
            this.cboFormaDePago.FormattingEnabled = true;
            this.cboFormaDePago.Location = new System.Drawing.Point(263, 43);
            this.cboFormaDePago.Name = "cboFormaDePago";
            this.cboFormaDePago.Size = new System.Drawing.Size(185, 21);
            this.cboFormaDePago.TabIndex = 7;
            // 
            // lblTotalAct
            // 
            this.lblTotalAct.AutoSize = true;
            this.lblTotalAct.Location = new System.Drawing.Point(16, 307);
            this.lblTotalAct.Name = "lblTotalAct";
            this.lblTotalAct.Size = new System.Drawing.Size(45, 13);
            this.lblTotalAct.TabIndex = 6;
            this.lblTotalAct.Text = "TOTAL:";
            // 
            // lbldnu
            // 
            this.lbldnu.AutoSize = true;
            this.lbldnu.Location = new System.Drawing.Point(137, 74);
            this.lbldnu.Name = "lbldnu";
            this.lbldnu.Size = new System.Drawing.Size(92, 13);
            this.lbldnu.TabIndex = 5;
            this.lbldnu.Text = "Dias no utilizados:";
            // 
            // lbldaloj
            // 
            this.lbldaloj.AutoSize = true;
            this.lbldaloj.Location = new System.Drawing.Point(14, 74);
            this.lbldaloj.Name = "lbldaloj";
            this.lbldaloj.Size = new System.Drawing.Size(69, 13);
            this.lbldaloj.TabIndex = 4;
            this.lbldaloj.Text = "Dias Alojado:";
            // 
            // lblDtoACt
            // 
            this.lblDtoACt.AutoSize = true;
            this.lblDtoACt.Location = new System.Drawing.Point(16, 274);
            this.lblDtoACt.Name = "lblDtoACt";
            this.lblDtoACt.Size = new System.Drawing.Size(226, 13);
            this.lblDtoACt.TabIndex = 4;
            this.lblDtoACt.Text = "DESCUENTO POR REGIMEN DE ESTADIA: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Detalle de Consumibles:";
            // 
            // lstConsAct
            // 
            this.lstConsAct.FormattingEnabled = true;
            this.lstConsAct.HorizontalScrollbar = true;
            this.lstConsAct.Location = new System.Drawing.Point(51, 136);
            this.lstConsAct.Name = "lstConsAct";
            this.lstConsAct.ScrollAlwaysVisible = true;
            this.lstConsAct.Size = new System.Drawing.Size(212, 134);
            this.lstConsAct.TabIndex = 2;
            // 
            // lblVCAct
            // 
            this.lblVCAct.AutoSize = true;
            this.lblVCAct.Location = new System.Drawing.Point(21, 100);
            this.lblVCAct.Name = "lblVCAct";
            this.lblVCAct.Size = new System.Drawing.Size(129, 13);
            this.lblVCAct.TabIndex = 1;
            this.lblVCAct.Text = "VALOR CONSUMIBLES: ";
            // 
            // lblVBActual
            // 
            this.lblVBActual.AutoSize = true;
            this.lblVBActual.Location = new System.Drawing.Point(16, 43);
            this.lblVBActual.Name = "lblVBActual";
            this.lblVBActual.Size = new System.Drawing.Size(148, 13);
            this.lblVBActual.TabIndex = 0;
            this.lblVBActual.Text = "VALOR BASE HABITACION: ";
            // 
            // NuevaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblFCHOUT);
            this.Controls.Add(this.lblFCHIN);
            this.Controls.Add(this.groupBox1);
            this.Name = "NuevaFactura";
            this.Text = "NuevaFactura";
            this.Load += new System.EventHandler(this.NuevaFactura_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblFCHOUT;
        private System.Windows.Forms.Label lblFCHIN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFormaDePago;
        private System.Windows.Forms.Label lblTotalAct;
        private System.Windows.Forms.Label lbldnu;
        private System.Windows.Forms.Label lbldaloj;
        private System.Windows.Forms.Label lblDtoACt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstConsAct;
        private System.Windows.Forms.Label lblVCAct;
        private System.Windows.Forms.Label lblVBActual;
    }
}