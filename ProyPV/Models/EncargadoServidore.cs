using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class EncargadoServidore
{
    public int IdEncargadoServidores { get; set; }

    public string? NombreEnca { get; set; }

    public string? CorreoEnca { get; set; }

    public int? CodigoServidor { get; set; }

    public virtual Servidor? CodigoServidorNavigation { get; set; }

    public virtual ICollection<EnviarCorreo> EnviarCorreos { get; } = new List<EnviarCorreo>();
}
