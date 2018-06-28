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

            contraseniaInput.DataBindings.Add(new TextBinding(this.Model, "Password"));
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
                var hoteles = HotelesLogin.GetAllFor(LoginData.IdUsuario);
               
                bool debeAbrirSeleccionar = roles.Count > 1 || hoteles.Count > 1;

                if (debeAbrirSeleccionar)
             
                        Seleccionar();
                else
                    LoginData.Rol = roles.First();

                this.Hide();
              
                Form1 form = new Form1();

                form.Show();
            }
        }

        private void Seleccionar()
        {
            var rolSelec = new Seleccion();

            rolSelec.ShowDialog();
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
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = usuarioLogin.Password;

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

        private void Login_Shown(object sender, EventArgs e)
        {
            var usLog = (UsuarioLogin)this.Model;

            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);


            usLog.Nombre = ConfigurationManager.AppSettings["defaultUserName"];
            usLog.Password = ConfigurationManager.AppSettings["defaultPassword"];

            var autoLogin = ConfigurationManager.AppSettings["autoLogin"] != null ? Boolean.Parse(ConfigurationManager.AppSettings["autoLogin"]) : false;

            if (autoLogin)
                button1_Click(null, null);
        }

        private void guestBtn_Click(object sender, EventArgs e)
        {
            LoginData.IdUsuario = 0; //Limpio toda la info del usuario anterior y cargo el usuario guest
            LoginData.Rol = new Rol(0, "Guest", "Y");

            this.Hide();

            Form1 form = new Form1();

            form.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
