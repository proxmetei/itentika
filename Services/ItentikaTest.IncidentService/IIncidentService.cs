using ItentikaTest.Models;

namespace ItentikaTest.Services.Incidents
{
    public interface IIncidentService
    {
        Task<List<Incident>> GetAllIncidents(bool sortByTime, int pageNum, int pageSize);
        Task createIncident(Incident model);
    }
}
