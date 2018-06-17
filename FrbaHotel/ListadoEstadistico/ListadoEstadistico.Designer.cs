namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.añoInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.top5Input = new System.Windows.Forms.ComboBox();
            this.filtrarBtn = new System.Windows.Forms.Button();
            this.trimestreInput = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año";
            // 
            // añoInput
            // 
            this.añoInput.Location = new System.Drawing.Point(77, 20);
            this.añoInput.Name = "añoInput";
            this.añoInput.Size = new System.Drawing.Size(350, 20);
            this.añoInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TOP 5 de:";
            // 
            // top5Input
            // 
            this.top5Input.FormattingEnabled = true;
            this.top5Input.Location = new System.Drawing.Point(78, 115);
            this.top5Input.Name = "top5Input";
            this.top5Input.Size = new System.Drawing.Size(349, 21);
            this.top5Input.TabIndex = 5;
            // 
            // filtrarBtn
            // 
            this.filtrarBtn.Location = new System.Drawing.Point(330, 166);
            this.filtrarBtn.Name = "filtrarBtn";
            this.filtrarBtn.Size = new System.Drawing.Size(97, 32);
            this.filtrarBtn.TabIndex = 6;
            this.filtrarBtn.Text = "Filtrar";
            this.filtrarBtn.UseVisualStyleBackColor = true;
            this.filtrarBtn.Click += new System.EventHandler(this.filtrarBtn_Click);
            // 
            // trimestreInput
            // 
            this.trimestreInput.FormattingEnabled = true;
            this.trimestreInput.Location = new System.Drawing.Point(78, 68);
            this.trimestreInput.Name = "trimestreInput";
            this.trimestreInput.Size = new System.Drawing.Size(349, 21);
            this.trimestreInput.TabIndex = 7;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 209);
            this.Controls.Add(this.trimestreInput);
            this.Controls.Add(this.filtrarBtn);
            this.Controls.Add(this.top5Input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.añoInput);
            this.Controls.Add(this.label1);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox añoInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox top5Input;
        private System.Windows.Forms.Button filtrarBtn;
        private System.Windows.Forms.ComboBox trimestreInput;
    }
}