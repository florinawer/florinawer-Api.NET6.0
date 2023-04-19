using AutoMapper;
using Serilog;
using TradingDDD.Application.Services.Helpers;
using TradingDDD.Application.Services.Interfaces;
using TradingDDD.Domain.Entities;
using TradingDDD.Infrastructure.Data.Model;
using TradingDDD.Infrastructure.Repository;
using TradingDDD.Infrastructure.Repository.Interfaces;

namespace TradingDDD.Application.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        
       

        public PortfolioService(IPortfolioRepository portfolioRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger logger)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        public async Task<IEnumerable<PortfolioEntity>> GetAllAsync()
        {
            IEnumerable<Portfolio> stocks = await _portfolioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PortfolioEntity>>(stocks);
        }

        public async Task<PortfolioEntity> GetByIdAsync(int id)
        {
            Portfolio portfolio = await _portfolioRepository.GetByIdAsync(id);
            return _mapper.Map<PortfolioEntity>(portfolio);
        }

        public async Task<PortfolioEntity> InsertAsync(PortfolioEntity entity)
        {
            Portfolio portfolio = await _portfolioRepository.InsertAsync(_mapper.Map<Portfolio>(entity));
            _unitOfWork.Commit();
            _logger.Information("Se ha añadido un Stock a tu portfolio");
            //EmailHelper.Send("Se ha añadido un Stock a tu portfolio");
            return _mapper.Map<PortfolioEntity>(portfolio);
        }
    }
}
