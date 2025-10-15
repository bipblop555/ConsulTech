using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulTech.Core.Services.Abstractions
{
    public interface IConsultantService
    {
        Task<List<ConsultantDto>> GetAllConsultantsAsync();
        Task<Consultant> GetConsultantByIdAsync(Guid id);
        Task<Guid> CreateConsultantAsync(ConsultantDto consultantDto);
        Task<Guid> UpdateConsultantAsync(ConsultantDto consultantDto);
        Task<bool> DeleteConsultantAsync(Guid id);
    }
}
