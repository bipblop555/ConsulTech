namespace ConsulTech.Web.Services;

public class NiveauClient
{
    private readonly HttpClient _http;

    public NiveauClient(HttpClient httpClient) => _http = httpClient;

    public record NiveauDto(Guid Id, string Titre);
    public record CreateNiveauDto(string Titre);
    public record UpdateNiveauDto(Guid Id, string Titre);

    public async Task<List<NiveauDto>> GetAll()
        => await _http.GetFromJsonAsync<List<NiveauDto>>("api/niveau") ?? new();

    public Task<NiveauDto?> Get(Guid id)
        => _http.GetFromJsonAsync<NiveauDto?>($"api/niveau/{id}");

    public async Task Create(CreateNiveauDto dto)
    {
        var res = await _http.PostAsJsonAsync("api/niveau", dto);
        res.EnsureSuccessStatusCode();
    }

    public async Task Update(UpdateNiveauDto dto)
    {
        var res = await _http.PutAsJsonAsync($"api/niveau/{dto.Id}", dto);
        res.EnsureSuccessStatusCode();
    }

    public async Task<bool> Delete(Guid id)
    {
        var res = await _http.DeleteAsync($"api/niveau/{id}");
        return res.IsSuccessStatusCode;
    }
}
