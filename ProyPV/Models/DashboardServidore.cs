using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class DashboardServidore
{
    public int Iddashboard { get; set; }

    public int CodigoServidor { get; set; }

    public string FechaUltimomonitoreo { get; set; } = null!;

    public string UsoCpu { get; set; } = null!;

    public string UsoMemoria { get; set; } = null!;

    public string UsoDisco { get; set; } = null!;

    public string EstadoGeneral { get; set; } = null!;

    public virtual Servidor CodigoServidorNavigation { get; set; } = null!;
}
