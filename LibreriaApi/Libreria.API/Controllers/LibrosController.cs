using Libreria.Application.DTOs;
using Libreria.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.API.Controllers
{
/// <summary>
/// Controlador para gestionar libros.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
private readonly ILibroService _libroService;

        /// <summary>
    /// Constructor del controlador de libros.
    /// </summary>
    /// <param name="libroService">Servicio de libros inyectado.</param>
    public LibrosController(ILibroService libroService)
    {
        _libroService = libroService;
    }

    /// <summary>
    /// Crea un nuevo libro.
    /// </summary>
    /// <param name="dto">Datos del libro a crear.</param>
    /// <returns>El libro creado con su ubicación.</returns>
    [HttpPost]
    public async Task<IActionResult> CrearLibro([FromBody] CrearLibroDto dto)
{
    try
    {
        // Llamamos al servicio para crear el libro, sin esperar un retorno
        await _libroService.CrearLibroAsync(dto);

        // Devolvemos una respuesta de éxito sin necesidad de retornar el libro
        return Ok("Libro creado con éxito.");
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}



    /// <summary>
    /// Obtiene un libro por su ID.
    /// </summary>
    /// <param name="id">Identificador del libro.</param>
    /// <returns>El libro si existe, o NotFound.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerLibroPorId(Guid id)
    {
        try
        {
            var libro = await _libroService.ObtenerLibroPorIdAsync(id);
            return Ok(libro);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Obtiene todos los libros registrados.
    /// </summary>
    /// <returns>Una lista de libros.</returns>
    [HttpGet]
    public async Task<IActionResult> ObtenerTodosLosLibros()
    {
        try
        {
            var libros = await _libroService.ObtenerTodosLosLibrosAsync();
            return Ok(libros);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Actualiza los datos de un libro existente.
    /// </summary>
    /// <param name="id">ID del libro a actualizar.</param>
    /// <param name="dto">Nuevos datos del libro.</param>
    /// <returns>204 NoContent si fue exitoso.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarLibro(Guid id, [FromBody] CrearLibroDto dto)
    {
        try
        {
            await _libroService.ActualizarLibroAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Elimina un libro por su ID.
    /// </summary>
    /// <param name="id">Identificador del libro.</param>
    /// <returns>204 NoContent si fue eliminado correctamente.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarLibro(Guid id)
    {
        try
        {
            await _libroService.EliminarLibroAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}


}