using MissionControl.Data;
using MissionControl.Shared.Models;
using System.Reflection;

namespace MissionControl.Business
{
    public class MissionValidator
    {
        private readonly MissionRepository _missionRepository;
        protected ResponseDto _response;

        public MissionValidator(MissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
            _response = new ResponseDto();
        }

        public async Task<ResponseDto> addMission(Mission mission)
        {
            try
            {               
                bool addProdcut = await _missionRepository.CreateMission(mission);

                if (addProdcut)
                {
                    _response.IsSuccess = true;
                    _response.Data = mission;
                    _response.DisplayMessage = "Mission added success";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.Message;
            }

            return _response;

        }

        public async Task<List<Mission>> listMission(Mission filter)
        {
            return await _missionRepository.listMissions(filter);
        }

        public async Task<ResponseDto> updatedMission(Guid id, Mission mission)
        {
            try
            {
                bool addProdcut = await _missionRepository.Update(id,mission);

                if (addProdcut)
                {
                    _response.IsSuccess = true;
                    _response.Data = mission;
                    _response.DisplayMessage = "Mission updated success";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.Message;
            }

            return _response;
        }

        public async Task<Mission> findMissinoById(Guid id)
        {
            return await _missionRepository.getMissionById(id);
        }
    }
}
