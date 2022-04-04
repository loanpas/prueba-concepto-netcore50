using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace apiPruebaConceptoNet50.Models
{
    public partial class DbPruebaConcepto50Context : DbContext
    {
        public DbPruebaConcepto50Context()
        {
        }

        public DbPruebaConcepto50Context(DbContextOptions<DbPruebaConcepto50Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Espacio> Espacios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=DbPruebaConcepto5.0;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Espacio>(entity =>
            {
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("longitud");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
