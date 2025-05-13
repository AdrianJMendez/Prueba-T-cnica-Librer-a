using Libreria.Application.DTOs;

namespace Libreria.Application.Services.Interfaces;
public interface ILibroService
{
    Task CrearLibroAsync(CrearLibroDto dto);
    Task<LibroDto> ObtenerLibroPorIdAsync(Guid id);
    Task<List<LibroDto>> ObtenerTodosLosLibrosAsync();
    Task ActualizarLibroAsync(Guid id, CrearLibroDto dto);
    Task EliminarLibroAsync(Guid id);
}


