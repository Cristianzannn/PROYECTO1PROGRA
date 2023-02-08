using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyPV.DataAccess.Models;

public partial class ProyectoProgra5Context : DbContext
{
    public ProyectoProgra5Context()
    {
    }

    public ProyectoProgra5Context(DbContextOptions<ProyectoProgra5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DashboardServicio> DashboardServicios { get; set; }

    public virtual DbSet<DashboardServidore> DashboardServidores { get; set; }

    public virtual DbSet<EncargadoServicio> EncargadoServicios { get; set; }

    public virtual DbSet<EncargadoServidore> EncargadoServidores { get; set; }

    public virtual DbSet<EnviarCorreo> EnviarCorreos { get; set; }

    public virtual DbSet<Monitoreo> Monitoreos { get; set; }

    public virtual DbSet<MonitoreoServicio> MonitoreoServicios { get; set; }

    public virtual DbSet<ParametrosSensibilidad> ParametrosSensibilidads { get; set; }

    public virtual DbSet<ParametrosServicio> ParametrosServicios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Servidor> Servidors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Proyecto");

        modelBuilder.Entity<DashboardServicio>(entity =>
        {
            entity.HasKey(e => e.IdDashboard);

            entity.ToTable("DashboardServicios", "dbo");

            entity.Property(e => e.IdDashboard)
                .ValueGeneratedNever()
                .HasColumnName("idDashboard");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Timeout).HasColumnName("timeout");

            entity.HasOne(d => d.CodigoServicioNavigation).WithMany(p => p.DashboardServicios)
                .HasForeignKey(d => d.CodigoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DashboardServicios_Servicios");
        });

        modelBuilder.Entity<DashboardServidore>(entity =>
        {
            entity.HasKey(e => e.Iddashboard);

            entity.ToTable("DashboardServidores", "dbo");

            entity.Property(e => e.Iddashboard)
                .ValueGeneratedNever()
                .HasColumnName("IDdashboard");
            entity.Property(e => e.EstadoGeneral)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaUltimomonitoreo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsoCpu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UsoCPU");
            entity.Property(e => e.UsoDisco)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsoMemoria)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoServidorNavigation).WithMany(p => p.DashboardServidores)
                .HasForeignKey(d => d.CodigoServidor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DashboardServidores_Servidor");
        });

        modelBuilder.Entity<EncargadoServicio>(entity =>
        {
            entity.HasKey(e => e.IdEncargadoServicios).HasName("PK__Encargad__EAAFC2C14F7A5C13");

            entity.ToTable("EncargadoServicios", "dbo");

            entity.Property(e => e.CorreoEncServ)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreEncargado)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoServicioNavigation).WithMany(p => p.EncargadoServicios)
                .HasForeignKey(d => d.CodigoServicio)
                .HasConstraintName("FK_EncargadoServicios_Servicios");
        });

        modelBuilder.Entity<EncargadoServidore>(entity =>
        {
            entity.HasKey(e => e.IdEncargadoServidores).HasName("PK__Encargad__E4253249DD8BB93B");

            entity.ToTable("EncargadoServidores", "dbo");

            entity.Property(e => e.CorreoEnca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreEnca)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoServidorNavigation).WithMany(p => p.EncargadoServidores)
                .HasForeignKey(d => d.CodigoServidor)
                .HasConstraintName("FK_EncargadoServidores_Servidor");
        });

        modelBuilder.Entity<EnviarCorreo>(entity =>
        {
            entity.HasKey(e => e.IdCorreo);

            entity.ToTable("EnviarCorreo", "dbo");

            entity.Property(e => e.AsuntoCorreo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoEncargado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CuerpoCorreo)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Destinatarios)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEncargadoNavigation).WithMany(p => p.EnviarCorreos)
                .HasForeignKey(d => d.IdEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnviarCorreo_EncargadoServicios");

            entity.HasOne(d => d.IdEncargado1).WithMany(p => p.EnviarCorreos)
                .HasForeignKey(d => d.IdEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnviarCorreo_EncargadoServidores");
        });

        modelBuilder.Entity<Monitoreo>(entity =>
        {
            entity.HasKey(e => e.NombreComputador).HasName("PK__Monitore__DB1DE4566D726250");

            entity.ToTable("Monitoreo", "dbo");

            entity.Property(e => e.Cpu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CPU");
            entity.Property(e => e.EspacioDisp)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Memoria)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoServidorNavigation).WithMany(p => p.Monitoreos)
                .HasForeignKey(d => d.CodigoServidor)
                .HasConstraintName("FK_Monitoreo_Servidor");
        });

        modelBuilder.Entity<MonitoreoServicio>(entity =>
        {
            entity.HasKey(e => e.CodigoServicios);

            entity.ToTable("MonitoreoServicios", "dbo");

            entity.Property(e => e.CodigoServicios).ValueGeneratedNever();

            entity.HasOne(d => d.CodigoServiciosNavigation).WithOne(p => p.MonitoreoServicio)
                .HasForeignKey<MonitoreoServicio>(d => d.CodigoServicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonitoreoServicios_Servicios");
        });

        modelBuilder.Entity<ParametrosSensibilidad>(entity =>
        {
            entity.HasKey(e => e.NombreParametro);

            entity.ToTable("ParametrosSensibilidad", "dbo");

            entity.Property(e => e.NombreParametro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rango)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdServidorNavigation).WithMany(p => p.ParametrosSensibilidads)
                .HasForeignKey(d => d.IdServidor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParametrosSensibilidad_Servidor");
        });

        modelBuilder.Entity<ParametrosServicio>(entity =>
        {
            entity.HasKey(e => e.IdParametro);

            entity.ToTable("ParametrosServicios", "dbo");

            entity.Property(e => e.IdParametro).ValueGeneratedNever();
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdServiciosNavigation).WithMany(p => p.ParametrosServicios)
                .HasForeignKey(d => d.IdServicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParametrosServicios_Servicios");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Servicios", "dbo");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servidor>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Servidor", "dbo");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Administrador)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Parametros)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ParametrosNavigation).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.Parametros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servidor_ParametrosSensibilidad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
