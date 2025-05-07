using Microsoft.AspNetCore.Mvc;
using MissionControl.Business;
using MissionControl.Message;
using MissionControl.Shared.Models;
using System.Collections.Generic;
using System.Text.Json;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

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

                    _rabbitMQService.SendMessage(messageJson, "MissionRescue");
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

        [HttpGet("list")]
        public async Task<IActionResult> Get([FromQuery] Mission filter)
        {
            List<Mission> missions = new List<Mission>();

            try
            {
                missions = await _missionValidator.listMission(filter);
                return StatusCode(StatusCodes.Status200OK, missions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }           

        }
    }
}
