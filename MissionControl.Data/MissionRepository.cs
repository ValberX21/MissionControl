using Microsoft.EntityFrameworkCore;
using MissionControl.Data;
using MissionControl.Shared.Models;

namespace MissionControl.Data
{
    public class MissionRepository
    {
        private readonly ApplicationDbContext _db;
        protected ResponseDto _response;

        public MissionRepository(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        public async Task<bool> CreateMission(Mission mission)
        {
            try
            {
                if (mission.LaunchDate.Kind != DateTimeKind.Utc)
                {
                    mission.LaunchDate = mission.LaunchDate.ToUniversalTime();
                }

                _db.Mission.Add(mission);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Mission>> listMissions(Mission filter)
        {
            var query = _db.Mission.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(m => m.Name.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.Destination))
                query = query.Where(m => m.Destination.Contains(filter.Destination));

            if (!string.IsNullOrWhiteSpace(filter.RocketType))
                query = query.Where(m => m.RocketType.Contains(filter.RocketType));

            if (!string.IsNullOrWhiteSpace(filter.Status))
                query = query.Where(m => m.Status.Contains(filter.Status));

            if (!string.IsNullOrWhiteSpace(filter.MasterApprove))
                query = query.Where(m => m.MasterApprove.Contains(filter.MasterApprove));

            return await query.ToListAsync();
        }

    }
}
