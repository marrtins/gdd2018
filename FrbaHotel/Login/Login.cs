using FrbaHotel.Login.Model;
using FrbaHotel.Utilities;
using Rubberduck.Winforms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

            Log();
        }

        private void Log()
        {
            var usuarioLogin = (UsuarioLogin)this.Model;
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.Logear", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = usuarioLogin.Nombre;
                    cmd.Parameters.AddWithValue("@Contrasenia", SqlDbType.NVarChar).Value = usuarioLogin.Contrasenia;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                        dr.Read();

                    var id = (int)dr["id"]; //si id = -1 es login fallido

                    var txtError = id == -1 ? "Contraseña incorrecta" :
                                   id == -2 ? "El usuario ha sido bloqueado" :
                                   id == -3 ? "Usuario Inhabilitado" : "";

                    this.loginErrorLbl.Text = txtError;

                    if (id < 0)
                        this.loginErrorLbl.Show();
                    else
                    {
                        this.loginErrorLbl.Hide();
                        LoginData.IdUsuario = id;
                    }
                }
            }
        }
    }
}
