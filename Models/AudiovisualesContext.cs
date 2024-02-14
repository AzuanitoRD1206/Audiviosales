using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudAudiovisuales.models;

public partial class AudiovisualesContext : DbContext
{
    public AudiovisualesContext()
    {
    }

    public AudiovisualesContext(DbContextOptions<AudiovisualesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Rentadevolucion> Rentadevolucions { get; set; }

    public virtual DbSet<Tecnologiasconexion> Tecnologiasconexions { get; set; }

    public virtual DbSet<Tiposdeequipo> Tiposdeequipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseMySql("server=localhost;port=3306;database=audiovisuales;uid=root;password=Yadiel1206@", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TandaLabor)
                .HasMaxLength(20)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipos");

            entity.HasIndex(e => e.MarcaId, "MarcaID");

            entity.HasIndex(e => e.ModeloId, "ModeloID");

            entity.HasIndex(e => e.TipoEquipoId, "TipoEquipoID");

            entity.HasIndex(e => e.TipoTecnologiaConexionId, "TipoTecnologiaConexionID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.ModeloId).HasColumnName("ModeloID");
            entity.Property(e => e.NoSerial)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ServiceTag)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoEquipoId).HasColumnName("TipoEquipoID");
            entity.Property(e => e.TipoTecnologiaConexionId).HasColumnName("TipoTecnologiaConexionID");

            entity.HasOne(d => d.Marca).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("equipos_ibfk_2");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.ModeloId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("equipos_ibfk_3");

            entity.HasOne(d => d.TipoEquipo).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.TipoEquipoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("equipos_ibfk_1");

            entity.HasOne(d => d.TipoTecnologiaConexion).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.TipoTecnologiaConexionId)
                .HasConstraintName("equipos_ibfk_4");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("marcas");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modelos");

            entity.HasIndex(e => e.MarcaId, "MarcaID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");

            entity.HasOne(d => d.Marca).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("modelos_ibfk_1");
        });

        modelBuilder.Entity<Rentadevolucion>(entity =>
        {
            entity.HasKey(e => e.NoPrestamo).HasName("PRIMARY");

            entity.ToTable("rentadevolucion");

            entity.HasIndex(e => e.EmpleadoId, "EmpleadoID");

            entity.HasIndex(e => e.EquipoId, "EquipoID");

            entity.HasIndex(e => e.UsuarioId, "UsuarioID");

            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.EquipoId).HasColumnName("EquipoID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");
            entity.Property(e => e.FechaPrestamo).HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Rentadevolucions)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("rentadevolucion_ibfk_1");

            entity.HasOne(d => d.Equipo).WithMany(p => p.Rentadevolucions)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("rentadevolucion_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Rentadevolucions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("rentadevolucion_ibfk_3");
        });

        modelBuilder.Entity<Tecnologiasconexion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tecnologiasconexion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Tiposdeequipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tiposdeequipos");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NoCarnet)
                .HasMaxLength(20)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
