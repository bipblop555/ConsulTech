using ConsulTech.Core.Context;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConsulTech.Core.Services;

public sealed class ConsultantService : IConsultantService
{
    private readonly ConsultTechContext _dbContext;

    public ConsultantService(ConsultTechContext dbContext) => this._dbContext = dbContext;
    public async Task<Guid> CreateConsultantAsync(ConsultantDto consultantDto)
    {
        if(await this._dbContext.Consultants.AnyAsync(c => c.Email == consultantDto.Email))
            return Guid.Empty;

        var consultantToAdd = new Consultant
        {
            Nom = consultantDto.Nom,
            Prenom = consultantDto.Prenom,
            Email = consultantDto.Email,
            DateEmbauche = consultantDto.DateEmbauche,
            EstDisponible = consultantDto.EstDisponible
        };

        await this._dbContext.Consultants.AddAsync(consultantToAdd);
        await this._dbContext.SaveChangesAsync();
        return consultantToAdd.Id;
    }

    public async Task<bool> DeleteConsultantAsync(Guid id)
    {
        var foundConsultant = this._dbContext.Consultants
            .Include(c => c.Missions)
            .Include(c => c.Competences)
            .FirstOrDefault(c => c.Id == id);
        if (foundConsultant is null)
            return false;

        this._dbContext.Consultants.Remove(foundConsultant);
        await this._dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<ConsultantDto>> GetAllConsultantsAsync()
    {
        return await this._dbContext.Consultants
            .Include(c => c.Competences)
            .Include(c => c.Missions)
            .Select(c => new ConsultantDto
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                DateEmbauche = c.DateEmbauche,
                EstDisponible = c.EstDisponible,

                Competences = new List<CompetenceListDto>(c.Competences.Select(k => new CompetenceListDto(
                    k.Id,
                    k.Titre
                )))
            })
            .ToListAsync();
    }

    public Task<ConsultantDto> GetConsultantByIdAsync(Guid id)
    {
        return this._dbContext.Consultants
            .Include(c => c.Competences)
            .Include(c => c.Missions)
            .Select(c => new ConsultantDto
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                DateEmbauche = c.DateEmbauche,
                EstDisponible = c.EstDisponible,

                Competences = new List<CompetenceListDto>(c.Competences.Select(k => new CompetenceListDto(
                    k.Id,
                    k.Titre
                )))
            })
            .FirstOrDefaultAsync(c => c.Id == id)!;
    }

    public async Task<Guid> UpdateConsultantAsync(ConsultantDto consultantDto)
    {
        var foundConsultant = await this._dbContext.Consultants
            .Include(c => c.Competences)
            .Include(c => c.Missions)
            .FirstOrDefaultAsync(c => c.Id == consultantDto.Id);
        if (foundConsultant is null)
            return Guid.Empty;

        foundConsultant.Nom = consultantDto.Nom;
        foundConsultant.Prenom = consultantDto.Prenom;
        foundConsultant.Email = consultantDto.Email;
        foundConsultant.DateEmbauche = consultantDto.DateEmbauche;
        foundConsultant.EstDisponible = consultantDto.EstDisponible;

        await this._dbContext.SaveChangesAsync();
        return foundConsultant.Id;
    }
}
