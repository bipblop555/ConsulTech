using ConsulTech.Web.Models.Dtos.Categorie;

namespace ConsulTech.Web.Services;

public class CategoriesClient
{
    private readonly HttpClient _http;

    public CategoriesClient(HttpClient httpClient) => _http = httpClient;

    public async Task<List<CategorieDto>> GetAll()
        => await _http.GetFromJsonAsync<List<CategorieDto>>("api/categorie") ?? new();

    public async Task<CategorieDto?> Get(Guid id)
        => await _http.GetFromJsonAsync<CategorieDto?>($"api/categorie/{id}");

    public async Task Create(CreateCategorieDto dto)
    {
        var res = await _http.PostAsJsonAsync("api/categorie", dto);
        res.EnsureSuccessStatusCode();
    }

    public async Task Update(UpdateClientDto dto)
    {
        var res = await _http.PutAsJsonAsync($"api/categorie/{dto.Id}", dto);
        res.EnsureSuccessStatusCode();
    }

    public async Task<bool> Delete(Guid id)
    {
        var res = await _http.DeleteAsync($"api/categorie/{id}");
        return res.IsSuccessStatusCode;
    }
}
