using FrbaHotel.Login.Model;
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
    public partial class Seleccion : Form
    {
        List<Rol> roles;
        List<HotelLogin> hoteles;

        public Seleccion()
        {
            InitializeComponent();

            roles = Roles.GetAllFor(LoginData.IdUsuario);
            this.rolesCombo.DataSource = roles;

            hoteles = HotelesLogin.GetAllFor(LoginData.IdUsuario);
            this.hotelesCombo.DataSource = hoteles;

            this.rolesCombo.SelectedIndex = 0;
            this.hotelesCombo.SelectedIndex = 0;

            this.rolesCombo.Enabled = roles.Count > 1;
            this.hotelesCombo.Enabled = hoteles.Count > 1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LoginData.Rol = roles.First(r => r.Id == (int)this.rolesCombo.SelectedValue);
            LoginData.Hotel = hoteles.First(r => r.IdHotel == (int)this.hotelesCombo.SelectedValue);

            this.Close();
        }
    }
}
