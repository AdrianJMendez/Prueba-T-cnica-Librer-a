namespace Libreria.Application.DTOs;

public class AutorDto
{
    public Guid Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string? Ciudad { get; set; }
    public string? CorreoElectronico { get; set; }
}
