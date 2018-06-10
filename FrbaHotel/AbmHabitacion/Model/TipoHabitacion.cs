using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrbaHotel.AbmHabitacion.Model
{
    class TipoHabitacion
    {
        private int idTipoHabitacion; //PK
        private char descripcion;

        public int IdTipoHabitacion
        {
            get => idTipoHabitacion;
            set
            {
                idTipoHabitacion = value;
                InvokePropertyChanged("");
            }
        }

        public char Descripcion
        {
            get => descripcion;
            set
            {
                descripcion = value;
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
