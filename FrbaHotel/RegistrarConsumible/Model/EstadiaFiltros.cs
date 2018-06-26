using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.RegistrarConsumibles.Model
{
    internal class EstadiaFiltros : INotifyPropertyChanged
    {
        int codigoReserva;
        int nroHabitacion;
        int piso;
        public int idTipoRegimen;

        public int CodigoReserva
        {
            get
            {
                return codigoReserva;
            }

            set
            {
                codigoReserva = value;
                InvokePropertyChanged("");
            }
        }

        public int NroHabitacion
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

        public int Piso
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

        public int IdTipoRegimen {get; set; }

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
