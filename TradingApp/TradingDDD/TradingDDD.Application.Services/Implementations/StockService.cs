using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Application.Services.Helpers;
using TradingDDD.Application.Services.Interfaces;
using TradingDDD.Domain.Entities;
using TradingDDD.Domain.Entities.Pagination;
using TradingDDD.Infrastructure.Data.Model;
using TradingDDD.Infrastructure.Repository.Interfaces;

namespace TradingDDD.Application.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public StockService(IStockRepository stockRepository, IMapper mapper, IUriService uriService)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
            _uriService = uriService;
        }

        public async Task<PagedResponseEntity<List<StockEntity>>> GetAllAsync(PaginationFilterEntity paginationFilter, string route)
        {
            int totalRecord = await _stockRepository.GetCountAsync();
            var pageData = _mapper.Map<List<StockEntity>>(await _stockRepository.PaginationAsync(_mapper.Map<PaginationFilter>(paginationFilter)));
            var PagedResponse = PaginationHelper.CreatePagedReponse(pageData, paginationFilter, totalRecord, _uriService, route);
            return PagedResponse;
        }

        public async Task<StockEntity> GetByIdAsync(int id)
        {
            Stock stock = await _stockRepository.GetByIdAsync(id);
            return _mapper.Map<StockEntity>(stock);
        }

        public Task<StockEntity> InsertAsync(StockEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
