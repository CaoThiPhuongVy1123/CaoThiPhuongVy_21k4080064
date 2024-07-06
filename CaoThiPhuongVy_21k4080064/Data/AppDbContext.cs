using Microsoft.EntityFrameworkCore;

namespace CaoThiPhuongVy_21k4080064.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
