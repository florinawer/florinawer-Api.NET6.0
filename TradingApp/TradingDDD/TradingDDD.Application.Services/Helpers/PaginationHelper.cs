using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Application.Services.Interfaces;
using TradingDDD.Domain.Entities;
using TradingDDD.Domain.Entities.Pagination;

namespace TradingDDD.Application.Services.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponseEntity<List<StockEntity>> CreatePagedReponse(List<StockEntity> pagedData, PaginationFilterEntity paginationFilter, int totalRecords, IUriService uriService, string route)
        {
            var response = new PagedResponseEntity<List<StockEntity>>(pagedData, paginationFilter.PageNumber, paginationFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)paginationFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            response.NextPage =
                paginationFilter.PageNumber >= 1 && paginationFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilterEntity(paginationFilter.PageNumber + 1, paginationFilter.PageSize), route)
                : null;
            response.PreviousPage =
                paginationFilter.PageNumber - 1 >= 1 && paginationFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilterEntity(paginationFilter.PageNumber - 1, paginationFilter.PageSize), route)
                : null;
            response.FirstPage = uriService.GetPageUri(new PaginationFilterEntity(1, paginationFilter.PageSize), route);
            response.LastPage = uriService.GetPageUri(new PaginationFilterEntity(roundedTotalPages, paginationFilter.PageSize), route);
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            return response;
        }
    }
}
