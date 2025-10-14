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
            => await _http.GetFromJsonAsync<List<ClientDto>>("api/clients") ?? new();

        public Task<ClientDto?> Get(Guid id)
            => _http.GetFromJsonAsync<ClientDto?>($"api/clients/{id}");
        public async Task<ClientDto?> Create(CreateClientDto dto)
        {
            var res = await _http.PostAsJsonAsync("api/clients", dto);
            if (!res.IsSuccessStatusCode) return null;
            return await res.Content.ReadFromJsonAsync<ClientDto>();
        }

        public async Task<bool> Update(UpdateClientDto dto)
        {
            var res = await _http.PutAsJsonAsync($"api/clients/{dto.Id}", dto);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(Guid id)
        {
            var res = await _http.DeleteAsync($"api/clients/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
