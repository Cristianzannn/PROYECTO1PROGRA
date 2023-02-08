using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class Servidor
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Administrador { get; set; } = null!;

    public string Parametros { get; set; } = null!;

    public virtual ICollection<DashboardServidore> DashboardServidores { get; } = new List<DashboardServidore>();

    public virtual ICollection<EncargadoServidore> EncargadoServidores { get; } = new List<EncargadoServidore>();

    public virtual ICollection<Monitoreo> Monitoreos { get; } = new List<Monitoreo>();

    public virtual ParametrosSensibilidad ParametrosNavigation { get; set; } = null!;

    public virtual ICollection<ParametrosSensibilidad> ParametrosSensibilidads { get; } = new List<ParametrosSensibilidad>();
}
