namespace ConsulTech.Web.Services
{
    public class ClientsClient
    {
        private readonly HttpClient _http;
        public ClientsClient(HttpClient http) => _http = http;


        // DTO => API
        public record ClientDto(Guid Id, string Nom, string Secteur, string Adresse, string Contact);
        public record CreateClientDto(string Nom, string Secteur, string Adresse, string Contact);
        public record UpdateClientDto(Guid Id, string Nom, string Secteur, string Adresse, string Contact);

        public async Task<List<ClientDto>> GetAll()
            => await _http.GetFromJsonAsync<List<ClientDto>>("api/client") ?? new();

        public Task<ClientDto?> Get(Guid id)
            => _http.GetFromJsonAsync<ClientDto?>($"api/client/{id}");
        public async Task Create(CreateClientDto dto)
        {
            var res = await _http.PostAsJsonAsync("api/client", dto);
            res.EnsureSuccessStatusCode();
        }

        public async Task Update(UpdateClientDto dto)
        {
            var res = await _http.PutAsJsonAsync($"api/client/{dto.Id}", dto);
            res.EnsureSuccessStatusCode();
        }

        public async Task<bool> Delete(Guid id)
        {
            var res = await _http.DeleteAsync($"api/client/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
