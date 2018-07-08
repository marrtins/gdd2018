namespace FrbaHotel.Login
{
    partial class Login
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
            this.usuarioInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginErrorLbl = new System.Windows.Forms.Label();
            this.guestBtn = new System.Windows.Forms.Button();
            this.contraseniaInput = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // usuarioInput
            // 
            this.usuarioInput.Location = new System.Drawing.Point(98, 10);
            this.usuarioInput.Name = "usuarioInput";
            this.usuarioInput.Size = new System.Drawing.Size(223, 20);
            this.usuarioInput.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // loginErrorLbl
            // 
            this.loginErrorLbl.AutoSize = true;
            this.loginErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.loginErrorLbl.Location = new System.Drawing.Point(95, 82);
            this.loginErrorLbl.Name = "loginErrorLbl";
            this.loginErrorLbl.Size = new System.Drawing.Size(63, 13);
            this.loginErrorLbl.TabIndex = 3;
            this.loginErrorLbl.Text = "Login fallido";
            this.loginErrorLbl.Visible = false;
            // 
            // guestBtn
            // 
            this.guestBtn.Location = new System.Drawing.Point(165, 105);
            this.guestBtn.Name = "guestBtn";
            this.guestBtn.Size = new System.Drawing.Size(75, 23);
            this.guestBtn.TabIndex = 3;
            this.guestBtn.Text = "Guest";
            this.guestBtn.UseVisualStyleBackColor = true;
            this.guestBtn.Click += new System.EventHandler(this.guestBtn_Click);
            // 
            // contraseniaInput
            // 
            this.contraseniaInput.Location = new System.Drawing.Point(98, 49);
            this.contraseniaInput.Name = "contraseniaInput";
            this.contraseniaInput.PasswordChar = '*';
            this.contraseniaInput.Size = new System.Drawing.Size(223, 20);
            this.contraseniaInput.TabIndex = 1;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 140);
            this.Controls.Add(this.contraseniaInput);
            this.Controls.Add(this.loginErrorLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.guestBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usuarioInput);
            this.Name = "Login";
            this.Text = "Login";
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usuarioInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label loginErrorLbl;
        private System.Windows.Forms.Button guestBtn;
        private System.Windows.Forms.MaskedTextBox contraseniaInput;
    }
}