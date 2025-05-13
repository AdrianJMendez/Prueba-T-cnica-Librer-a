namespace Libreria.Domain.UnitOfWork;
using Libreria.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
IAutorRepository Autores { get; }
ILibroRepository Libros { get; }
Task<int> GuardarCambiosAsync();
}