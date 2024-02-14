using System;
using System.Collections.Generic;

namespace CrudAudiovisuales.models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Cedula { get; set; }

    public string? NoCarnet { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public string TipoPersona { get; set; } = null!;

    public string? Estado { get; set; }

    public string? Nombredeusuario { get; set; }
    
    public string? CorreoElectronico { get; set; }
    
    public string?  Contrasena { get; set; }

    public virtual ICollection<Rentadevolucion> Rentadevolucions { get; set; } = new List<Rentadevolucion>();
}
