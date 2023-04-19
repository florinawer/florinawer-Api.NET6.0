using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Domain.Entities;
using TradingDDD.Domain.Entities.Pagination;

namespace TradingDDD.Application.Services.Interfaces
{
    public interface IStockService
    {
        public Task<PagedResponseEntity<List<StockEntity>>> GetAllAsync(PaginationFilterEntity paginationFilter, string route);
        public Task<StockEntity> GetByIdAsync(int id);
        public Task<StockEntity> InsertAsync(StockEntity entity);
    }
}
