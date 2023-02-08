using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class DashboardServicio
{
    public int IdDashboard { get; set; }

    public int CodigoServicio { get; set; }

    public double Timeout { get; set; }

    public string Disponibilidad { get; set; } = null!;

    public virtual Servicio CodigoServicioNavigation { get; set; } = null!;
}
