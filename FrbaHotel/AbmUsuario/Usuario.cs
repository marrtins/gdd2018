using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class Usuario : Form
    {
        private Button btnCrearUsuario;
        private Button btnModificarUsuario;
        private Button btnBorrarUsuario;
    
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
                    
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            SeleccionUsuario su = new SeleccionUsuario();
            su.ShowDialog();
            ModificarUsuario mu = new ModificarUsuario();
            mu.ShowDialog();
            
        }

        private void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            BorrarUsuario bu = new BorrarUsuario();
            bu.ShowDialog();
        
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            AltaUsuario au = new AltaUsuario();
            au.ShowDialog();
        
        }

        private void InitializeComponent()
        {
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnBorrarUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Location = new System.Drawing.Point(35, 35);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(150, 50);
            this.btnCrearUsuario.TabIndex = 0;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Location = new System.Drawing.Point(35, 95);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(150, 50);
            this.btnModificarUsuario.TabIndex = 1;
            this.btnModificarUsuario.Text = "Modificar Usuario";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnBorrarUsuario
            // 
            this.btnBorrarUsuario.Location = new System.Drawing.Point(35, 155);
            this.btnBorrarUsuario.Name = "btnBorrarUsuario";
            this.btnBorrarUsuario.Size = new System.Drawing.Size(150, 50);
            this.btnBorrarUsuario.TabIndex = 2;
            this.btnBorrarUsuario.Text = "Borrar Usuario";
            this.btnBorrarUsuario.UseVisualStyleBackColor = true;
            // 
            // Usuario
            // 
            this.ClientSize = new System.Drawing.Size(219, 236);
            this.Controls.Add(this.btnBorrarUsuario);
            this.Controls.Add(this.btnModificarUsuario);
            this.Controls.Add(this.btnCrearUsuario);
            this.Name = "Usuario";
            this.Text = "Usuario";
            this.ResumeLayout(false);

        }
    }
}
