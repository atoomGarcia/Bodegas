using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Bodegas.SPs;

#nullable disable

namespace Bodegas.Models
{
    public partial class UbiBodegasContext : DbContext
    {
        public UbiBodegasContext()
        {
        }

        public UbiBodegasContext(DbContextOptions<UbiBodegasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

        public virtual DbSet<ExtraeArticulos> ExtraeArticulos { get; set; }
        public virtual DbSet<ExtraeUbicaciones> ExtraeUbicaciones { get; set; }

        public virtual DbSet<ExtraeBodegas> ExtraeBodegas { get; set; }

        public virtual DbSet<InsertarAsignaciones> InsertarAsignaciones { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=UbiBodegas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.ClaveArticulo)
                    .HasName("PK__Articulo__47F65A39AAA48CDD");

                entity.Property(e => e.CodigoBarras)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCorta)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraeArticulos>(entity =>
            {
                entity.HasKey(e => e.Link)
                    .HasName("PK__Articulo__47F65A39AAA48CDD");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraeUbicaciones>(entity =>
            {
                entity.HasKey(e => e.ClaveArticulo)
                    .HasName("PK__Bodegas__B1D8FA60EF8AFF3E");

                entity.Property(e => e.NombreBodega)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InsertarAsignaciones>(entity =>
            {
                entity.HasKey(e => e.ClaveArticulo)
                    .HasName("PK__Bodegas__B1D8FA60EF8AFF3E");

                entity.Property(e => e.ClaveBodega)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraeBodegas>(entity =>
            {
                entity.HasKey(e => e.Link)
                    .HasName("PK__Bodegas__B1D8FA60EF8AFF3E");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.ClaveBodega)
                    .HasName("PK__Bodegas__B1D8FA60EF8AFF3E");

                entity.Property(e => e.NombreBodega)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ubicacione>(entity =>
            {
                entity.HasKey(e => new { e.ClaveBodega, e.ClaveUbicacion, e.ClaveArticulo })
                    .HasName("PK__Ubicacio__2651AB8CF8C3490B");

                entity.Property(e => e.NombreUbicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Piezas).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ClaveArticuloNavigation)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.ClaveArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ubicacion__Clave__619B8048");

                entity.HasOne(d => d.ClaveBodegaNavigation)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.ClaveBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ubicacion__Clave__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
