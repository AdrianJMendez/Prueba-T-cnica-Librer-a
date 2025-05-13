using Libreria.Application.DTOs;
using Libreria.Domain.Entities;

namespace Libreria.Application.Services.Interfaces;

public interface IAutorService
{
    Task<List<AutorDto>> ObtenerTodosAsync();
    Task<AutorDto?> ObtenerPorIdAsync(Guid id);
    Task<AutorDto?> ObtenerPorCorreoAsync(string correo);
    Task<Guid> CrearAutorAsync(CrearAutorDto dto);
}
