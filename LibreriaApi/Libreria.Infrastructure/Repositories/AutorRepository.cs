using Libreria.Domain.Entities;
using Libreria.Domain.Repositories;
using Libreria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infrastructure.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibreriaDbContext _dbContext;

        public AutorRepository(LibreriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Autor?> ObtenerPorIdAsync(Guid id)
        {
            return await _dbContext.Autores
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Autor?> ObtenerPorCorreoAsync(string correo)
        {
            return await _dbContext.Autores
                .FirstOrDefaultAsync(a => a.CorreoElectronico == correo);
        }

        public async Task<List<Autor>> ObtenerTodosAsync()
        {
            return await _dbContext.Autores.ToListAsync();
        }

        public async Task AgregarAsync(Autor autor)
        {
            await _dbContext.Autores.AddAsync(autor);
        }

        public async Task GuardarCambiosAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
