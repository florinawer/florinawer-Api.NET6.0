using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Infrastructure.Data.Model;
using TradingDDD.Infrastructure.Repository.Interfaces;

namespace TradingDDD.Infrastructure.Repository.Implementations
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        ILogger<StockRepository> _logger;
        public StockRepository(IUnitOfWork unitOfWork, ILogger<StockRepository> logger) : base(unitOfWork)
        {
            _logger = logger;
        }
        public async void InsertCsv(IEnumerable<Stock> stocks)
        {
            if (CheckStocks(stocks).Result == false)
            {
                string query = "Insert into Stocks (Symbol, Name) Values ";
                foreach (var stock in stocks)
                {
                    query += $"('{stock.Symbol}','{stock.Name}'),";
                }
                query = query.Remove(query.Length - 1, 1);
                await _unitOfWork.Context.Database.ExecuteSqlRawAsync(query);
        }
    }

        public async Task<bool> CheckStocks(IEnumerable<Stock> stocks)
        {
            var result = _unitOfWork.Context.Stocks.Count();
            var csvresult = stocks.Count();
            if (csvresult == result)
            {
                _logger.LogInformation($"No ha habido cambios en la base de datos {DateTime.Now}");
                return true;
            }
            _logger.LogInformation($"Se ha borrado la base de datos {DateTime.Now}");
            string query = "DELETE FROM Portfolio";
            await _unitOfWork.Context.Database.ExecuteSqlRawAsync(query);
            string query2 = "DELETE FROM Stocks";
            await _unitOfWork.Context.Database.ExecuteSqlRawAsync(query2);
            return false;
        }

        public async Task<Stock> GetByNameAsync(string name)
        {
            return await _unitOfWork.Context.Stocks.FirstOrDefaultAsync(d => d.Name == name);
        }
    }
}
