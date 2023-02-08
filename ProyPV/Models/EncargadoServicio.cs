using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class EncargadoServicio
{
    public int IdEncargadoServicios { get; set; }

    public string? NombreEncargado { get; set; }

    public string? CorreoEncServ { get; set; }

    public int? CodigoServicio { get; set; }

    public virtual Servicio? CodigoServicioNavigation { get; set; }

    public virtual ICollection<EnviarCorreo> EnviarCorreos { get; } = new List<EnviarCorreo>();
}
