using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHotel.Model
{
    public class Hotel : DBObject
    {
        public Hotel(int id, string mail, Direccion direccion, string telefono, int cantidadEstrellas, string ciudad)
            :base(id)
        {
            Id = id;
            Mail = mail;
            Direccion = direccion;
            Telefono = telefono;
            CantidadEstrellas = cantidadEstrellas;
            Ciudad = ciudad;
        }

        public string Mail { get; set; }
        public Direccion Direccion { get; set; }
        public string Telefono { get; set; }
        public int CantidadEstrellas { get; set; }
        public string Ciudad { get; set; }
        
    }
}
