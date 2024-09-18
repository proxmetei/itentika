using Microsoft.Extensions.DependencyInjection;

namespace ItentikaTest.Services.Incidents
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddIncidentService(this IServiceCollection services)
        {
            return services
                .AddSingleton<IIncidentService, IncidentService>();
        }
    }
}