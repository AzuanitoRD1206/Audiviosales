using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Cedula { get; set; }

    public string TandaLabor { get; set; } = null!;

    public DateOnly? FechaIngreso { get; set; }

    public string? Estado { get; set; }
    public virtual ICollection<Rentadevolucion> Rentadevolucions { get; set; } = new List<Rentadevolucion>();
}
