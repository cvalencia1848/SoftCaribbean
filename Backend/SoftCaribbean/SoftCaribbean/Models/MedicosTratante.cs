using System;
using System.Collections.Generic;

namespace SoftCaribbean.Models;

public partial class MedicosTratante
{
    public int Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
