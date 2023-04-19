using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Domain.Entities;

namespace TradingDDD.Application.Services.Interfaces
{
    public interface IPortfolioService
    {
        public Task<IEnumerable<PortfolioEntity>> GetAllAsync();
        public Task<PortfolioEntity> GetByIdAsync(int id);
        public Task<PortfolioEntity> InsertAsync(PortfolioEntity entity);
    }
}
