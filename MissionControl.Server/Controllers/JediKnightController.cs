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

        [HttpPost("searchJediKnight")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<JediKnightModel> result = (IEnumerable<JediKnightModel>)await _jediKnightValidator.listJediKnights();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }

        }
    }
}
