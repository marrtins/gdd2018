namespace FrbaHotel.Facturar
{
    partial class FacturaExistente
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupFactAnt = new System.Windows.Forms.GroupBox();
            this.cboFDPAnt = new System.Windows.Forms.ComboBox();
            this.lblNroAnt = new System.Windows.Forms.Label();
            this.lblFechaAnt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConsumibles = new System.Windows.Forms.Label();
            this.lblValorBase = new System.Windows.Forms.Label();
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
            this.lblFCHIN = new System.Windows.Forms.Label();
            this.lblFCHOUT = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupFactAnt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "La reserva seleccionada, ya se ha facturado con anterioridad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puede decidir mantener el precio o modificar la misma.";
            // 
            // groupFactAnt
            // 
            this.groupFactAnt.Controls.Add(this.cboFDPAnt);
            this.groupFactAnt.Controls.Add(this.lblNroAnt);
            this.groupFactAnt.Controls.Add(this.lblFechaAnt);
            this.groupFactAnt.Controls.Add(this.lblTotal);
            this.groupFactAnt.Controls.Add(this.label3);
            this.groupFactAnt.Controls.Add(this.lblConsumibles);
            this.groupFactAnt.Controls.Add(this.lblValorBase);
            this.groupFactAnt.Location = new System.Drawing.Point(75, 121);
            this.groupFactAnt.Name = "groupFactAnt";
            this.groupFactAnt.Size = new System.Drawing.Size(290, 336);
            this.groupFactAnt.TabIndex = 2;
            this.groupFactAnt.TabStop = false;
            this.groupFactAnt.Text = "Factura Anterior";
            // 
            // cboFDPAnt
            // 
            this.cboFDPAnt.FormattingEnabled = true;
            this.cboFDPAnt.Location = new System.Drawing.Point(101, 104);
            this.cboFDPAnt.Name = "cboFDPAnt";
            this.cboFDPAnt.Size = new System.Drawing.Size(158, 21);
            this.cboFDPAnt.TabIndex = 7;
            // 
            // lblNroAnt
            // 
            this.lblNroAnt.AutoSize = true;
            this.lblNroAnt.Location = new System.Drawing.Point(15, 173);
            this.lblNroAnt.Name = "lblNroAnt";
            this.lblNroAnt.Size = new System.Drawing.Size(86, 13);
            this.lblNroAnt.TabIndex = 5;
            this.lblNroAnt.Text = "Numero Factura:";
            // 
            // lblFechaAnt
            // 
            this.lblFechaAnt.AutoSize = true;
            this.lblFechaAnt.Location = new System.Drawing.Point(15, 149);
            this.lblFechaAnt.Name = "lblFechaAnt";
            this.lblFechaAnt.Size = new System.Drawing.Size(99, 13);
            this.lblFechaAnt.TabIndex = 4;
            this.lblFechaAnt.Text = "Fecha Facturacion:";
            this.lblFechaAnt.Click += new System.EventHandler(this.lblFechaAnt_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(11, 311);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "TOTAL: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forma de pago: ";
            // 
            // lblConsumibles
            // 
            this.lblConsumibles.AutoSize = true;
            this.lblConsumibles.Location = new System.Drawing.Point(11, 78);
            this.lblConsumibles.Name = "lblConsumibles";
            this.lblConsumibles.Size = new System.Drawing.Size(129, 13);
            this.lblConsumibles.TabIndex = 1;
            this.lblConsumibles.Text = "VALOR CONSUMIBLES: ";
            // 
            // lblValorBase
            // 
            this.lblValorBase.AutoSize = true;
            this.lblValorBase.Location = new System.Drawing.Point(11, 50);
            this.lblValorBase.Name = "lblValorBase";
            this.lblValorBase.Size = new System.Drawing.Size(148, 13);
            this.lblValorBase.TabIndex = 0;
            this.lblValorBase.Text = "VALOR BASE HABITACION: ";
            this.lblValorBase.Click += new System.EventHandler(this.label3_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(417, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 332);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Factura Actual";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Forma de Pago";
            // 
            // cboFormaDePago
            // 
            this.cboFormaDePago.FormattingEnabled = true;
            this.cboFormaDePago.Location = new System.Drawing.Point(106, 255);
            this.cboFormaDePago.Name = "cboFormaDePago";
            this.cboFormaDePago.Size = new System.Drawing.Size(157, 21);
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
            this.lblDtoACt.Location = new System.Drawing.Point(6, 224);
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
            this.lstConsAct.Size = new System.Drawing.Size(212, 69);
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
            // lblFCHIN
            // 
            this.lblFCHIN.AutoSize = true;
            this.lblFCHIN.Location = new System.Drawing.Point(402, 55);
            this.lblFCHIN.Name = "lblFCHIN";
            this.lblFCHIN.Size = new System.Drawing.Size(88, 13);
            this.lblFCHIN.TabIndex = 0;
            this.lblFCHIN.Text = "Fecha Check IN:";
            // 
            // lblFCHOUT
            // 
            this.lblFCHOUT.AutoSize = true;
            this.lblFCHOUT.Location = new System.Drawing.Point(402, 82);
            this.lblFCHOUT.Name = "lblFCHOUT";
            this.lblFCHOUT.Size = new System.Drawing.Size(100, 13);
            this.lblFCHOUT.TabIndex = 4;
            this.lblFCHOUT.Text = "Fecha Check OUT:";
            this.lblFCHOUT.Click += new System.EventHandler(this.lblFCHOUT_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Utilizar F. Anterior";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(527, 478);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Utilizar F. Actual";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FacturaExistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 538);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFCHOUT);
            this.Controls.Add(this.lblFCHIN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupFactAnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FacturaExistente";
            this.Text = "FacturaExistente";
            this.Load += new System.EventHandler(this.FacturaExistente_Load);
            this.groupFactAnt.ResumeLayout(false);
            this.groupFactAnt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupFactAnt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblValorBase;
        private System.Windows.Forms.Label lblFCHIN;
        private System.Windows.Forms.Label lblFCHOUT;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConsumibles;
        private System.Windows.Forms.Label lblTotalAct;
        private System.Windows.Forms.Label lbldnu;
        private System.Windows.Forms.Label lbldaloj;
        private System.Windows.Forms.Label lblDtoACt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstConsAct;
        private System.Windows.Forms.Label lblVCAct;
        private System.Windows.Forms.Label lblVBActual;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblFechaAnt;
        private System.Windows.Forms.Label lblNroAnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFormaDePago;
        private System.Windows.Forms.ComboBox cboFDPAnt;
    }
}