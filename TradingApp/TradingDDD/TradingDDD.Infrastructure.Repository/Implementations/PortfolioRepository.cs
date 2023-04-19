using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Infrastructure.Data.Model;
using TradingDDD.Infrastructure.Repository.Interfaces;

namespace TradingDDD.Infrastructure.Repository.Implementations
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        private readonly IStockRepository _stockRepository;
        public PortfolioRepository(IUnitOfWork unitOfWork, IStockRepository stockRepository) : base(unitOfWork)
        {
            _stockRepository = stockRepository;
        }

        public override async Task<Portfolio> InsertAsync(Portfolio portfolio)
        {
            var stock = await _stockRepository.GetByNameAsync(portfolio.Stock.Name);
            portfolio.Stock = stock;
            await _unitOfWork.Context.AddAsync(portfolio);
            return portfolio;
        }

        public override async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            var result = await _unitOfWork.Context.Portfolio.Include(d => d.Stock).ToListAsync();
            return result;
        }

        public override async Task<Portfolio> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.Context.Portfolio.Include(d => d.Stock).FirstOrDefaultAsync(d => d.Id == id);
            return result;
        }
    }
}
