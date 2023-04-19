using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Infrastructure.Data.Model;

namespace TradingDDD.Infrastructure.Repository.Interfaces
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        public void InsertCsv(IEnumerable<Stock> stocks);
        public Task<bool> CheckStocks(IEnumerable<Stock> stocks);
        public Task<Stock> GetByNameAsync(string name);
    }
}
