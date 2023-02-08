using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyPV.DataAccess.Models;

public partial class ParametrosSensibilidad
{
    public string NombreParametro { get; set; } = null!;

    public string Rango { get; set; } = null!;

    public int IdServidor { get; set; }

    [JsonIgnore]
    public virtual Servidor IdServidorNavigation { get; set; } = null!;

    public virtual ICollection<Servidor> Servidors { get; } = new List<Servidor>();
}
