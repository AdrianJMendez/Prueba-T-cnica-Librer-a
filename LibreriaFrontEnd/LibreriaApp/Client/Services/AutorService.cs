using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using LibreriaApp.Shared.DTOs;

namespace LibreriaApp.Client.Services;

public class AutorService
{
    private readonly HttpClient _http;

    public AutorService(HttpClient http)
    {
        _http = http;
    }

   public async Task<List<AutorDto>> ObtenerTodosAsync()
    {
        var response = await _http.GetFromJsonAsync<List<AutorDto>>("api/Autores");
        return response ?? new List<AutorDto>();
    }

    public async Task<AutorDto?> ObtenerPorIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<AutorDto>($"api/autores/{id}");
    }

    public async Task RegistrarAsync(AutorCrearDto nuevoAutor)
    {
        var respuesta = await _http.PostAsJsonAsync("api/autores", nuevoAutor);
        respuesta.EnsureSuccessStatusCode();
    }

    public async Task EliminarAsync(int id)
    {
        var respuesta = await _http.DeleteAsync($"api/autores/{id}");
        respuesta.EnsureSuccessStatusCode();
    }
}