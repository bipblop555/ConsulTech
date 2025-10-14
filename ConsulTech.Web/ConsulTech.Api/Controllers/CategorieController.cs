using ConsulTech.Api.Models;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Api.Controllers
{
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategorieAsync()
        {
            return Ok(await this._categorieService.GetAllCategoriesAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetCategorieByIdAsync(Guid id)
        {
            var foundCategorie = await this._categorieService.GetCategorieByIdAsync(id);
            return foundCategorie is null ? NotFound() : Ok(foundCategorie);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategorieAsync([FromBody] CategorieInput categorie)
        {
            var createdCategorieId = await this._categorieService.CreateCategorieAsync(new CategorieDto
            {
                Titre = categorie.Titre
            });

            return createdCategorieId != Guid.Empty ? Created($"/api/categorie/{createdCategorieId}", null) : Problem();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateCategorieAsync(Guid id, [FromBody] CategorieInput categorie)
        {
            if (id != categorie.Id)
                return BadRequest("L'id de la categorie ne correspond pas à celui de l'URL.");

            var updatedCategorieId = await this._categorieService.UpdateCategorieAsync(new CategorieDto
            {
                Id = categorie.Id,
                Titre = categorie.Titre
            });

            return updatedCategorieId != Guid.Empty ? NoContent() : Problem();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCategorieAsync(Guid id)
        {
            var categorieToDelete = await this._categorieService.GetCategorieByIdAsync(id);

            if (categorieToDelete is null)
                return NotFound();

            var isDeleted = await this._categorieService.DeleteCategorieAsync(categorieToDelete.Id);

            return isDeleted ? NoContent() : Problem();
        }
    }
}
