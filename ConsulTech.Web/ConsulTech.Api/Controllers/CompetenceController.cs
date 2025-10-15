using ConsulTech.Api.Models;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompetenceController : ControllerBase
{
    private readonly ICompetenceService _competenceService;

    public CompetenceController(ICompetenceService competenceService) => _competenceService = competenceService;

    [HttpGet]
    public async Task<ActionResult> GetAllCompetencesAsync()
    {
        return Ok(await this._competenceService.GetAllCompetencesAsync());
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> GetCompetenceByIdAsync(Guid id)
    {
        var foundCompetence = await this._competenceService.GetCompetenceByIdAsync(id);
        return foundCompetence is null ? NotFound() : Ok(foundCompetence);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCompetenceAsync([FromBody] CompetenceInput competence)
    {
        var competenceDto = new CompetenceDto
        {
            Titre = competence.Titre,
            CategorieId = competence.CategorieId,
            NiveauId = competence.NiveauId,
            ConsultantsId = competence.ConsultantsId
        };

        var createdCompetenceId = await _competenceService.CreateCompetenceAsync(competenceDto);

        if (createdCompetenceId != Guid.Empty)
            return Created($"/api/competence/{createdCompetenceId}", new { Id = createdCompetenceId });

        return Problem("La création de la compétence a échoué.");
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateCompetenceAsync(Guid id, [FromBody] CompetenceInput competence)
    {
        if (id != competence.Id)
            return BadRequest("L'id de la compétence ne correspond pas à celui de l'URL.");
        var competenceDto = new CompetenceDto
        {
            Id = competence.Id,
            Titre = competence.Titre,
            CategorieId = competence.CategorieId,
            NiveauId = competence.NiveauId,
            ConsultantsId = competence.ConsultantsId
        };
        var updatedCompetenceId = await _competenceService.UpdateCompetenceAsync(competenceDto);
        if (updatedCompetenceId != Guid.Empty)
            return Ok(new { Id = updatedCompetenceId });
        return Problem("La mise à jour de la compétence a échoué.");
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteCompetenceAsync(Guid id)
    {
        var deletedCompetenceId = await _competenceService.DeleteCompetenceAsync(id);
        if (id != Guid.Empty)
            return Ok(new { Id = deletedCompetenceId });
        return Problem("La suppression de la compétence a échoué.");
    }
}
