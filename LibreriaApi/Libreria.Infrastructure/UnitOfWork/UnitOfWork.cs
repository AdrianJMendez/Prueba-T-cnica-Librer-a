namespace Libreria.Infrastructure.UnitOfWork;
using Libreria.Domain.Repositories;
using Libreria.Domain.UnitOfWork;
using Libreria.Infrastructure.Persistence;
using Libreria.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
private readonly LibreriaDbContext _context;

public UnitOfWork(LibreriaDbContext context)
{
    _context = context;
    Autores = new AutorRepository(_context);
    Libros = new LibroRepository(_context);
}

public IAutorRepository Autores { get; }
public ILibroRepository Libros { get; }

public async Task<int> GuardarCambiosAsync()
{
    return await _context.SaveChangesAsync();
}

public void Dispose()
{
    _context.Dispose();
}

}