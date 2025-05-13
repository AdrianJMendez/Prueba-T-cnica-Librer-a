namespace Libreria.Application.DTOs;

using System.ComponentModel.DataAnnotations;

public class CrearLibroDto
{
[Required(ErrorMessage = "El título es obligatorio.")]
[StringLength(200, MinimumLength = 2, ErrorMessage = "El título debe tener entre 2 y 200 caracteres.")]
public string Titulo { get; set; } = string.Empty;
    [Required(ErrorMessage = "El año es obligatorio.")]
    [Range(1, 3000, ErrorMessage = "El año debe ser un número positivo válido.")]
    public int Anio { get; set; }

    [StringLength(50, ErrorMessage = "El género no puede tener más de 50 caracteres.")]
    public string? Genero { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor a 0.")]
    public int NumeroPaginas { get; set; }

    [Required(ErrorMessage = "El ID del autor es obligatorio.")]
    public Guid AutorId { get; set; }
}