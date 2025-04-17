using Microsoft.AspNetCore.Mvc;
using MissionControl.Business;
using MissionControl.Message;
using MissionControl.Shared.Models;
using System.Text.Json;

namespace MissionControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly MissionValidator _missionValidator;
        private readonly RabbitMQService _rabbitMQService;

        protected ResponseDto _response;

        public MissionController(MissionValidator missionValidator, RabbitMQService rabbitMQService)
        {
            _missionValidator = missionValidator;
            _rabbitMQService = rabbitMQService;
            _response = new ResponseDto();
        }

        [HttpPost("addMission")]
        public async Task<IActionResult> Post([FromBody] Mission mission)
        {
            try
            {
                ResponseDto result = await _missionValidator.addMission(mission);                

                if (result.IsSuccess)
                {
                    var messageJson = JsonSerializer.Serialize(result.Data);

                    _rabbitMQService.SendMessage(messageJson, "Mission rescue");
                    return StatusCode(StatusCodes.Status201Created, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);                   
                }
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }
    }
}
