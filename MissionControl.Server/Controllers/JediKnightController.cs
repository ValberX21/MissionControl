using Microsoft.AspNetCore.Mvc;
using MissionControl.Business;
using MissionControl.Message;
using MissionControl.Shared.Models;

namespace MissionControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JediKnightController : ControllerBase
    {
        private readonly MissionValidator _missionValidator;
        private readonly RabbitMQService _rabbitMQService;

        protected ResponseDto _response;

        public JediKnightController(MissionValidator missionValidator, RabbitMQService rabbitMQService)
        {
            _missionValidator = missionValidator;
            _rabbitMQService = rabbitMQService;
            _response = new ResponseDto();
        }

        [HttpPost("searchJediKnight")]
        public async Task<IActionResult> Get()
        {
            try
            {
                //IEnumerable<Product> result = (List<Product>)await _productValidator.listAllProducts();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }

        }
    }
}
