namespace LibreriaApp.Shared.DTOs;

public class AutorCrearDto
{
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime? FechaNacimiento { get; set; }


    public string? Ciudad { get; set; }
    public string? CorreoElectronico { get; set; }
}