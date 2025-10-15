using ConsulTech.Core.Context;
using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConsulTech.Core.Services
{
    internal class MissionService : IMissionService
    {
        private readonly ConsultTechContext _dbContext;
        public MissionService(ConsultTechContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Guid> CreateMissionAsync(MissionDto missionDto)
        {
            if (await this._dbContext.Missions.AnyAsync(m => m.Titre == missionDto.Titre))
                return Guid.Empty;

            var missionToAdd = new Mission
            {
                Titre = missionDto.Titre,
                Description = missionDto.Description,
                Debut = missionDto.Debut,
                Fin = missionDto.Fin,
                Budget = missionDto.Budget,
                ClientId = missionDto.ClientId
            };

            await this._dbContext.Missions.AddAsync(missionToAdd);
            await this._dbContext.SaveChangesAsync();
            return missionToAdd.Id;
        }

        public async Task<bool> DeleteMissionAsync(Guid id)
        {
            var foundMission = await this._dbContext.Missions.FirstOrDefaultAsync(c => c.Id == id);
            if (foundMission is null)
                return false;

            this._dbContext.Missions.Remove(foundMission);
            await this._dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Mission>> GetAllMissionAsync()
        {
            return await this._dbContext.Missions.Include(m => m.Client).ToListAsync();
        }

        public async Task<Mission?> GetMissionByIdAsync(Guid id)
        {
            return await this._dbContext.Missions.Include(m => m.Client).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Guid> UpdateMissionAsync(MissionDto missionDto)
        {
            var foundMission = await this._dbContext.Missions.FirstOrDefaultAsync(m => m.Id == missionDto.Id);

            if (foundMission is null)
                return Guid.Empty;

            foundMission.Titre = missionDto.Titre;
            foundMission.Description = missionDto.Description;
            foundMission.Debut = missionDto.Debut;
            foundMission.Fin = missionDto.Fin;
            foundMission.Budget = missionDto.Budget;
            foundMission.ClientId = missionDto.ClientId;

            this._dbContext.Missions.Update(foundMission);
            await this._dbContext.SaveChangesAsync();

            return foundMission.Id;
        }
    }
}
