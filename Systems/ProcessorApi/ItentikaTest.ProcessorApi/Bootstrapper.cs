namespace ItentikaTest.ProcessorApi;

using ItentikaTest.Services.Processing;
using ItentikaTest.Services.Incidents;
public static class Bootstrapper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddProcessingService()
            .AddIncidentService();

        return services;
    }
}
