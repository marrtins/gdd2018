using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FrbaHotel.AbmUsuario.Model
{
    [Serializable]
    public class Hotel
    {
        public int idHotel { get; set; }
        public string Nombre { get; set; }

        public Hotel(int id, string nombre)
        {
            idHotel = id;
            Nombre = nombre;
        }

        public Hotel()
        {

        }
    }
}