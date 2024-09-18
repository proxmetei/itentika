namespace ItentikaTest.GeneratorApi;
using ItentikaTest.Services.Generate;
public static class Bootstrapper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddGenerateService();

        return services;
    }
}
