using FrbaHotel.Utilities;
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
            FechaDesde = LoginData.SystemDate;
            FechaHasta = LoginData.SystemDate;
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
                if (value < LoginData.SystemDate)
                    value = LoginData.SystemDate;

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
