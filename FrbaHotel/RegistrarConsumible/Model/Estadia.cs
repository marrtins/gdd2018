using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.RegistrarConsumibles.Model
{
    public static class MensajesValidacion
    {
        public static string Requerido = "El campo es requerido";
    }

    [Serializable]
    public class Estadia : INotifyPropertyChanged
    {
        private string codigoReserva;
        private int idTipoRegimen;
        private string nroHabitacion;
        private string piso;
        private DateTime fechaCheckIn;
        private DateTime fechaCheckOut;

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string CodigoReserva
        {
            get => codigoReserva;
            set
            {
                codigoReserva = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string NroHabitacion
        {
            get
            {
                return nroHabitacion;
            }

            set
            {
                nroHabitacion = value;
                InvokePropertyChanged("");
            }
        }

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
        public DateTime FechaCheckIn
        {
            get => fechaCheckIn;
            set
            {
                fechaCheckIn = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        public DateTime FechaCheckOut
        {
            get => fechaCheckOut;
            set
            {
                fechaCheckOut = value;
                InvokePropertyChanged("");
            }
        }

        public int IdTipoRegimen{get => idTipoRegimen; set idTipoRegimen = value; }


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
