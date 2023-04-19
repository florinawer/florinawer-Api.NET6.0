using AutoMapper;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Domain.Entities;
using TradingDDD.Infrastructure.Data.Model;
using TradingDDD.Infrastructure.Repository;
using TradingDDD.Infrastructure.Repository.Interfaces;

namespace TradingDDD.Application.Services.Helpers
{
    public class SeedDataHelper
    {
        public static async Task Seed(IServiceProvider services)
        {
            var baseQuery = services.GetRequiredService<IConfiguration>().GetConnectionString("Query_url");
            var secret = services.GetRequiredService<IConfiguration>().GetConnectionString("apikey");
            var repository = services.GetRequiredService<IStockRepository>();
            var mapping = services.GetRequiredService<IMapper>();
            var unit = services.GetRequiredService<IUnitOfWork>();

            List<StockEntity> stocks = new();
            Uri baseUrl = new Uri("https://www.alphavantage.co/");
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            using (HttpClient client = new())
            {
               client.BaseAddress = baseUrl;
               var response = await client.GetAsync(baseQuery + secret);
                    using (StreamReader reader = new((MemoryStream)response.Content.ReadAsStream()))
                    {
                        using (CsvReader csv = new(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            
                            while (csv.Read())
                            {
                                stocks.Add(new StockEntity()
                                {
                                    Symbol = csv.Parser.Record[0].ToString(),
                                    Name = csv.Parser.Record[1].ToString().Replace("'", string.Empty)
                                });
                            }
                        }
                    }
            }
            repository.InsertCsv(mapping.Map<List<Stock>>(stocks));
            unit.Commit();
        }
    }
}

