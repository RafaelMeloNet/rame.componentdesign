using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using rame.componentdesign.datastore.Models;

namespace rame.componentdesign.datastore.Data;

internal partial class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carga> Carga { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Despacho> Despacho { get; set; }

    public virtual DbSet<Motorista> Motorista { get; set; }

    public virtual DbSet<Transportadora> Transportadora { get; set; }

    public virtual DbSet<Veiculo> Veiculo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carga__3214EC0785B7108F");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC07E4E2311B");
        });

        modelBuilder.Entity<Despacho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Despacho__3214EC07BF86791E");

            entity.HasOne(d => d.Carga).WithMany(p => p.Despacho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Despacho__CargaI__00DF2177");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Despacho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Despacho__Client__7FEAFD3E");

            entity.HasOne(d => d.Transportadora).WithMany(p => p.Despacho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Despacho__Transp__02C769E9");

            entity.HasOne(d => d.Veiculo).WithMany(p => p.Despacho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Despacho__Veicul__01D345B0");
        });

        modelBuilder.Entity<Motorista>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Motorist__3214EC073F67237F");
        });

        modelBuilder.Entity<Transportadora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transpor__3214EC076C2C987A");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Veiculo__3214EC07C9C0FCF4");

            entity.HasOne(d => d.IdMotoristaNavigation).WithMany(p => p.Veiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Veiculo__IdMotor__7D0E9093");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
