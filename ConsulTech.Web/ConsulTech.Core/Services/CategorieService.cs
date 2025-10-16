using ConsulTech.Core.Context;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConsulTech.Core.Services;

internal sealed class CategorieService : ICategorieService
{
    private readonly ConsultTechContext _dbContext;

    public CategorieService(ConsultTechContext dbContext) => this._dbContext = dbContext;

    public async Task<Guid> CreateCategorieAsync(CategorieDto categorieDto)
    {
        if(await this._dbContext.Categories.AnyAsync(c => c.Titre == categorieDto.Titre))
            return Guid.Empty;

        var categorieToAdd = new Categorie
        {
            Titre = categorieDto.Titre
        };

        await this._dbContext.Categories.AddAsync(categorieToAdd);
        await this._dbContext.SaveChangesAsync();

        return categorieToAdd.Id;
    }

    public async Task<bool> DeleteCategorieAsync(Guid id)
    {
        var foundCategorie = await this._dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (foundCategorie is null)
            return false;

        this._dbContext.Categories.Remove(foundCategorie);
        await this._dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<CategorieDto>> GetAllCategoriesAsync()
    {
        return await this._dbContext.Categories
            .Select(c => new CategorieDto
            {
                Id = c.Id,
                Titre = c.Titre
            })
            .ToListAsync();
    }

    public async Task<CategorieDto?> GetCategorieByIdAsync(Guid id)
    {
        return await this._dbContext.Categories
            .Select(c => new CategorieDto
            {
                Id = c.Id,
                Titre = c.Titre
            })
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Guid> UpdateCategorieAsync(CategorieDto categorieDto)
    {
        var foundCategorie = this._dbContext.Categories.FirstOrDefault(c => c.Id == categorieDto.Id);

        if (foundCategorie is null)
            return Guid.Empty;

        foundCategorie.Titre = categorieDto.Titre;

        this._dbContext.Categories.Update(foundCategorie);
        await this._dbContext.SaveChangesAsync();

        return foundCategorie.Id;
    }
}
