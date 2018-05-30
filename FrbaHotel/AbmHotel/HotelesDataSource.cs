using FrbaHotel.AbmHotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace FrbaHotel.AbmHotel
{
    class HotelesRepository
    {
        public IList<Filter> Filters { get; } = new List<Filter>();
        public BindingList<Hotel> Hoteles { get; } = new BindingList<Hotel>();

        public HotelesRepository()
        {
        }

        public void Refresh()
        {
            Hoteles.Add(new Hotel(1, "prueba@prueba.com", new Direccion(1, new Pais(1, "Argentina"), "calle 1"), "1144223322", 5, "CABA"));
        }

        public HotelesRepository(IList<Filter> filters, IList<Hotel> hoteles)
        {
            Contract.Requires(hoteles != null);
            Contract.Requires(filters != null);

            Filters = filters;
            this.Hoteles = new BindingList<Hotel>(hoteles);
        }
    }
}