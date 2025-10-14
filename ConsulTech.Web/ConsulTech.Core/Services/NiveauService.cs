using ConsulTech.Core.Context;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConsulTech.Core.Services;

internal sealed class NiveauService : INiveauService
{
    private readonly ConsultTechContext _dbContext;

    public NiveauService(ConsultTechContext dbContext) => this._dbContext = dbContext;

    public async Task<Guid> CreateNiveauAsync(NiveauDto niveauDto)
    {
        if (await this._dbContext.Niveaux.AnyAsync(n => n.Titre == niveauDto.Titre))
            return Guid.Empty;

        var niveauToAdd = new Niveau
        {
            Titre = niveauDto.Titre
        };

        await this._dbContext.Niveaux.AddAsync(niveauToAdd);
        await this._dbContext.SaveChangesAsync();
        return niveauToAdd.Id;
    }

    public async Task<bool> DeleteNiveauAsync(Guid id)
    {
        var foundNiveau = await this._dbContext.Niveaux.FirstOrDefaultAsync(n => n.Id == id);
        if (foundNiveau is null)
            return false;

        this._dbContext.Niveaux.Remove(foundNiveau);
        await this._dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Niveau>> GetAllNiveauxAsync()
    {
        return await this._dbContext.Niveaux.ToListAsync();
    }

    public async Task<Niveau?> GetNiveauByIdAsync(Guid id)
    {
        return await this._dbContext.Niveaux.FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<Guid> UpdateNiveauAsync(NiveauDto niveauDto)
    {
        var foundNiveau = await this._dbContext.Niveaux.FirstOrDefaultAsync(n => n.Id == niveauDto.Id);

        if (foundNiveau is null)
            return Guid.Empty;

        foundNiveau.Titre = niveauDto.Titre;

        this._dbContext.Niveaux.Update(foundNiveau);
        await this._dbContext.SaveChangesAsync();
        return foundNiveau.Id;
    }
}
