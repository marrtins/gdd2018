using FrbaHotel.Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Utilities
{
    public static class LoginData
    {
        public static int IdUsuario { get; set; }

        public static Rol Rol { get; set; }

        public static HotelLogin Hotel { get; set; }

        public static bool EsAdmin
        {
            get
            {
                return Rol.Nombre == "administrador";
            }
        }
    }
}
