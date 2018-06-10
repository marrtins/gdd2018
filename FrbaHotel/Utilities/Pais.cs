namespace FrbaHotel.Utilities
{
    public class Pais
    {
        public int idPais { get; set; }
        public string Nombre { get; set; }

        public Pais(int id, string nombre)
        {
            idPais = id;
            Nombre = nombre;
        }

        public Pais()
        {
        }
    }
}