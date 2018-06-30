using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmUsuario.Model
{
    internal class UsuarioFiltros : INotifyPropertyChanged
    {
        string username;
        string nombre;
        string apellido;
        string mail;
        string nroDocumento;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                InvokePropertyChanged("");
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
                InvokePropertyChanged("");
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
                InvokePropertyChanged("");
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
                InvokePropertyChanged("");
            }
        }

        public string NroDocumento
        {
            get
            {
                return nroDocumento;
            }

            set
            {
                nroDocumento = value;
                InvokePropertyChanged("");
            }
        }

        public int IdRol {get; set; }
        public int IdTipoDocumento {get; set; }




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
