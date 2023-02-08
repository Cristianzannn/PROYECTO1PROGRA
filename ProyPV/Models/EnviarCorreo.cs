using System;
using System.Collections.Generic;

namespace ProyPV.DataAccess.Models;

public partial class EnviarCorreo
{
    public int IdCorreo { get; set; }

    public string AsuntoCorreo { get; set; } = null!;

    public string CuerpoCorreo { get; set; } = null!;

    public string Destinatarios { get; set; } = null!;

    public string CorreoEncargado { get; set; } = null!;

    public int IdEncargado { get; set; }

    public virtual EncargadoServidore IdEncargado1 { get; set; } = null!;

    public virtual EncargadoServicio IdEncargadoNavigation { get; set; } = null!;
}
