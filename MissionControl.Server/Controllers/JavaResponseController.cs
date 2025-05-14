using Microsoft.AspNetCore.Mvc;
using MissionControl.Business;
using MissionControl.Shared.Models;

namespace MissionControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JavaResponseController : ControllerBase
    {
        private readonly JavaResponseValidator _javaResponseValidator;

        public JavaResponseController(JavaResponseValidator javaResponseValidator)
        {
            _javaResponseValidator = javaResponseValidator;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveResponse([FromBody] JavaResponseModel model)
        {
            ResponseDto result = await _javaResponseValidator.confirmMission(model);

            return StatusCode(StatusCodes.Status201Created, result);

        }
    }
}
