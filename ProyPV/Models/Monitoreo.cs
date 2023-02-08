using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class Monitoreo
{
    public int NombreComputador { get; set; }

    public string? Cpu { get; set; }

    public string? Memoria { get; set; }

    public string? EspacioDisp { get; set; }

    public int? CodigoServidor { get; set; }

    public virtual Servidor? CodigoServidorNavigation { get; set; }
}
