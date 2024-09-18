using ItentikaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ItentikaTest.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Event> Events { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

            Database.EnsureCreated();
        }
    }
}
