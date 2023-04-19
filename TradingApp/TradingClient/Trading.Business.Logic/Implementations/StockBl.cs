using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Trading.Business.Logic.Interfaces;
using Trading.Common.Dto;
using Trading.Common.Dto.Pagination;

namespace Trading.Business.Logic.Implementations
{
    public class StockBl : IStockBl
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public StockBl(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<PagedResponseDto<IEnumerable<StockDto>>> GetAll(PaginationFilterDto paginationFilter)
        {
            var baseurl = _configuration.GetConnectionString("BaseUrl");
            _httpClient.BaseAddress = new Uri(baseurl);
            var httpResponse = await _httpClient.GetFromJsonAsync<PagedResponseDto<IEnumerable<StockDto>>>($"api/Stock/Pagination?pageNumber={paginationFilter.PageNumber}&pageSize={paginationFilter.PageSize}");
            return httpResponse;
        }
    }
}
