using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models.DTO;

public class ModeloDto
{

    public int MarcaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Estado { get; set; }

}
