using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FrbaHotel.Utilities;


namespace FrbaHotel.AbmHabitacion.Model
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
    class Habitacion : INotifyPropertyChanged
    {
        private int idHabitacion; //PK 

        private int idTipoHabitacion; //FK 
        private int numeroHabitacion;// Unique
        private int idHotel; //FK
        private int piso;
        private char vistaAlExterior;
        private string descripcion;
        private char habilitado;
       

        [CustomRequired]
        public int IdHabitacion
        {
            get { return idHabitacion; }
            set
            {
                idHabitacion = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        public int NumeroHabitacion
        {
            get {return numeroHabitacion; }
            set
            {
                numeroHabitacion = value;
                InvokePropertyChanged("");
            }
        }

        public int IdHotel
        {
            get { return idHotel; }
            set
            {
                idHotel = value;
                InvokePropertyChanged("");
            }
        }
     
        public int IdTipoHabitacion
        {
            get { return idTipoHabitacion; }
            set
            {
                idTipoHabitacion = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public int Piso
        {
            get { return piso; }
            set
            {
                piso = value;
                InvokePropertyChanged("");
            }
        }


        [CustomRequired]
        public char VistaAlExterior
        {
            get { return vistaAlExterior; }
            set
            {
                vistaAlExterior = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                InvokePropertyChanged("");
            }
        }
        [CustomRequired]
        public char Habilitado
        {
            get { return Habilitado; }
            set
            {
                Habilitado = value;
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
