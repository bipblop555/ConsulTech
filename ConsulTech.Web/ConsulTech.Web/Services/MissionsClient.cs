namespace ConsulTech.Web.Services
{
    public class MissionsClient
    {
        private readonly HttpClient _http;
        public MissionsClient(HttpClient http) => _http = http;

        // DTO => API
        public record MissionDto(
            Guid Id, string Titre, string Description,
            DateTime Debut, DateTime Fin, float Budget,
            Guid ClientId, string ClientNom,
            List<Guid>? ConsultantIds, List<string>? Consultants
        );

        public record CreateMissionDto(
            string Titre, string Description,
            DateTime Debut, DateTime Fin, float Budget, Guid ClientId,
            List<Guid> ConsultantIds
        );

        public record UpdateMissionDto(
            Guid Id, string Titre, string Description,
            DateTime Debut, DateTime Fin, float Budget, Guid ClientId,
            List<Guid> ConsultantIds
        );

        public async Task<List<MissionDto>> GetAll()
            => await _http.GetFromJsonAsync<List<MissionDto>>("api/mission") ?? new();

        public async Task<MissionDto?> Get(Guid id)
            => await _http.GetFromJsonAsync<MissionDto?>($"api/mission/{id}");

        public async Task Create(CreateMissionDto dto)
        {
            var res = await _http.PostAsJsonAsync("api/mission", dto);
            res.EnsureSuccessStatusCode();
        }

        public async Task<bool> Update(UpdateMissionDto dto)
        {
            var res = await _http.PutAsJsonAsync($"api/mission/{dto.Id}", dto);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(Guid id)
        {
            var res = await _http.DeleteAsync($"api/mission/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
