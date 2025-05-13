using Microsoft.AspNetCore.Mvc;
using Libreria.Application.DTOs;
using Libreria.Application.Services.Interfaces;

namespace Libreria.API.Controllers
{
/// <summary>
/// Controlador para gestionar autores.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
private readonly IAutorService _autorService;

        /// <summary>
    /// Constructor del controlador de autores.
    /// </summary>
    /// <param name="autorService">Servicio de autores inyectado.</param>
    public AutoresController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    /// <summary>
    /// Crea un nuevo autor.
    /// </summary>
    /// <param name="dto">Datos del autor a crear.</param>
    /// <returns>El autor creado con su ubicación.</returns>
    [HttpPost]
    public async Task<IActionResult> CrearAutor([FromBody] CrearAutorDto dto)
    {
        var id = await _autorService.CrearAutorAsync(dto);
        var autorCreado = await _autorService.ObtenerPorIdAsync(id);
        return CreatedAtAction(nameof(ObtenerAutorPorId), new { id = id }, autorCreado);
    }

    /// <summary>
    /// Obtiene un autor por su ID.
    /// </summary>
    /// <param name="id">Identificador del autor.</param>
    /// <returns>El autor si existe, o NotFound.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerAutorPorId(Guid id)
    {
        var autor = await _autorService.ObtenerPorIdAsync(id);
        return autor != null ? Ok(autor) : NotFound();
    }

    /// <summary>
    /// Obtiene un autor por su correo electrónico.
    /// </summary>
    /// <param name="correo">Correo del autor.</param>
    /// <returns>El autor si existe, o NotFound.</returns>
    [HttpGet("por-correo")]
    public async Task<IActionResult> ObtenerAutorPorCorreo([FromQuery] string correo)
    {
        var autor = await _autorService.ObtenerPorCorreoAsync(correo);
        return autor != null ? Ok(autor) : NotFound();
    }

    /// <summary>
    /// Lista todos los autores registrados.
    /// </summary>
    /// <returns>Una lista de autores.</returns>
    [HttpGet]
    public async Task<IActionResult> ListarAutores()
    {
        var autores = await _autorService.ObtenerTodosAsync();
        return Ok(autores);
    }
}

}