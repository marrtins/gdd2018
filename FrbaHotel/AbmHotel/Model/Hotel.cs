﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrbaHotel.AbmHotel.Model
{
    public static class MensajesValidacion
    {
        public static string Requerido = "El campo es requerido";
    }

    [Serializable]
    public class Hotel : INotifyPropertyChanged
    {
        private string _telefono;
        private string _mail;
        private string _ciudad;
        DateTime fechaDeCreacion;

        [CustomRequired]

        public DateTime FechaDeCreacion
        {
            get
            {
                return fechaDeCreacion;
            }

            set
            {
                fechaDeCreacion = value;
                InvokePropertyChanged("");

            }
        }

        int idHotel;
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

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string RecargaEstrellas
        {
            get
            {
                return recargaEstrellas;
            }

            set
            {
                recargaEstrellas = value;
                InvokePropertyChanged("");
            }
        }

        int idPais;
         //Refactor pendiente: hay que separar la entidad de su buildeada con un builder. Ahi vamos a pder usar mas objetos y cosas mas lindas
        string nombrePais;

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

        public Hotel(int id, string nombre, string mail, string telefono, int cantidadEstrellas, string ciudad, int idPais, string nombrePais, string calle, string nroCalle)
        {
            NroCalle = nroCalle;
            Calle = calle;
            Calle = calle;
            IdPais = idPais;
            NombrePais = nombrePais;
            Nombre = nombre;
            idHotel = id;
            Mail = mail;
            Telefono = telefono;
            CantidadEstrellas = cantidadEstrellas;
            Ciudad = ciudad;
            FechaDeCreacion = new DateTime();
        }

        public Hotel()
        {
            FechaDeCreacion = new DateTime();
        }

        [CustomRequired]
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                InvokePropertyChanged("");
            }
        }
        public int CantidadEstrellas { get; set; }


        [CustomRequired]
        public string Ciudad
        {
            get { return _ciudad; }
            set
            {
                _ciudad = value;
                InvokePropertyChanged("");
            }
        }

        public int IdHotel { get { return idHotel; } set { idHotel = value; } }
        public int IdPais { get { return idPais; } set { idPais = value; } }
        public string NombrePais { get { return nombrePais; } set { nombrePais = value; } }
        private int idDireccion;
        private string recargaEstrellas;

        public int IdDireccion
        {
            get { return idDireccion; }
            set
            {
                idDireccion = value;
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
