using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;

namespace ConsulTech.Core.Services.Abstractions;

public interface IClientService
{
    Task<List<Client>> GetAllClientsAsync();
    Task<Client?> GetClientByIdAsync(Guid id);
    Task<Guid> CreateClientAsync(ClientDto clientDto);
    Task<Guid> UpdateClientAsync(ClientDto clientDto);
    Task<bool> DeleteClientAsync(Guid id);
}
