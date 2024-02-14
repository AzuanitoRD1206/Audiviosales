using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models.DTO;

public  class RentadevolucionDto
{
    public int NoPrestamo { get; set; }

    public int EmpleadoId { get; set; }

    public int EquipoId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string? Comentario { get; set; }

    public string? Estado { get; set; }

}
