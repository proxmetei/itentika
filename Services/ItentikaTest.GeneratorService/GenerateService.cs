using ItentikaTest.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ItentikaTest.Services.Generate
{
    /// <summary>
    /// Генератор событий
    /// </summary>
    public class GenerateService : BackgroundService
    {
        private readonly ILogger<GenerateService> _logger;

        private const int periodTime = 2;

        public GenerateService(ILogger<GenerateService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(new Random().NextDouble() * periodTime));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                Event myEvent = EventCreator.GenerateEvent();

                _logger.LogInformation(
                    "GenerateService is working. Event: {eventStr}", myEvent.ToString());

                try
                {
                    RequestGenerator.SendRequest(myEvent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        "Error while sending requset from background. Exception: {ex}", ex);
                }

                timer.Period = TimeSpan.FromSeconds(new Random().NextDouble() * 2);
            }
        }
    }
}
