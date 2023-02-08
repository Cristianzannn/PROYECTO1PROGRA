using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class ParametrosServicio
{
    public int IdParametro { get; set; }

    public double Timeout { get; set; }

    public string Disponibilidad { get; set; } = null!;

    public int IdServicios { get; set; }

    public virtual Servicio IdServiciosNavigation { get; set; } = null!;
}
