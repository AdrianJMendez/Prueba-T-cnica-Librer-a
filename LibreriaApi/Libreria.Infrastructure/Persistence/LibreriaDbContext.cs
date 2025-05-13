using Microsoft.EntityFrameworkCore;
using Libreria.Domain.Entities;

namespace Libreria.Infrastructure.Persistence;

public class LibreriaDbContext : DbContext
{
    public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; } = null;
    public DbSet<Libro> Libros { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("biblioteca");

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.ToTable("autores");

            entity.HasKey(a => a.Id);

            entity.Property(a => a.NombreCompleto)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(a => a.FechaNacimiento)
                .IsRequired();

            entity.Property(a => a.Ciudad)
                .HasMaxLength(100);

            entity.Property(a => a.CorreoElectronico)
                .HasMaxLength(150);

            entity.HasIndex(a => a.CorreoElectronico)
                .IsUnique();
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.ToTable("libros");

            entity.HasKey(l => l.Id);

            entity.Property(l => l.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(l => l.Anio)
                .IsRequired();

            entity.Property(l => l.Genero)
                .HasMaxLength(100);

            entity.Property(l => l.NumeroPaginas)
                .HasDefaultValue(0); 

           entity.HasOne(l => l.Autor)
            .WithMany(a => a.Libros)
            .HasForeignKey(l => l.AutorId)
            .OnDelete(DeleteBehavior.Cascade);


            entity.HasIndex(l => l.AutorId);
        });
    }



}
