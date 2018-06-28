using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.GenerarModificacionReserva
{

    


    public class Reserva
    {
        /*private int idReserva;
        private int idUsuarioQueProcesoReserva;
        private DateTime FechaDeReserva;
        private DateTime FechaDesde;
        private DateTime FechaHasta;
        private int idHabitacion;
        private int idRegimen;
        private int idHuesped;
        private char EstadoReserva;
        private int CodigoReserva;*/

        public int idReserva { get; set; }
        public int idHotel { get; set; }
        public List<Int32> idHabitaciones { get; set; }
        public int idUsuarioQueProcesoReserva { get; set; }
        public DateTime FechaDeReserva { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        
        public char EstadoReserva { get; set; }
        public int idRegimen { get; set; }

        public int idHuesped { get; set; }

        public int CodigoReserva { get; set; }

    }
    public class TipoCant
    {
        public int cant { get; set; }
        public string desc { get; set; }
    }
}
