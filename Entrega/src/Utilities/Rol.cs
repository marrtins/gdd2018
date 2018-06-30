using FrbaHotel.AbmRol.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FrbaHotel.Utilities
{
    [Serializable]
    public class Rol
    {
        public int idRol { get; set; }
        public string Nombre { get; set; }
        public string Activo { get; set; }
        public BindingList<Funcionalidad> Funcionalidades { get; set; }  //No se carga excepto en el ABMRol

        public Rol(int id, string nombre, string activo)
        {
            idRol = id;
            Nombre = nombre;
            Activo = activo;
            Funcionalidades = new BindingList<Funcionalidad>();
        }

        public Rol()
        {
            Funcionalidades = new BindingList<Funcionalidad>();

        }
    }
}