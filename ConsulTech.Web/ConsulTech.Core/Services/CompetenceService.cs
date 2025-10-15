using ConsulTech.Core.Context;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConsulTech.Core.Services;

internal sealed class CompetenceService : ICompetenceService
{
    private readonly ConsultTechContext _dbContext;

    public CompetenceService(ConsultTechContext dbContext) => this._dbContext = dbContext;

    public async Task<Guid> CreateCompetenceAsync(CompetenceDto competenceDto)
    {
        var competenceToAdd = new Competence
        {
            Titre = competenceDto.Titre,
            Niveau = competenceDto.Niveau,
            Categorie = competenceDto.Categorie
        };

        await this._dbContext.Competences.AddAsync(competenceToAdd);
        await this._dbContext.SaveChangesAsync();

        return competenceToAdd.Id;
    }

    public async Task<bool> DeleteCompetenceAsync(Guid id)
    {
        var foundCompetence = this._dbContext.Competences.FirstOrDefault(c => c.Id == id);
        if (foundCompetence is null)
            return false;
        this._dbContext.Competences.Remove(foundCompetence);
        await this._dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<Competence>> GetAllCompetencesAsync()
    {
        return await this._dbContext.Competences
            .Include(c => c.Categorie)
            .Include(c => c.Niveau)
            .ToListAsync();
    }

    public async Task<Competence?> GetCompetenceByIdAsync(Guid id)
    {
        return await this._dbContext.Competences
            .Include(c => c.Categorie)
            .Include(c => c.Niveau)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<Guid> UpdateCompetenceAsync(CompetenceDto competenceDto)
    {
        throw new NotImplementedException();
    }
}
