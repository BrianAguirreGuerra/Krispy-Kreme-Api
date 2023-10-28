using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class KrispyKremeContext : DbContext
{
    public KrispyKremeContext()
    {
    }

    public KrispyKremeContext(DbContextOptions<KrispyKremeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Dona> Donas { get; set; }

    public virtual DbSet<VentaDona> VentaDonas { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= KrispyKreme; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D594664298DA500D");

            entity.ToTable("Cliente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C76BDE488FD");

            entity.ToTable("Direccion");

            entity.Property(e => e.Calle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Colonia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Municipio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumExt)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NumInt)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Direccion__IdCli__1273C1CD");
        });

        modelBuilder.Entity<Dona>(entity =>
        {
            entity.HasKey(e => e.IdDona).HasName("PK__Dona__0E45FCD02C84A0B0");

            entity.ToTable("Dona");

            entity.Property(e => e.Detalles).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VentaDona>(entity =>
        {
            entity.HasKey(e => e.IdVentaProducto).HasName("PK__VentaDon__E4CB5099F67E553A");

            entity.ToTable("VentaDona");

            entity.HasOne(d => d.IdDonaNavigation).WithMany(p => p.VentaDonas)
                .HasForeignKey(d => d.IdDona)
                .HasConstraintName("FK__VentaDona__IdDon__1B0907CE");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentaDonas)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__VentaDona__Canti__1A14E395");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__BC1240BD1A8CE196");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Venta__Fecha__173876EA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
