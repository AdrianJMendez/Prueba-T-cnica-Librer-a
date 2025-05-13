namespace Libreria.Domain.Repositories;
using Libreria.Domain.Entities;

public interface ILibroRepository
{
    Task<Libro?> ObtenerPorIdAsync(Guid id);
    Task<List<Libro>> ObtenerPorAutorAsync(Guid autorId);
    Task<int> ContarLibrosPorAutorAsync(Guid autorId);
    Task AgregarAsync(Libro libro);
    Task GuardarCambiosAsync();
    Task<int> ContarAsync();
    Task<List<Libro>> ObtenerTodosAsync();
    Task EliminarAsync(Libro libro);


}
