using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulTech.Core.Services.Abstractions
{
    public interface ICompetenceService
    {
        Task<List<Competence>> GetAllCompetencesAsync();
        Task<Competence?> GetCompetenceByIdAsync(Guid id);
        Task<Guid> CreateCompetenceAsync(CompetenceDto competenceDto);
        Task<Guid> UpdateCompetenceAsync(CompetenceDto competenceDto);
        Task<bool> DeleteCompetenceAsync(Guid id);
    }
}
