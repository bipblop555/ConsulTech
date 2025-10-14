using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulTech.Core.Services.Abstractions
{
    public interface IMissionService
    {
        Task<List<Mission>> GetAllMissionAsync();
        Task<Mission?> GetMissionByIdAsync(Guid id);
        Task<Guid> CreateMissionAsync(MissionDto missionDto);
        Task<Guid> UpdateMissionAsync(MissionDto missionDto);
        Task<bool> DeleteMissionAsync(Guid id);
    }
}
