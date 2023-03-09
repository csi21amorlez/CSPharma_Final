using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class CspharmaInformationalContext : DbContext
{
    public CspharmaInformationalContext()
    {
    }

    public CspharmaInformationalContext(DbContextOptions<CspharmaInformationalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DlkCatAccEmpleado> DlkCatAccEmpleados { get; set; }

    public virtual DbSet<DlkCatAccRole> DlkCatAccRoles { get; set; }

    public virtual DbSet<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedidos { get; set; }

    public virtual DbSet<TdcCatLineasDistribucion> TdcCatLineasDistribucions { get; set; }

    public virtual DbSet<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=cspharma_informational;User Id=postgres;Password=root123"                        
            );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DlkCatAccEmpleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dlk_cat_acc_empleado_pkey");

            entity.ToTable("dlk_cat_acc_empleado", "dlk_informacional");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClaveEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("clave_empleado");
            entity.Property(e => e.CodEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("cod_empleado");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
            entity.Property(e => e.NivelAcceso).HasColumnName("nivel_acceso");

            entity.HasOne(d => d.NivelAccesoNavigation).WithMany(p => p.DlkCatAccEmpleados)
                .HasForeignKey(d => d.NivelAcceso)
                .HasConstraintName("rol");
        });

        modelBuilder.Entity<DlkCatAccRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dlk_cat_acc_roles_pkey");

            entity.ToTable("dlk_cat_acc_roles", "dlk_informacional");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DescRol)
                .HasColumnType("character varying")
                .HasColumnName("descRol");
        });

        modelBuilder.Entity<TdcCatEstadosDevolucionPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_cat_estados_devolucion_pedido_pkey");

            entity.ToTable("tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");

            entity.HasIndex(e => e.CodEstadoDevolucion, "cod_estado_devolucion").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoDevolucion)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.DesEstadoDevolucion)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_devolucion");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosEnvioPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_cat_estados_envio_pedido_pkey");

            entity.ToTable("tdc_cat_estados_envio_pedido", "dwh_torrecontrol");

            entity.HasIndex(e => e.CodEstadoEnvio, "cod_estado_envio").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.DesEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_envio");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosPagoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_cat_estados_pago_pedido_pkey");

            entity.ToTable("tdc_cat_estados_pago_pedido", "dwh_torrecontrol");

            entity.HasIndex(e => e.CodEstadoPago, "cod_estado_pago").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoPago)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.DesEstadoPago)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_pago");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatLineasDistribucion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_cat_lineas_distribucion_pkey");

            entity.ToTable("tdc_cat_lineas_distribucion", "dwh_torrecontrol");

            entity.HasIndex(e => e.CodLinea, "cod_linea").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodBarrio)
                .HasColumnType("character varying")
                .HasColumnName("cod_barrio");
            entity.Property(e => e.CodLinea)
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodMunicipio)
                .HasColumnType("character varying")
                .HasColumnName("cod_municipio");
            entity.Property(e => e.CodProvincia)
                .HasColumnType("character varying")
                .HasColumnName("cod_provincia");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcTchEstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_tch_estado_pedidos_pkey");

            entity.ToTable("tdc_tch_estado_pedidos", "dwh_torrecontrol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoDevolucion)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.CodEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.CodEstadoPago)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.CodLinea)
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodPedido)
                .HasColumnType("character varying")
                .HasColumnName("cod_pedido");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");

            entity.HasOne(d => d.CodEstadoDevolucionNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasPrincipalKey(p => p.CodEstadoDevolucion)
                .HasForeignKey(d => d.CodEstadoDevolucion)
                .HasConstraintName("cod_dev");

            entity.HasOne(d => d.CodEstadoEnvioNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasPrincipalKey(p => p.CodEstadoEnvio)
                .HasForeignKey(d => d.CodEstadoEnvio)
                .HasConstraintName("cod_envio");

            entity.HasOne(d => d.CodEstadoPagoNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasPrincipalKey(p => p.CodEstadoPago)
                .HasForeignKey(d => d.CodEstadoPago)
                .HasConstraintName("cod_pago");

            entity.HasOne(d => d.CodLineaNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasPrincipalKey(p => p.CodLinea)
                .HasForeignKey(d => d.CodLinea)
                .HasConstraintName("cod_linea");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
