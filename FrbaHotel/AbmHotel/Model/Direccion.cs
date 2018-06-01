namespace FrbaHotel.AbmHotel.Model
{
    public class Direccion : DBObject
    {
        public Pais Pais { get; set; }
        public string Calle { get; set; }

        public Direccion(int Id, Pais pais, string calle)
            : base(Id)
        {
            Pais = pais;
            Calle = calle;
        }
    }
}