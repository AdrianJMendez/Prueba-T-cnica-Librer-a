
using System.Net.Http.Json;
using LibreriaApp.Shared.DTOs;

namespace LibreriaApp.Client.Services;

public class LibroService
{
    private readonly HttpClient _http;
    private const string Endpoint = "api/libros";

    public LibroService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<LibroDto>> ObtenerLibrosAsync()
    {
        var libros = await _http.GetFromJsonAsync<List<LibroDto>>(Endpoint);
        return libros ?? new List<LibroDto>();
    }

    public async Task<LibroDto?> ObtenerLibroPorIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<LibroDto>($"{Endpoint}/{id}");
    }

    public async Task<HttpResponseMessage> CrearLibroAsync(LibroCrearDto nuevoLibro)
    {
        return await _http.PostAsJsonAsync(Endpoint, nuevoLibro);
    }

    public async Task<HttpResponseMessage> EliminarLibroAsync(int id)
    {
        return await _http.DeleteAsync($"{Endpoint}/{id}");
    }

    public async Task<HttpResponseMessage> ActualizarLibroAsync(int id, LibroCrearDto libroActualizado)
    {
        return await _http.PutAsJsonAsync($"{Endpoint}/{id}", libroActualizado);
    }
}