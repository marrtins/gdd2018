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

            var usLog = (UsuarioLogin)this.Model;

            usLog.Nombre = ConfigurationManager.AppSettings["defaultUserName"];
            usLog.Contrasenia = ConfigurationManager.AppSettings["defaultPassword"];
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

            bool success = Log();         

            if (success)
            {
                var roles = Roles.GetAllFor(LoginData.IdUsuario);
                bool masDeUnRol = roles.Count > 1;

                if (masDeUnRol)
                    SeleccionarRol();
                else
                    LoginData.Rol = roles.First();

                this.Hide();

                Form1 form = new Form1();

                form.Show();
            }
        }

        private void SeleccionarRol()
        {
            var rolSelec = new SeleccionRol();

            rolSelec.ShowDialog();

            this.Close();
        }

        private bool Log()
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

                    var txtError = "";
                    var id = 0;

                    if (dr.HasRows)
                    {
                        dr.Read();

                        id = (int)dr["id"]; //si id = -1 es login fallido

                        txtError = id == -1 ? "Contraseña incorrecta" :
                                    id == -2 ? "El usuario ha sido bloqueado" :
                                    id == -3 ? "Usuario Inhabilitado" : "";

                    }
                    else //El reader no retorno nada, no hay datos
                        txtError = "Usuario inexistente";

                    this.loginErrorLbl.Text = txtError;

                    if (id <= 0)
                    {
                        this.loginErrorLbl.Show();
                        return false;
                    }

                    this.loginErrorLbl.Hide();
                    LoginData.IdUsuario = id;
                    return true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
