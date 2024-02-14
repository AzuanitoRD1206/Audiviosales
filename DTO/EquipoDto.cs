using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models.DTO;

public class EquipoDto
{

    public string Descripcion { get; set; } = null!;

    public string? NoSerial { get; set; }

    public string? ServiceTag { get; set; }

    public int TipoEquipoId { get; set; }

    public int MarcaId { get; set; }

    public int ModeloId { get; set; }

    public int? TipoTecnologiaConexionId { get; set; }

    public string? Estado { get; set; }

}
