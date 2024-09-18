using ItentikaTest.Models;
using Microsoft.AspNetCore.Mvc;
using ItentikaTest.Services.Incidents;
using ItentikaTest.Services.Processing;

namespace ItentikaTest.ProcessorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly ILogger<ProcessController> _logger;
        private readonly IProcessingService _processingService;
        private readonly IIncidentService _incidentService;
        public ProcessController(ILogger<ProcessController> logger,
            IProcessingService processingService,
            IIncidentService incidentService)
        {
            _logger = logger;
            _processingService = processingService;
            _incidentService = incidentService;
        }
        /// <summary>
        /// Обработать получаемое событие
        /// </summary>
        /// <param name="myEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProcessEvent(Event myEvent)
        {
            _logger.LogInformation(
                "Event is accepted. Event: {eventStr}", myEvent.ToString());
            _processingService.processEvent(myEvent);
            return Ok();
        }
        /// <summary>
        /// Получить список созданных инцидентов
        /// Если параметры не верны, вернутся все инциденты, залоггируется ошибка
        /// </summary>
        /// <param name="sortByTime">Сортировка по умолчанию включенена (убывание по времени)</param>
        /// <param name="pageNum">Номер страницы, если равен 0, то вывести все инциденты</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetIncidents(bool sortByTime=true,
            int pageNum=0,
            int pageSize=5)
        {
            if (pageNum < 0)
            {
                _logger.LogError($"Page number can not be {pageNum}", pageNum);

            }
            if (pageSize <= 0)
            {
                _logger.LogError($"Page number can not be {pageSize}", pageSize);

            }
            return new JsonResult(_incidentService.GetAllIncidents(sortByTime, pageNum, pageSize));
        }
    }
}
