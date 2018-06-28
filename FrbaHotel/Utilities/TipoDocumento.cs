namespace FrbaHotel.Utilities
{
    public class TipoDocumento
    {
        public int idTipoDocumento { get; set; }
        public string descripcion { get; set; }

        public TipoDocumento(int id, string descripcion)
        {
            idTipoDocumento = id;
            //Descripcion = descripcion;
        }

        public TipoDocumento()
        {
        }
    }
}