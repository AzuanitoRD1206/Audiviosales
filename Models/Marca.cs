using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models;

public partial class Marca
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Estado { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
