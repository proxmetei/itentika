using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ItentikaTest.Context
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Register db context
        /// </summary>
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
        {

            services.AddDbContextFactory<MainDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}
