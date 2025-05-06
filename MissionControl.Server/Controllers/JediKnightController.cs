using JediKnight.Business;
using Microsoft.AspNetCore.Mvc;
using MissionControl.Message;
using MissionControl.Shared.Models;

namespace MissionControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JediKnightController : ControllerBase
    {
        private readonly JediKnightValidator _jediKnightValidator;
        private readonly RabbitMQService _rabbitMQService;

        protected ResponseDto _response;

        public JediKnightController(JediKnightValidator jediKnightValidator, RabbitMQService rabbitMQService)
        {
            _jediKnightValidator = jediKnightValidator;
            _rabbitMQService = rabbitMQService;
            _response = new ResponseDto();
        }

        [HttpPost("loginJediKnight")]
        public async Task<IActionResult> LoginUser(LoginModel dtKnight)
        {
            try
            {
                ResponseDto jedi = await _jediKnightValidator.checkKnight(dtKnight);

                return StatusCode(StatusCodes.Status200OK, jedi);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }

        }

        [HttpPost("addJediKnight")]
        public async Task<IActionResult> CreateUser([FromBody] JediKnightModel jediKnight)
        {
            try
            {
                ResponseDto jedi = await _jediKnightValidator.addKnight(jediKnight);

                return StatusCode(StatusCodes.Status200OK, jedi);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }

        }
    }
}
