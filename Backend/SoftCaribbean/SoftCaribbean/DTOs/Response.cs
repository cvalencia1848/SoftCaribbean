namespace SoftCaribbean.DTOs
{
    public class Response<TEntidad>
    {
        public Response()
        {
            this.Exitoso = false;
        }

        public TEntidad Entidad { get; set; }

        public bool Exitoso { get; set; }

        public string MensajeError { get; set; }

    }
}
