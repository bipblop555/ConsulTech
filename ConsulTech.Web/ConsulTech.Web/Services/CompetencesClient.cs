using ConsulTech.Web.Models.Dtos.Competence;

namespace ConsulTech.Web.Services;

public class CompetencesClient
{
    private readonly HttpClient _http;
    public CompetencesClient(HttpClient http) => _http = http;

    public async Task<List<CompetenceDto>> GetAll()
        => await _http.GetFromJsonAsync<List<CompetenceDto>>("api/competences") ?? new();
    
    public async Task<CompetenceDto?> Get(Guid id)
        => await _http.GetFromJsonAsync<CompetenceDto?>($"api/competences/{id}");

    public async Task Create(CreateCompetenceDto dto)
    {

    }
}
