using ConsulTech.Api.Models;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;

        public ConsultantController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllConsultantAsync()
        {
            return Ok(await this._consultantService.GetAllConsultantsAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetConsultantByIdAsync(Guid id)
        {
            var foundConsultant = await this._consultantService.GetConsultantByIdAsync(id);
            return foundConsultant is null ? NotFound() : Ok(foundConsultant);
        }

        [HttpPost]
        public async Task<ActionResult> CreateConsultantAsync([FromBody] ConsultantInput consultant)
        {
            var createdConsultantId = await this._consultantService.CreateConsultantAsync(new ConsultantDto
            {
                Nom = consultant.Nom,
                Prenom = consultant.Prenom,
                Email = consultant.Email,
                DateEmbauche = consultant.DateEmbauche,
                EstDisponible = consultant.EstDisponible
            });

            return createdConsultantId != Guid.Empty ? Created($"/api/consultant/{createdConsultantId}", null) : Problem();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateConsultantAsync(Guid id, [FromBody] ConsultantInput consultant)
        {
            if (id != consultant.Id)
                return BadRequest("L'id du consultant ne correspond pas à celui de l'URL.");

            var updatedConsultantId = await this._consultantService.UpdateConsultantAsync(new ConsultantDto
            {
                Id = consultant.Id,
                Prenom = consultant.Prenom,
                Nom = consultant.Nom,
                Email = consultant.Email,
                DateEmbauche = consultant.DateEmbauche,
                EstDisponible = consultant.EstDisponible
            });

            return updatedConsultantId != Guid.Empty ? NoContent() : Problem();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteConsultantAsync(Guid id)
        {
            var consultantToDelete = await this._consultantService.GetConsultantByIdAsync(id);

            if (consultantToDelete is null)
                return NotFound();

            var isDeleted = await this._consultantService.DeleteConsultantAsync(consultantToDelete.Id);

            return isDeleted ? NoContent() : Problem();
        }
    }
}
