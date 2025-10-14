using ConsulTech.Web.Models.Dtos.Client;

namespace ConsulTech.Web.Services
{
    public class ClientsClient
    {
        private readonly HttpClient _http;
        public ClientsClient(HttpClient http) => _http = http;

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
