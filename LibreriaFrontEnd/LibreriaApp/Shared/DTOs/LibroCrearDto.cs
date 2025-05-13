namespace LibreriaApp.Shared.DTOs;

public class LibroCrearDto
{
    public string Titulo { get; set; } = string.Empty;
    public int Anio { get; set; }
    public string? Genero { get; set; }
    public int? NumeroPaginas { get; set; }
    public Guid AutorId { get; set; }
}