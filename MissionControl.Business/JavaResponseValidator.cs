using Azure;
using MissionControl.Data;
using MissionControl.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Business
{
    public class JavaResponseValidator
    {
        private readonly JavaResponseRepository _javaResponseRepository;
        protected ResponseDto _response;

        public JavaResponseValidator(JavaResponseRepository missionRepository)
        {
            _javaResponseRepository = missionRepository;
            _response = new ResponseDto();
        }

        public async Task<ResponseDto> confirmMission(JavaResponseModel mission)
        {
            try
            {
                mission.ReceivedAt = DateTime.UtcNow;
              
                bool addReturnJava = await _javaResponseRepository.confirmJava(mission);

                if (addReturnJava)
                {
                    _response.IsSuccess = true;
                    _response.Data = mission;
                    _response.DisplayMessage = "Mission approved";
                }
                

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.Message;
            }

            return _response;

        }
    }
}
