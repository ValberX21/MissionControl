using MissionControl.Data.Data;
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
                var custom = _db.Mission.Add(mission);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
