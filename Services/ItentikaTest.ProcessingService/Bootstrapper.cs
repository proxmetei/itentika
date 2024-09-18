using Microsoft.Extensions.DependencyInjection;

namespace ItentikaTest.Services.Processing
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddProcessingService(this IServiceCollection services)
        {
            return services
                .AddSingleton<IProcessingService, ProcessingService>();
        }
    }
}