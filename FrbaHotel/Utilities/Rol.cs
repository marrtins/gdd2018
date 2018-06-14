namespace FrbaHotel.Utilities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Activo { get; set; }

        public Rol(int id, string nombre, string activo)
        {
            Id = id;
            Nombre = nombre;
            Activo = activo;
        }

        public Rol()
        {
        }
    }
}