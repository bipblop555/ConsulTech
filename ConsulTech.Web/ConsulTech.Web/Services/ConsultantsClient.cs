using System.Net;

namespace ConsulTech.Web.Services
{
    public class ConsultantsClient
    {
        private readonly HttpClient _http;
        public ConsultantsClient(HttpClient http) => _http = http;

        private const string BasePath = "api/consultant";
        public record SkillDto(Guid Id, string Titre);
        public record ConsultantDto(Guid Id, string Nom, string Prenom, string Email,
            DateTime DateEmbauche, bool EstDisponible, List<SkillDto> Competences);

        public record CreateConsultantDto(string Nom, string Prenom, string Email,
            DateTime DateEmbauche, bool EstDisponible);

        public record UpdateConsultantDto(Guid Id, string Nom, string Prenom, string Email,
            DateTime DateEmbauche, bool EstDisponible);

        public async Task<List<ConsultantDto>> GetAll()
        {
            var res = await _http.GetAsync(BasePath);
            if (res.StatusCode == HttpStatusCode.NotFound) return new();
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<List<ConsultantDto>>() ?? new();
        }

        public async Task<ConsultantDto?> Get(Guid id)
        {
            var res = await _http.GetAsync($"api/consultant/{id}");
            if (res.StatusCode == HttpStatusCode.NotFound) return null;
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<ConsultantDto?>();
        }

        public async Task<bool> Create(CreateConsultantDto dto)
        {
            var res = await _http.PostAsJsonAsync("api/consultant", dto);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Update(UpdateConsultantDto dto)
        {
            var res = await _http.PutAsJsonAsync($"api/consultant/{dto.Id}", dto);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(Guid id)
        {
            var res = await _http.DeleteAsync($"api/consultant/{id}");
            return res.IsSuccessStatusCode;
        }

    }
}
