using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaTaller.Models
{
    public partial class TallerContext : DbContext
    {
        public TallerContext()
        {
        }

        public TallerContext(DbContextOptions<TallerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleTrabajo> DetalleTrabajos { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Trabajo> Trabajos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FADPRP3;Initial Catalog=Taller;User ID=sa;Password=minerd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdClientes);

                entity.Property(e => e.IdClientes).HasColumnName("Id_Clientes");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleTrabajo>(entity =>
            {
                entity.HasKey(e => e.IdDetalleTrabajo);

                entity.ToTable("Detalle_Trabajo");

                entity.Property(e => e.IdDetalleTrabajo).HasColumnName("Id_Detalle_Trabajo");

                entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");
                entity.Property(e => e.Id_Trabajo).HasColumnName("Id_Trabajo");
                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.DetalleTrabajos)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_Trabajo_Servicios");
          
            entity.HasOne(d => d.IdTrabajoNavigation)
                  .WithMany(p => p.Detalles)
                  .HasForeignKey(d => d.Id_Trabajo)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_Detalle_Trabajo_Trabajo");
        });

            

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Trabajo>(entity =>
            {
                entity.HasKey(e => e.IdTrabajo);

                entity.ToTable("Trabajo");

                entity.Property(e => e.IdTrabajo).HasColumnName("Id_Trabajo");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdVehiculo).HasColumnName("Id_Vehiculo");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Trabajos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trabajo_Clientes");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Trabajos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trabajo_Usuarios");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Trabajos)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK_Trabajo_Vehiculos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios);

                entity.Property(e => e.IdUsuarios).HasColumnName("Id_Usuarios");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo);

                entity.Property(e => e.IdVehiculo).HasColumnName("Id_Vehiculo");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Vehiculos_Clientes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
