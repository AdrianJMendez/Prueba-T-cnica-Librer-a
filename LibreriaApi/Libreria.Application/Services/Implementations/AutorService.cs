using Libreria.Application.DTOs;
using Libreria.Application.Services.Interfaces;
using Libreria.Domain.Entities;
using Libreria.Domain.Repositories;

namespace Libreria.Application.Services.Implementations;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public async Task<List<AutorDto>> ObtenerTodosAsync()
    {
        var autores = await _autorRepository.ObtenerTodosAsync();
        return autores.Select(a => new AutorDto
        {
            Id = a.Id,
            NombreCompleto = a.NombreCompleto,
            FechaNacimiento = a.FechaNacimiento,
            Ciudad = a.Ciudad,
            CorreoElectronico = a.CorreoElectronico
        }).ToList();
    }

    public async Task<AutorDto?> ObtenerPorIdAsync(Guid id)
    {
        var autor = await _autorRepository.ObtenerPorIdAsync(id);
        if (autor == null) return null;

        return new AutorDto
        {
            Id = autor.Id,
            NombreCompleto = autor.NombreCompleto,
            FechaNacimiento = autor.FechaNacimiento,
            Ciudad = autor.Ciudad,
            CorreoElectronico = autor.CorreoElectronico
        };
    }

    public async Task<AutorDto?> ObtenerPorCorreoAsync(string correo)
    {
        var autor = await _autorRepository.ObtenerPorCorreoAsync(correo);
        if (autor == null) return null;

        return new AutorDto
        {
            Id = autor.Id,
            NombreCompleto = autor.NombreCompleto,
            FechaNacimiento = autor.FechaNacimiento,
            Ciudad = autor.Ciudad,
            CorreoElectronico = autor.CorreoElectronico
        };
    }

    public async Task<Guid> CrearAutorAsync(CrearAutorDto dto)
    {
        var autor = new Autor
        {
            Id = Guid.NewGuid(),
            NombreCompleto = dto.NombreCompleto,
            FechaNacimiento = DateTime.SpecifyKind(dto.FechaNacimiento, DateTimeKind.Utc),
            Ciudad = dto.Ciudad,
            CorreoElectronico = dto.CorreoElectronico
        };

        await _autorRepository.AgregarAsync(autor);
        await _autorRepository.GuardarCambiosAsync();

        return autor.Id;
    }
}
