using Microsoft.AspNetCore.Mvc;
using MissionControl.Business;
using MissionControl.Shared.Models;

namespace MissionControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly MissionValidator _missionValidator;
        protected ResponseDto _response;

        public MissionController(MissionValidator missionValidator)
        {
            _missionValidator = missionValidator;
            _response = new ResponseDto();
        }

        [HttpPost("addMission")]
        public async Task<IActionResult> Post([FromBody] Mission mission)
        {
            try
            {
                ResponseDto result = await _missionValidator.addMission(mission);

                bool statusReturned = (bool)result.GetType().GetProperty("IsSuccess")?.GetValue(result);

                if (!statusReturned)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status201Created, result);
                }
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }
    }
}
