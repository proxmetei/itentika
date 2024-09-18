using Microsoft.Extensions.DependencyInjection;

namespace ItentikaTest.Services.Generate
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddGenerateService(this IServiceCollection services)
        {
            services.AddHostedService<GenerateService>();

            return services;
        }
    }
}
