using System.ComponentModel.DataAnnotations;
using Libreria.Application.DTOs;
using Libreria.Application.Services.Exceptions;
using Libreria.Application.Services.Interfaces;
using Libreria.Domain.Entities;
using Libreria.Domain.Repositories;

namespace Libreria.Application.Services;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _libroRepository;
    private readonly IAutorRepository _autorRepository;

    // Límite definido por las reglas de negocio (podría moverse a configuración)
    private const int MaximoLibrosPermitidos = 100;

    public LibroService(ILibroRepository libroRepository, IAutorRepository autorRepository)
    {
        _libroRepository = libroRepository;
        _autorRepository = autorRepository;
    }

    public async Task CrearLibroAsync(CrearLibroDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Titulo))
            throw new ValidationException("El título es obligatorio.");

        if (dto.Anio <= 0)
            throw new ValidacionException("El año debe ser mayor a 0.");

        if (dto.AutorId == Guid.Empty)
            throw new ValidacionException("El autor es obligatorio.");

        var autor = await _autorRepository.ObtenerPorIdAsync(dto.AutorId);
        if (autor == null)
            throw new NotFoundException($"No se encontró el autor con ID: {dto.AutorId}");

        var totalLibros = await _libroRepository.ContarAsync();
        if (totalLibros >= MaximoLibrosPermitidos)
            throw new LimiteDeLibrosException("Se ha alcanzado el límite máximo de libros permitidos.");

        var libro = new Libro(
            Guid.NewGuid(),
            dto.Titulo,
            dto.Anio,
            dto.Genero,
            dto.NumeroPaginas,
            dto.AutorId
        );

        await _libroRepository.AgregarAsync(libro);
        await _libroRepository.GuardarCambiosAsync();
    }

    public async Task<LibroDto> ObtenerLibroPorIdAsync(Guid id)
    {
        var libro = await _libroRepository.ObtenerPorIdAsync(id);
        if (libro == null)
            throw new NotFoundException("Libro no encontrado.");

        return new LibroDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            Anio = libro.Anio,
            Genero = libro.Genero,
            NumeroPaginas = libro.NumeroPaginas,
            AutorId = libro.AutorId
        };
    }

    public async Task<List<LibroDto>> ObtenerTodosLosLibrosAsync()
    {
        var libros = await _libroRepository.ObtenerTodosAsync();
        return libros.Select(libro => new LibroDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            Anio = libro.Anio,
            Genero = libro.Genero,
            NumeroPaginas = libro.NumeroPaginas,
            AutorId = libro.AutorId
        }).ToList();
    }

    public async Task EliminarLibroAsync(Guid id)
    {
        var libro = await _libroRepository.ObtenerPorIdAsync(id);
        if (libro == null)
            throw new NotFoundException("Libro no encontrado.");

        await _libroRepository.EliminarAsync(libro);
        await _libroRepository.GuardarCambiosAsync();
    }

    public async Task ActualizarLibroAsync(Guid id, CrearLibroDto dto)
    {
        var libro = await _libroRepository.ObtenerPorIdAsync(id);
        if (libro == null)
            throw new NotFoundException("Libro no encontrado.");

        if (string.IsNullOrWhiteSpace(dto.Titulo))
            throw new ValidacionException("El título es obligatorio.");

        if (dto.Anio <= 0)
            throw new ValidacionException("El año debe ser mayor a 0.");

        if (dto.AutorId == Guid.Empty)
            throw new ValidacionException("El autor es obligatorio.");

        var autor = await _autorRepository.ObtenerPorIdAsync(dto.AutorId);
        if (autor == null)
            throw new NotFoundException($"No se encontró el autor con ID: {dto.AutorId}");

        libro.ActualizarDatos(dto.Titulo, dto.Anio, dto.Genero, dto.NumeroPaginas, dto.AutorId);

        await _libroRepository.GuardarCambiosAsync();
    }
}
