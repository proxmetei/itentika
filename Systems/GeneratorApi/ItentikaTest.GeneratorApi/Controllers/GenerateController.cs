using ItentikaTest.Models;
using ItentikaTest.Services.Generate;
using Microsoft.AspNetCore.Mvc;

namespace ItentikaTest.GeneratorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly ILogger<GenerateController> _logger;
        public GenerateController(ILogger<GenerateController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Создать событие вручную
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateEvent")]
        public IActionResult GenerateEventManually(int? type)
        {
            if (type < 1 || type > 4)
            {
                _logger.LogError($"Wrong type {type}", type);
                return StatusCode(406);
            }
            Event myEvent = type==null ? EventCreator.GenerateEvent() : EventCreator.GenerateEvent(type.Value);
            _logger.LogInformation(
            "GenerateController is working. Event: {eventStr}", myEvent.ToString());
            try
            {
                RequestGenerator.SendRequest(myEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    "Error while sending manual requset. Exception: {ex}", ex);
                return StatusCode(400);
            }
            return StatusCode(200);
        }
    }
}
