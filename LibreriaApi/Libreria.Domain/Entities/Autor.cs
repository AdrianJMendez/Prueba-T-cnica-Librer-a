namespace Libreria.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("autores", Schema = "biblioteca")]
public class Autor
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("nombre_completo")]
    public string NombreCompleto { get; set; }

    [Column("fecha_nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Column("ciudad")]
    public string Ciudad { get; set; }

    [Column("correo_electronico")]
    public string CorreoElectronico { get; set; }

    // Opcional: relación con Libros
    public ICollection<Libro>? Libros { get; set; }
}
