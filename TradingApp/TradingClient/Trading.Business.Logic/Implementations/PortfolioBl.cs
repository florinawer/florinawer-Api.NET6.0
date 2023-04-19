using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Trading.Business.Logic.Interfaces;
using Trading.Common.Dto;

namespace Trading.Business.Logic.Implementations
{
    public class PortfolioBl : IPortfolioBl
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PortfolioBl(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<PortfolioDto>> GetAll()
        {
            var baseurl = _configuration.GetConnectionString("BaseUrl");
            _httpClient.BaseAddress = new Uri(baseurl);
            var httpResponse = await _httpClient.GetFromJsonAsync<IEnumerable<PortfolioDto>>("api/Portfolio");
            return httpResponse;
        }

        public async Task<PortfolioDto> Add(PortfolioDto portfolioDto)
        {
            var baseurl = _configuration.GetConnectionString("BaseUrl");
            _httpClient.BaseAddress = new Uri(baseurl);
            var insertedPortfolio = new StringContent(
                JsonConvert.SerializeObject(portfolioDto),
                Encoding.UTF8,
                "application/json");
            var httpResponse =
               await _httpClient.PostAsync($"api/Portfolio", insertedPortfolio);
            var result = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PortfolioDto>(result);
        }
    }
}
