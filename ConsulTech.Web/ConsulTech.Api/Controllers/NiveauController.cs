using ConsulTech.Api.Models;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NiveauController : ControllerBase
{
    private readonly INiveauService _niveauService;

    public NiveauController(INiveauService niveauService)
    {
        _niveauService = niveauService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllNiveauAsync()
    {
        return Ok(await this._niveauService.GetAllNiveauxAsync());
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> GetNiveauByIdAsync(Guid id)
    {
        var foundNiveau = await this._niveauService.GetNiveauByIdAsync(id);
        return foundNiveau is null ? NotFound() : Ok(foundNiveau);
    }

    [HttpPost]
    public async Task<ActionResult> CreateNiveauAsync([FromBody] NiveauInput niveau)
    {
        var createdNiveauId = await this._niveauService.CreateNiveauAsync(new NiveauDto
        {
            Titre = niveau.Titre
        });

        return createdNiveauId != Guid.Empty ? Created($"/api/niveau/{createdNiveauId}", null) : Problem();
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateNiveauAsync(Guid id, [FromBody] NiveauInput niveau)
    {
        if (id != niveau.Id)
            return BadRequest("L'id du niveau ne correspond pas à celui de l'URL.");

        var updatedNiveauId = await this._niveauService.UpdateNiveauAsync(new NiveauDto
        {
            Id = niveau.Id,
            Titre = niveau.Titre
        });

        return updatedNiveauId != Guid.Empty ? NoContent() : Problem();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteNiveauAsync(Guid id)
    {
        var niveauToDelete = await this._niveauService.GetNiveauByIdAsync(id);

        if (niveauToDelete is null)
            return NotFound();

        var isDeleted = await this._niveauService.DeleteNiveauAsync(niveauToDelete.Id);

        return isDeleted ? NoContent() : Problem();
    }
}
