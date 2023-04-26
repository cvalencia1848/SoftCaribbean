using System;
using System.Collections.Generic;

namespace SoftCaribbean.Models;

public partial class TiposDocumento
{
    public int Id { get; set; }

    public string? Abreviatura { get; set; }

    public string? TipoDocumento { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
