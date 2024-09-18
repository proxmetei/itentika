using ItentikaTest.Context;
using ItentikaTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ItentikaTest.Services.Incidents
{
    /// <summary>
    /// Работа с инцидентами и БД
    /// </summary>
    public class IncidentService : IIncidentService
    {
        private readonly IDbContextFactory<MainDbContext> _dbContextFactory;
        private readonly ILogger<IncidentService> _logger;
        public IncidentService(IDbContextFactory<MainDbContext> dbContextFactory,
            ILogger<IncidentService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }
        public async Task createIncident(Incident incident)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            await context.Incidents.AddAsync(incident);

            context.SaveChanges();
        }
        public async Task<List<Incident>> GetAllIncidents(bool sortByTime, int pageNum, int pageSize)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var result = context.Incidents.Include("Events");

            if (((pageNum - 1) * pageSize) > result.Count())
                _logger.LogError("Threr is no page with such number and size");

            if (sortByTime)
                result = result.OrderByDescending(x => x.Time);

            if (pageNum > 0 && ((pageNum - 1) * pageSize) < result.Count())
            {
                result = result.Skip((pageNum - 1) * pageSize).Take(pageSize);
            }

            return result.ToList();
        }
    }
}
