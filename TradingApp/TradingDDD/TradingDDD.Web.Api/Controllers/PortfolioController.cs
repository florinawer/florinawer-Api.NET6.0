using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TradingDDD.Application.Services.Interfaces;
using TradingDDD.Domain.Entities;
using TradingDDD.Web.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingDDD.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public PortfolioController(IPortfolioService portfolioService, IMapper mapper)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
        }

        // GET: api/<PortfolioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _mapper.Map<List<PortfolioDto>>(await _portfolioService.GetAllAsync());
            return Ok(result);
        }

        // GET api/<PortfolioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _mapper.Map<PortfolioDto>(await _portfolioService.GetByIdAsync(id));
            return Ok(result);
        }

        // POST api/<PortfolioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PortfolioDto portfolioDto)
        {
            var result = _mapper.Map<PortfolioDto>(await _portfolioService.InsertAsync(_mapper.Map<PortfolioEntity>(portfolioDto)));
            return Ok(result);
        }


    }
}
