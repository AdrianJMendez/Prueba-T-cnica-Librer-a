using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Libreria.Application.Services;
using Libreria.Domain.Repositories;
using Libreria.Application.DTOs;
using Libreria.Domain.Entities;
using Libreria.Application.Services.Exceptions;
using System.ComponentModel.DataAnnotations;
using Libreria.Domain.Entities;

public class LibroServiceTests
{
    private readonly Mock<ILibroRepository> _libroRepoMock = new();
    private readonly Mock<IAutorRepository> _autorRepoMock = new();
    private readonly LibroService _libroService;

    public LibroServiceTests()
    {
        _libroService = new LibroService(_libroRepoMock.Object, _autorRepoMock.Object);
    }

    [Fact]
    public async Task CrearLibroAsync_DeberiaCrearLibro_ConDatosValidos()
    {
        // Arrange
        var dto = new CrearLibroDto
        {
            Titulo = "El Principito",
            Anio = 1943,
            Genero = "Fábula",
            NumeroPaginas = 100,
            AutorId = Guid.NewGuid()
        };

       _autorRepoMock.Setup(r => r.ObtenerPorIdAsync(dto.AutorId))
        .ReturnsAsync(new Autor
        {
            Id = dto.AutorId,
            NombreCompleto = "Antoine de Saint-Exupéry",
            FechaNacimiento = new DateTime(1900, 6, 29),
            Ciudad = "Lyon",
            CorreoElectronico = "antoine@example.com"
        });


        _libroRepoMock.Setup(r => r.ContarAsync()).ReturnsAsync(50);

        // Act
        await _libroService.CrearLibroAsync(dto);

        // Assert
        _libroRepoMock.Verify(r => r.AgregarAsync(It.IsAny<Libro>()), Times.Once);
        _libroRepoMock.Verify(r => r.GuardarCambiosAsync(), Times.Once);
    }

    [Fact]
    public async Task CrearLibroAsync_DeberiaLanzarExcepcion_SiTituloEsVacio()
    {
        var dto = new CrearLibroDto
        {
            Titulo = "",
            Anio = 2000,
            Genero = "Drama",
            NumeroPaginas = 120,
            AutorId = Guid.NewGuid()
        };

        await Assert.ThrowsAsync<ValidationException>(() =>
            _libroService.CrearLibroAsync(dto));
    }

    [Fact]
    public async Task CrearLibroAsync_DeberiaLanzarExcepcion_SiAnioEsInvalido()
    {
        var dto = new CrearLibroDto
        {
            Titulo = "Título válido",
            Anio = 0,
            Genero = "Acción",
            NumeroPaginas = 300,
            AutorId = Guid.NewGuid()
        };

        await Assert.ThrowsAsync<ValidacionException>(() =>
            _libroService.CrearLibroAsync(dto));
    }

    [Fact]
    public async Task CrearLibroAsync_DeberiaLanzarExcepcion_SiAutorNoExiste()
    {
        var autorId = Guid.NewGuid();
        var dto = new CrearLibroDto
        {
            Titulo = "Otro libro",
            Anio = 2023,
            Genero = "Ciencia ficción",
            NumeroPaginas = 150,
            AutorId = autorId
        };

        _autorRepoMock.Setup(r => r.ObtenerPorIdAsync(autorId)).ReturnsAsync((Autor?)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _libroService.CrearLibroAsync(dto));
    }

    [Fact]
    public async Task CrearLibroAsync_DeberiaLanzarExcepcion_SiSeAlcanzaElLimiteDeLibros()
    {
        var autorId = Guid.NewGuid();
        var dto = new CrearLibroDto
        {
            Titulo = "Límite",
            Anio = 2022,
            Genero = "Historia",
            NumeroPaginas = 220,
            AutorId = autorId
        };

        _autorRepoMock.Setup(r => r.ObtenerPorIdAsync(dto.AutorId))
        .ReturnsAsync(new Autor
        {
            Id = dto.AutorId,
            NombreCompleto = "Antoine de Saint-Exupéry",
            FechaNacimiento = new DateTime(1900, 6, 29),
            Ciudad = "Lyon",
            CorreoElectronico = "antoine@example.com"
        });


        _libroRepoMock.Setup(r => r.ContarAsync()).ReturnsAsync(100); // Límite alcanzado

        await Assert.ThrowsAsync<LimiteDeLibrosException>(() =>
            _libroService.CrearLibroAsync(dto));
    }
}
