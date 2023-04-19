using AutoMapper;
using Trading.Common.Dto;
using Trading.Common.Dto.Pagination;
using Trading.Presentation.Website.Models;
using Trading.Presentation.Website.Models.Pagination;

namespace Trading.Presentation.Website.Automapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<StockDto, StockViewModel>().ReverseMap();
            CreateMap<PortfolioDto, PortfolioViewModel>().ReverseMap();
            CreateMap<PaginationFilterDto, PaginationFilterViewModel>().ReverseMap();
            CreateMap(typeof(PagedResponseDto<>), typeof(PagedResponseViewModel<>)).ReverseMap();
        }
    }
}
