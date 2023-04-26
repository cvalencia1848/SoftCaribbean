using System;
using System.Collections.Generic;

namespace SoftCaribbean.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public int IdPersona { get; set; }

    public int? IdMedicoTratante { get; set; }

    public string? Eps { get; set; }

    public string? Arl { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaBaja { get; set; }

    public string? CodigoUsuario { get; set; }

    public string? Condicion { get; set; }

    public virtual MedicosTratante? IdMedicoTratanteNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
