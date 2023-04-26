using System;
using System.Collections.Generic;

namespace SoftCaribbean.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Documento { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? IdTipoDocumento { get; set; }

    public int? IdGenero { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaBaja { get; set; }

    public string? Direccion { get; set; }

    public string? Foto { get; set; }

    public string? TelefonoFijo { get; set; }

    public string? TelefonoMovil { get; set; }

    public string? Email { get; set; }

    public virtual Genero? IdGeneroNavigation { get; set; }

    public virtual TiposDocumento? IdTipoDocumentoNavigation { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
