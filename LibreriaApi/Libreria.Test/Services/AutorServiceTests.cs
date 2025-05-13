using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Libreria.Application.DTOs;
using Libreria.Application.Services.Implementations;
using Libreria.Domain.Entities;
using Libreria.Domain.Repositories;
using Moq;
using Xunit;

public class AutorServiceTests
{
    private readonly Mock<IAutorRepository> _mockRepo;
    private readonly AutorService _service;

    public AutorServiceTests()
    {
        _mockRepo = new Mock<IAutorRepository>();
        _service = new AutorService(_mockRepo.Object);
    }

    [Fact]
    public async Task ObtenerTodosAsync_DeberiaRetornarListaDeAutores()
    {
        // Arrange
        var autores = new List<Autor>
        {
            new Autor { Id = Guid.NewGuid(), NombreCompleto = "Juan Pérez", FechaNacimiento = DateTime.Parse("1980-01-01"), Ciudad = "Tegucigalpa", CorreoElectronico = "juan@example.com" }
        };

        _mockRepo.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(autores);

        // Act
        var resultado = await _service.ObtenerTodosAsync();

        // Assert
        resultado.Should().HaveCount(1);
        resultado[0].NombreCompleto.Should().Be("Juan Pérez");
    }

    [Fact]
    public async Task ObtenerPorIdAsync_CuandoExiste_DeberiaRetornarAutor()
    {
        // Arrange
        var id = Guid.NewGuid();
        var autor = new Autor { Id = id, NombreCompleto = "Ana López", FechaNacimiento = DateTime.Parse("1975-05-05"), Ciudad = "San Pedro", CorreoElectronico = "ana@example.com" };
        _mockRepo.Setup(r => r.ObtenerPorIdAsync(id)).ReturnsAsync(autor);

        // Act
        var resultado = await _service.ObtenerPorIdAsync(id);

        // Assert
        resultado.Should().NotBeNull();
        resultado!.NombreCompleto.Should().Be("Ana López");
    }

    [Fact]
    public async Task ObtenerPorIdAsync_CuandoNoExiste_DeberiaRetornarNull()
    {
        // Arrange
        _mockRepo.Setup(r => r.ObtenerPorIdAsync(It.IsAny<Guid>())).ReturnsAsync((Autor?)null);

        // Act
        var resultado = await _service.ObtenerPorIdAsync(Guid.NewGuid());

        // Assert
        resultado.Should().BeNull();
    }

    [Fact]
    public async Task ObtenerPorCorreoAsync_CuandoExiste_DeberiaRetornarAutor()
    {
        // Arrange
        var correo = "pedro@example.com";
        var autor = new Autor { Id = Guid.NewGuid(), NombreCompleto = "Pedro Rivera", FechaNacimiento = DateTime.Now, Ciudad = "La Ceiba", CorreoElectronico = correo };
        _mockRepo.Setup(r => r.ObtenerPorCorreoAsync(correo)).ReturnsAsync(autor);

        // Act
        var resultado = await _service.ObtenerPorCorreoAsync(correo);

        // Assert
        resultado.Should().NotBeNull();
        resultado!.CorreoElectronico.Should().Be(correo);
    }

    [Fact]
    public async Task CrearAutorAsync_DeberiaAgregarYRetornarId()
    {
        // Arrange
        var dto = new CrearAutorDto
        {
            NombreCompleto = "Carlos Meza",
            FechaNacimiento = DateTime.UtcNow.AddYears(-30),
            Ciudad = "Comayagua",
            CorreoElectronico = "carlos@example.com"
        };

        Guid nuevoId = Guid.NewGuid();
        _mockRepo.Setup(r => r.AgregarAsync(It.IsAny<Autor>()))
                 .Callback<Autor>(a => a.Id = nuevoId)
                 .Returns(Task.CompletedTask);
        _mockRepo.Setup(r => r.GuardarCambiosAsync()).Returns(Task.CompletedTask);

        // Act
        var resultadoId = await _service.CrearAutorAsync(dto);

        // Assert
        resultadoId.Should().Be(nuevoId);
        _mockRepo.Verify(r => r.AgregarAsync(It.IsAny<Autor>()), Times.Once);
        _mockRepo.Verify(r => r.GuardarCambiosAsync(), Times.Once);
    }
}
