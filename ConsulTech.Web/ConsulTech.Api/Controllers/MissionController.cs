using ConsulTech.Api.Models;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        public record MissionOutput(
            Guid Id, string Titre, string Description,
            DateTime Debut, DateTime Fin, float Budget,
            Guid ClientId, string ClientNom
        );

        [HttpGet]
        public async Task<ActionResult> GetAllMissionAsync()
        {
            var missions = await _missionService.GetAllMissionAsync();
            var output = missions.Select(m => new MissionOutput(
                m.Id,
                m.Titre,
                m.Description,
                m.Debut,
                m.Fin,
                m.Budget,
                m.ClientId,
                m.Client?.Nom ?? "-"
            ));
            return Ok(output);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetMissionByIdAsync(Guid id)
        {
            var m = await _missionService.GetMissionByIdAsync(id);
            if (m is null) return NotFound();

            var dto = new MissionOutput(
                m.Id,
                m.Titre,
                m.Description,
                m.Debut,
                m.Fin,
                m.Budget,
                m.ClientId,
                m.Client?.Nom ?? "-"
            );
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMissionAsync([FromBody] MissionInput mission)
        {
            var createdMissionId = await this._missionService.CreateMissionAsync(new MissionDto
            {
                Titre = mission.Titre,
                Description = mission.Description,
                Debut = mission.Debut,
                Fin = mission.Fin,
                Budget = mission.Budget,
                ClientId = mission.ClientId
            });

            return createdMissionId != Guid.Empty ? Created($"/api/mission/{createdMissionId}", null) : Problem();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateMissionAsync(Guid id, [FromBody] MissionInput mission)
        {
            if (id != mission.Id)
                return BadRequest("L'id de la mission ne correspond pas à celui de l'URL.");

            var updatedMissionId = await this._missionService.UpdateMissionAsync(new MissionDto
            {
                Id = mission.Id,
                Titre = mission.Titre,
                Description = mission.Description,
                Debut = mission.Debut,
                Fin = mission.Fin,
                Budget = mission.Budget,
                ClientId = mission.ClientId
            });

            return updatedMissionId != Guid.Empty ? NoContent() : Problem();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteMissionAsync(Guid id)
        {
            var missionToDelete = await this._missionService.GetMissionByIdAsync(id);

            if (missionToDelete is null)
                return NotFound();

            var isDeleted = await this._missionService.DeleteMissionAsync(missionToDelete.Id);

            return isDeleted ? NoContent() : Problem();
        }
    }
}
