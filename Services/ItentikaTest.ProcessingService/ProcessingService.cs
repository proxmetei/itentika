using ItentikaTest.Models;
using ItentikaTest.Services.Incidents;
using Microsoft.Extensions.Logging;

namespace ItentikaTest.Services.Processing
{
    /// <summary>
    /// Основная логика обработки событий на процессоре
    /// </summary>
    public class ProcessingService: IProcessingService
    {
        private readonly ILogger<ProcessingService> _logger;

        private Timer? _timer = null;

        private List<Event> _events;

        private readonly IIncidentService _incidentService;

        private const int waitTime = 20;

        public ProcessingService(ILogger<ProcessingService> logger, IIncidentService incidentService)
        {
            _logger = logger;
            _events = new List<Event>();
            _incidentService = incidentService;
        }
        public void processEvent(Event curEvent)
        {
                if ((int)curEvent.Type == 2)
                {
                    if (_timer != null)
                        DoWork(null);

                    _events.Add(curEvent);
                    _timer = new Timer(DoWork, null, TimeSpan.FromSeconds(waitTime), TimeSpan.Zero);
                }
                else if ((int)curEvent.Type == 1)
                {
                    _events.Add(curEvent);
                    if (_timer != null)
                    {
                        Incident incedent = IncidentCreator.GenerateIncident(IncidentTypeEnum.SecondType);
                        incedent.Events = _events;
                        _incidentService.createIncident(incedent);
                        _events.Clear();
                        _timer?.Dispose();
                        _timer = null;
                    }
                    else
                    {
                        Incident incedent = IncidentCreator.GenerateIncident(IncidentTypeEnum.FirstType);
                        incedent.Events = _events;
                        _incidentService.createIncident(incedent);
                        _events.Clear();
                    }
                }
            
            _logger.LogInformation("ProcessingService is working. Timer is not waiting : {eventStr}", _timer != null);
        }
        private void DoWork(object? state)
        {
                _events.Clear();
                _timer?.Dispose();
                _timer = null;
        }
    }
}
