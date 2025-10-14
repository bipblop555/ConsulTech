using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulTech.Core.Services.Abstractions
{
    public interface INiveauService
    {
        Task<List<Niveau>> GetAllNiveauxAsync();
        Task<Niveau?> GetNiveauByIdAsync(Guid id);
        Task<Guid> CreateNiveauAsync(NiveauDto niveauDto);
        Task<Guid> UpdateNiveauAsync(NiveauDto niveauDto);
        Task<bool> DeleteNiveauAsync(Guid id);
    }
}
