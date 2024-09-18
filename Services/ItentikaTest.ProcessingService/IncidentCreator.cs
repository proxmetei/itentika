using ItentikaTest.Models;

namespace ItentikaTest.Services.Processing
{
    public static class IncidentCreator
    {
        public static Incident GenerateIncident(IncidentTypeEnum type)
        {
            return new Incident()
            {
                Id = Guid.NewGuid(),
                Type = type,
                Time = DateTime.Now
            };
        }
    }
}
