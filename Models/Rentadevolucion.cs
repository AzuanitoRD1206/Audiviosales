using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models;

public partial class Rentadevolucion
{
    public int NoPrestamo { get; set; }

    public int EmpleadoId { get; set; }

    public int EquipoId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string? Comentario { get; set; }

    public string? Estado { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Equipo Equipo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
