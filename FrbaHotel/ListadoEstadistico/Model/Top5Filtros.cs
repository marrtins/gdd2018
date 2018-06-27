using FrbaHotel.AbmHabitacion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.ListadoEstadistico.Model
{
    public class Top5Filtros : INotifyPropertyChanged
    {
        private string _anio;
        private string _trimestre;
        private string _top5De;

        [CustomRequired]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener numeros.")]
        public string Anio
        {
            get
            {
                return _anio;
            }
            set
            {
                _anio = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        public string Trimestre
        {
            get
            {
                return _trimestre;
            }
            set
            {
                _trimestre = value;
                InvokePropertyChanged("");
            }
        }

        [CustomRequired]
        public string Top5De
        {
            get
            {
                return _top5De;
            }
            set
            {
                _top5De = value;
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
