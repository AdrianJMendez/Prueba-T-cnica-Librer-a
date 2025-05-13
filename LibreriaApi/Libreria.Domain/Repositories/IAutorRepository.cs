namespace Libreria.Domain.Repositories;
using Libreria.Domain.Entities;


public interface IAutorRepository
{
    Task<Autor?> ObtenerPorIdAsync(Guid id);
    Task<Autor?> ObtenerPorCorreoAsync(string correo);
    Task<List<Autor>> ObtenerTodosAsync();
    Task AgregarAsync(Autor autor);
    Task GuardarCambiosAsync();
}
