using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHotel.Model
{
    public class HotelBaja : INotifyPropertyChanged
    {
        public int idHotel { get; set; }
        DateTime fechaDesde;

        public HotelBaja()
        {
            FechaDesde = DateTime.Today;
            FechaHasta = DateTime.Today;
        }

        [CustomRequired]
        public DateTime FechaDesde
        {
            get
            {
                return fechaDesde;
            }

            set
            {
                if (value < DateTime.Today)
                    value = DateTime.Today;

                fechaDesde = value;
                InvokePropertyChanged("");

            }
        }
        DateTime fechaHasta;

        [CustomRequired]
        public DateTime FechaHasta
        {
            get
            {
                return fechaHasta;
            }

            set
            {
                if (value < FechaDesde)
                    value = FechaDesde;

                fechaHasta = value;
                InvokePropertyChanged("");
            }
        }
        string motivo;

        [CustomRequired]
        [StringLength(500,ErrorMessage = "El motivo puede tener hasta 500 caracteres")]
        public string Motivo
        {
            get
            {
                return motivo;
            }

            set
            {
                motivo = value;
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
