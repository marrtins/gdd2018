namespace FrbaHotel.Login
{
    partial class Seleccion
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.rolesCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hotelesCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 85);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cancelar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(209, 85);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // rolesCombo
            // 
            this.rolesCombo.DisplayMember = "Nombre";
            this.rolesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rolesCombo.FormattingEnabled = true;
            this.rolesCombo.Location = new System.Drawing.Point(115, 21);
            this.rolesCombo.Name = "rolesCombo";
            this.rolesCombo.Size = new System.Drawing.Size(169, 21);
            this.rolesCombo.TabIndex = 4;
            this.rolesCombo.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rol seleccionado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hotel Seleccionado";
            // 
            // hotelesCombo
            // 
            this.hotelesCombo.DisplayMember = "Nombre";
            this.hotelesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hotelesCombo.FormattingEnabled = true;
            this.hotelesCombo.Location = new System.Drawing.Point(115, 49);
            this.hotelesCombo.Name = "hotelesCombo";
            this.hotelesCombo.Size = new System.Drawing.Size(169, 21);
            this.hotelesCombo.TabIndex = 7;
            this.hotelesCombo.ValueMember = "IdHotel";
            // 
            // Seleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 120);
            this.Controls.Add(this.hotelesCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rolesCombo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "Seleccion";
            this.Text = "Seleccione";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox rolesCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hotelesCombo;
    }
}