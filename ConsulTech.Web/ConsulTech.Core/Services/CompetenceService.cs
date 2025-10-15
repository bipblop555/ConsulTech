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

        var categorie = await _dbContext.Categories.FindAsync(competenceDto.CategorieId);
        var niveau = await _dbContext.Niveaux.FindAsync(competenceDto.NiveauId);
        var consultant = await _dbContext.Consultants.FindAsync(competenceDto.ConsultantsId);

        if (categorie is null || niveau is null || consultant is null)
            return Guid.Empty;

        var competence = new Competence
        {
            Titre = competenceDto.Titre,
            Categorie = categorie,
            Niveau = niveau,
            Consultants = new List<Consultant>() { consultant }
        };

        _dbContext.Competences.Add(competence);
        await _dbContext.SaveChangesAsync();

        return competence.Id;
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

    public async Task<List<CompetenceDto>> GetAllCompetencesAsync()
    {
        // retourner la liste de compétence dto 
        // convertir en DTO
        return await this._dbContext.Competences
            .Include(cat => cat.Categorie)
            .Include(c => c.Niveau)
            .Include(consultant => consultant.Consultants)
            .Select(comp => new CompetenceDto
            {
                Id = comp.Id,
                Titre = comp.Titre,
                CategorieName = comp.Categorie.Titre,
                NiveauName = comp.Niveau.Titre,
                CategorieId = comp.Categorie.Id,
                NiveauId = comp.Niveau.Id,
                ConsultantsId = comp.Consultants.FirstOrDefault() != null ? comp.Consultants.First().Id : Guid.Empty
            })
            .ToListAsync();
    }

    public async Task<CompetenceDto> GetCompetenceByIdAsync(Guid id)
    {
        return await this._dbContext.Competences
            .Include(c => c.Categorie)
            .Include(c => c.Niveau)
            .Include(c => c.Consultants)
            .Select(comp => new CompetenceDto
            {
                Id = comp.Id,
                Titre = comp.Titre,
                CategorieName = comp.Categorie.Titre,
                NiveauName = comp.Niveau.Titre,
                CategorieId = comp.Categorie.Id,
                NiveauId = comp.Niveau.Id,
                ConsultantsId = comp.Consultants.FirstOrDefault() != null ? comp.Consultants.First().Id : Guid.Empty
            })
            .FirstOrDefaultAsync(c => c.Id == id) ?? new();
    }

    public async Task<Guid> UpdateCompetenceAsync(CompetenceDto competenceDto)
    {
        var foundCompetence = await this._dbContext.Competences
            .Include(c => c.Categorie)
            .Include(c => c.Niveau)
            .Include(c => c.Consultants)
            .FirstOrDefaultAsync(c => c.Id == competenceDto.Id);
        if (foundCompetence is null)
            return Guid.Empty;

        foundCompetence!.Titre = competenceDto.Titre;
        foundCompetence.Categorie.Id = competenceDto.CategorieId;
        foundCompetence.Niveau.Id = competenceDto.NiveauId;
        foundCompetence.Consultants = await this._dbContext.Consultants
            .Where(con => con.Competences.Any(comp => comp.Id == competenceDto.Id))
            .ToListAsync();

        await this._dbContext.SaveChangesAsync();

        return foundCompetence.Id;
    }
}
