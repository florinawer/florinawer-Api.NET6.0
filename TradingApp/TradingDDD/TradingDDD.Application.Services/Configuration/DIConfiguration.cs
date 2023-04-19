using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradingDDD.Application.Services.Helpers;
using TradingDDD.Application.Services.Implementations;
using TradingDDD.Application.Services.Interfaces;
using TradingDDD.Infrastructure.Persistence;
using TradingDDD.Infrastructure.Repository;
using TradingDDD.Infrastructure.Repository.Implementations;
using TradingDDD.Infrastructure.Repository.Interfaces;


namespace TradingDDD.Application.Services.Configuration
{
    public class DIConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public DIConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void ConfigureServices()
        {
            _services.AddDbContext<TradingDbContext>();
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            _services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            _services.AddScoped<IStockRepository, StockRepository>();
            _services.AddScoped<IStockService, StockService>();
            _services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            _services.AddScoped<IPortfolioService, PortfolioService>();
            //IUriService
            _services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
        }

        public async Task ConfigureMigrations(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TradingDbContext>();
            await context.Database.MigrateAsync();
        }

    }
}
