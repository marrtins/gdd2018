using FrbaHotel.AbmHotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Login.Model
{
    public class UsuarioLogin 
    {
        private string nombre;

        [CustomRequired]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                InvokePropertyChanged("");
            }
        }

        private string password;

        [CustomRequired]
        public string Password
        {
            get { return password; }
            set { password = value;
                InvokePropertyChanged("");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
