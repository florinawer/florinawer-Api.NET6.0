using AutoMapper;
using TradingDDD.Domain.Entities;
using TradingDDD.Domain.Entities.Pagination;
using TradingDDD.Infrastructure.Data.Model;
using TradingDDD.Web.Dto;
using TradingDDD.Web.Dto.Pagination;

namespace TradingDDD.Web.Api.Automapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<StockDto, StockEntity>().ReverseMap();
            CreateMap<StockEntity, Stock>().ReverseMap();
            CreateMap<PortfolioDto, PortfolioEntity>().ReverseMap();
            CreateMap<PortfolioEntity, Portfolio>().ReverseMap();
            CreateMap<PaginationFilterDto, PaginationFilterEntity>().ReverseMap();
            CreateMap<PaginationFilterEntity, PaginationFilter>().ReverseMap();
            CreateMap(typeof(PagedResponseDto<>), typeof(PagedResponseEntity<>)).ReverseMap();

        }
    }
}
