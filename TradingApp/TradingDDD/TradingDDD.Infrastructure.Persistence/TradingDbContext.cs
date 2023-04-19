using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TradingDDD.Infrastructure.Data.Model;

namespace TradingDDD.Infrastructure.Persistence
{
    public class TradingDbContext : DbContext
    {
        public readonly IHostingEnvironment _env;
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }

        public TradingDbContext(IHostingEnvironment env)
        {
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                   .UseMySql(config.GetConnectionString("DbContextConnectionString"), ServerVersion.AutoDetect(config.GetConnectionString("DbContextConnectionString")));
            }
        }
    }
}
