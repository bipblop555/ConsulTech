using ConsulTech.Web.Models.Dtos.Competence;

namespace ConsulTech.Web.Services;

public class CompetencesClient
{
    private readonly HttpClient _http;
    public CompetencesClient(HttpClient http) => _http = http;

    public async Task<List<CompetenceDto>> GetAll()
        => await _http.GetFromJsonAsync<List<CompetenceDto>>("api/competence") ?? new();
    
    public async Task<CompetenceDto?> Get(Guid id)
        => await _http.GetFromJsonAsync<CompetenceDto?>($"api/competence/{id}");

    public async Task Create(CreateCompetenceDto dto)
    {
        var res = await _http.PostAsJsonAsync("api/competence", dto);
        res.EnsureSuccessStatusCode();
    }

    public async Task Update(CreateCompetenceDto dto, Guid id)
    {
        var res = await _http.PutAsJsonAsync($"api/competence/{id}", dto);
        res.EnsureSuccessStatusCode();
    }

    public async Task<bool> Delete(Guid id)
    {
        var res = await _http.DeleteAsync($"api/competence/{id}");
        return res.IsSuccessStatusCode;
    }


}
