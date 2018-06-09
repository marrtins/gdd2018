namespace FrbaHotel.Utilities
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Pais(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Pais()
        {
        }
    }
}