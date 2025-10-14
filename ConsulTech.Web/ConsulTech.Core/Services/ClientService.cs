using ConsulTech.Core.Context;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConsulTech.Core.Services;

internal sealed class ClientService : IClientService
{
    private readonly ConsultTechContext _dbContext;
    public ClientService(ConsultTechContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<Guid> CreateClientAsync(ClientDto clientDto)
    {
        if (this._dbContext.Clients.Any(c => c.Nom == clientDto.Nom))
            return Guid.Empty;

        var clientToAdd = new Client
        {
            Nom = clientDto.Nom,
            Secteur = clientDto.Secteur,
            Adresse = clientDto.Adresse,
            Contact = clientDto.Contact
        };

        await this._dbContext.Clients.AddAsync(clientToAdd);
        await this._dbContext.SaveChangesAsync();
        return clientToAdd.Id;
    }

    public async Task<bool> DeleteClientAsync(Guid id)
    {
        var foundClient = await this._dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
        if (foundClient is null)
            return false;

        this._dbContext.Clients.Remove(foundClient);
        await this._dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Client>> GetAllClientsAsync()
    {
        return await this._dbContext.Clients.ToListAsync();
    }

    public async Task<Client?> GetClientByIdAsync(Guid id)
    {
        return await this._dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Guid> UpdateClientAsync(ClientDto clientDto)
    {
        var foundClient = await this._dbContext.Clients.FirstOrDefaultAsync(c => c.Id == clientDto.Id);

        if (foundClient is null)
            return Guid.Empty;

        foundClient.Nom = clientDto.Nom;
        foundClient.Secteur = clientDto.Secteur;
        foundClient.Adresse = clientDto.Adresse;
        foundClient.Contact = clientDto.Contact;

        this._dbContext.Clients.Update(foundClient);
        await this._dbContext.SaveChangesAsync();
        
        return foundClient.Id;
    }
}
