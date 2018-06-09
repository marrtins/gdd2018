using FrbaHotel.Login.Model;
using Rubberduck.Winforms;
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
    public partial class Login : ModelBoundForm
    {
        public Login()
            :base(new UsuarioLogin())
        {
            InitializeComponent();

            RegistrarInputs();
        }

        private void RegistrarInputs()
        {
            usuarioInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));
            Register(ErrorLabel.For(usuarioInput, Alignment.Bottom, 2));

            contraseniaInput.DataBindings.Add(new TextBinding(this.Model, "Contrasenia"));
            Register(ErrorLabel.For(contraseniaInput, Alignment.Bottom, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;
        }
    }
}
