namespace FrbaHotel.Utilities
{
    public class TipoDocumento
    {

        public int idTipoDocumento { get; set; }
        public string Detalle  { get; set; }

        public TipoDocumento(int id, string detalle)
        {
            idTipoDocumento = id;
            Detalle = detalle;
        }

        public TipoDocumento()
        {
        }
    }
}