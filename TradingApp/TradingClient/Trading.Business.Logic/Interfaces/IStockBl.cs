using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Common.Dto;
using Trading.Common.Dto.Pagination;

namespace Trading.Business.Logic.Interfaces
{
    public interface IStockBl
    {
        public Task<PagedResponseDto<IEnumerable<StockDto>>> GetAll(PaginationFilterDto paginationFilter);
    }
}
