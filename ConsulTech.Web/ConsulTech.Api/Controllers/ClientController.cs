using ConsulTech.Api.Models;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllClientsAsync()
    {
        return Ok(await this._clientService.GetAllClientsAsync());
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> GetClientByIdAsync(Guid id)
    {
        var foundClient = await this._clientService.GetClientByIdAsync(id);
        return foundClient is null ? NotFound() : Ok(foundClient);
    }

    [HttpPost]
    public async Task<ActionResult> CreateClientAsync([FromBody] ClientInput client)
    {
        var createdClientId = await this._clientService.CreateClientAsync(new ClientDto
        {
            Contact = client.Contact,
            Adresse = client.Adresse,
            Nom = client.Nom,
            Secteur = client.Secteur

        });

        return createdClientId != Guid.Empty ? Created($"/api/client/{createdClientId}", null) : Problem();
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateClientAsync(Guid id, [FromBody] ClientInput client)
    {
        if (id != client.Id)
            return BadRequest("L'id du client ne correspond pas à celui de l'URL.");

        var updatedClientId = await this._clientService.UpdateClientAsync(new ClientDto
        {
            Id = client.Id,
            Contact = client.Contact,
            Adresse = client.Adresse,
            Nom = client.Nom,
            Secteur = client.Secteur
        });

        return updatedClientId != Guid.Empty ? NoContent() : Problem();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteClientAsync(Guid id)
    {
        var clientToDelete = await this._clientService.GetClientByIdAsync(id);

        if(clientToDelete is null)
            return NotFound();

        var isDeleted = await this._clientService.DeleteClientAsync(clientToDelete.Id);

        return isDeleted ? NoContent() : Problem();
    }
}
