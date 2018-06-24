using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FrbaHotel.Utilities;


namespace FrbaHotel.ListadoEstadistico.Model
{
    class ListadoEstadistico
    {

        private string año;

      
        public string Año
        {
            get { return año; }
            set
            {
                año = value;
                InvokePropertyChanged("");
            }
        }
        
        string trimestre;
        string top5;
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
