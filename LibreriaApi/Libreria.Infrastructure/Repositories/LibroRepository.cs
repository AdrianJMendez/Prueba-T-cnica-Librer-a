using Libreria.Domain.Entities;
using Libreria.Domain.Repositories;
using Libreria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infrastructure.Repositories;

public class LibroRepository : ILibroRepository
{
private readonly LibreriaDbContext _context;

public LibroRepository(LibreriaDbContext context)
{
    _context = context;
}

public async Task<Libro?> ObtenerPorIdAsync(Guid id)
{
    return await _context.Libros.FindAsync(id);
}

public async Task<List<Libro>> ObtenerPorAutorAsync(Guid autorId)
{
    return await _context.Libros
        .Where(l => l.AutorId == autorId)
        .ToListAsync();
}

public async Task<int> ContarLibrosPorAutorAsync(Guid autorId)
{
    return await _context.Libros.CountAsync(l => l.AutorId == autorId);
}

public async Task<int> ContarAsync()
{
    return await _context.Libros.CountAsync();
}

public async Task<List<Libro>> ObtenerTodosAsync()
{
    return await _context.Libros.ToListAsync();
}

public async Task AgregarAsync(Libro libro)
{
    await _context.Libros.AddAsync(libro);
}

public async Task EliminarAsync(Libro libro)
{
    _context.Libros.Remove(libro);
}

public async Task GuardarCambiosAsync()
{
    await _context.SaveChangesAsync();
}
}