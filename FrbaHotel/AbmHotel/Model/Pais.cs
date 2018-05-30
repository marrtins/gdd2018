namespace FrbaHotel.AbmHotel.Model
{
    public class Pais : DBObject
    {
        public Pais(int id, string nombre) : base(id)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get; }
    }
}