using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.RegistrarConsumible
{
   

    class Consumible
    {
        int idConsumible;
        int costo;
        string nombre;
        int codigoConsumible;

        public int IdConsumible
        {
            get
            {
                return idConsumible;
            }

            set
            {
                idConsumible = value;
            }
        }

        public int Costo
        {
            get
            {
                return costo;
            }

            set
            {
                costo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int CodigoConsumible
        {
            get
            {
                return codigoConsumible;
            }

            set
            {
                codigoConsumible = value;
            }
        }
    }
}
