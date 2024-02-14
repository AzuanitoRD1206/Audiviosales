using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models;

public partial class Equipo
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? NoSerial { get; set; }

    public string? ServiceTag { get; set; }

    public int TipoEquipoId { get; set; }

    public int MarcaId { get; set; }

    public int ModeloId { get; set; }

    public int? TipoTecnologiaConexionId { get; set; }

    public string? Estado { get; set; }

    public virtual Marca Marca { get; set; } = null!;

    public virtual Modelo Modelo { get; set; } = null!;

    public virtual ICollection<Rentadevolucion> Rentadevolucions { get; set; } = new List<Rentadevolucion>();

    public virtual Tiposdeequipo TipoEquipo { get; set; } = null!;

    public virtual Tecnologiasconexion? TipoTecnologiaConexion { get; set; }
}
