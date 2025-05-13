namespace Libreria.Application.DTOs;

public class LibroDto
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int Anio { get; set; }
    public string? Genero { get; set; }
    public int? NumeroPaginas { get; set; }
    public Guid AutorId { get; set; }
}
