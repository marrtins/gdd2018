﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FrbaHotel.AbmUsuario.Model
{
    public static class MensajesValidacion
    {
        public static string Requerido = "El campo es requerido";
    }
    internal class CustomRequiredAttribute : RequiredAttribute
    {
        public CustomRequiredAttribute()
            : base()
        {
            this.ErrorMessage = "Este campo es requerido";
        }
    }

    [Serializable]
    public class Usuario : INotifyPropertyChanged
    {
        
        private int idUsuario; // PK
        private int idRol; // FK
        private int idPersona; // FK
        private int idHotel; // Fk
        private DateTime fechaNac;
        private int idTipoDocumento; // FK
        private string nroDocumento; 
        private string telefono;
        private string mail;
        private char activo;


        // direccion calle nro pais

        string username;
        [CustomRequired]
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

        string password;
        [CustomRequired]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                InvokePropertyChanged("");
            }
        }


        string nombre;
        [CustomRequired]
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

        string apellido;
        [CustomRequired]
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

        int idPais;

        string calle;
        [CustomRequired]
        public string Calle
        {
            get
            {
                return calle;
            }

            set
            {
                calle = value;
                InvokePropertyChanged("");
            }
        }

        string nroCalle;
        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string NroCalle
        {
            get
            {
                return nroCalle;
            }

            set
            {
                nroCalle = value;
                InvokePropertyChanged("");
            }
        }

        string localidad;
        [CustomRequired]
        public string Localidad
        {
            get
            {
                return localidad;
            }

            set
            {
                localidad = value;
                InvokePropertyChanged("");
            }
        }

        public Usuario(int id, string username, string password, int idRol, string nombre, string apellido, int idTipoDocumento, string nroDocumento, DateTime fechaNac, string mail, string telefono, int idPais, int idHotel, string calle, string nroCalle, string localidad, string depto, string piso)
        {
            // Dirección
            NroCalle = nroCalle;
            Calle = calle;
            IdPais = idPais;
            Localidad = localidad;
            Depto = depto;
            Piso = piso;

            // Usuario
            Username = username;
            Password = password;
            idUsuario = id;
            IdRol = idRol;
            IdHotel = idHotel;

            // Persona
            Nombre = nombre;
            Apellido = apellido;
            IdTipoDocumento = idTipoDocumento;
            NroDocumento = nroDocumento;
            Mail = mail;
            Telefono = telefono;
            
        }

        public Usuario()
        {

        }

        [CustomRequired]
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

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string Telefono
        {
            get 
            {
                return telefono;
            }
            set
            {
                telefono = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
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

        string depto;
        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string Depto
        {
            get 
            {
                return depto;
            }
            set
            {
                depto = value;
                InvokePropertyChanged("");
            }
        }

        string piso;
        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string Piso
        {
            get 
            {
                return piso;
            }
            set
            {
                piso = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        public DateTime FechaNac
        {
            get 
            {
                return fechaNac;
            }
            set
            {
                fechaNac = value;
                InvokePropertyChanged("");
            }
        }



        public int IdUsuario {
             get 
             {
                 return idUsuario;
             }
             set 
             {
                 idUsuario = value;
             }
            }
        public int IdPais {
            get 
             {
                 return idPais;
             }
             set 
             {
                 idPais = value;
             }
            }
        public int IdTipoDocumento { 
            get 
             {
                 return idTipoDocumento;
             }
             set 
             {
                 idTipoDocumento = value;
             } 
            }
        public int IdRol {
            get 
             {
                 return idRol;
             }
             set 
             {
                 idRol = value;
             } 
            } 


        public char Activo
        {
            get 
             {
                 return activo;
             }
             set 
             {
                 activo = value;
                 InvokePropertyChanged("");
             } 
        }

        public int IdPersona
        {
            get   
             {
                 return idPersona;
             }
            set
            {
                idPersona = value;
            }
        }

        public int IdHotel
        {
            get
            {
                return idHotel;
            }
            set
            {
                idHotel = value;
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
