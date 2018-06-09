using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHotel.Model
{
    internal class HotelFiltros : INotifyPropertyChanged
    {
        private string _ciudad;
        string nombre;

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
