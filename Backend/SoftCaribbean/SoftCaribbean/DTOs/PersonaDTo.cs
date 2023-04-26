namespace SoftCaribbean.DTOs
{
    public class PersonaDTo
    {
        public int Id { get; set; }
        public string? Documento { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public int? IdTipoDocumento { get; set; }

        public int? IdGenero { get; set; }

        public string? Direccion { get; set; }

        public string? TelefonoFijo { get; set; }

        public string? TelefonoMovil { get; set; }

        public string? Email { get; set; }
    }
}
