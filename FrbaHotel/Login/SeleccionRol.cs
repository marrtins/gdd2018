using FrbaHotel.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class SeleccionRol : Form
    {
        List<Rol> roles;

        public SeleccionRol()
        {
            InitializeComponent();

            roles = Roles.GetAllFor(LoginData.IdUsuario);
            this.rolesCombo.DataSource = roles;

            this.rolesCombo.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LoginData.Rol = roles.First(r => r.Id == (int)this.rolesCombo.SelectedValue);

            this.Close();
        }
    }
}
