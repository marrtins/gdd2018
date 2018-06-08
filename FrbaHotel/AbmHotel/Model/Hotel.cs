using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrbaHotel.AbmHotel.Model
{
    public static class MensajesValidacion
    {
        public static string Requerido = "El campo es requerido";
    }

    public class Hotel : DBObject, INotifyPropertyChanged
    {
        private string _telefono;
        private string _mail;
        private string _ciudad;

        public Hotel(int id)
            : base(id)
        {
        }

        public Hotel(int id, string mail, Direccion direccion, string telefono, int cantidadEstrellas, string ciudad)
: base(id)
        {
            Id = id;
            Mail = mail;
            Direccion = direccion;
            Telefono = telefono;
            CantidadEstrellas = cantidadEstrellas;
            Ciudad = ciudad;
        }

        [CustomRequired]
        public string Mail
        {
            get => _mail;
            set
            {
                _mail = value;
                InvokePropertyChanged("");
            }
        }
        public Direccion Direccion { get; set; }

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string Telefono
        {
            get => _telefono;
            set
            {
                _telefono = value;
                InvokePropertyChanged("");
            }
        }
        public int CantidadEstrellas { get; set; }



        public string Ciudad
        {
            get => _ciudad; set
            {
                _ciudad = value;
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
