using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TradingDDD.Application.Services.Interfaces;
using TradingDDD.Domain.Entities.Pagination;
using TradingDDD.Web.Dto;
using TradingDDD.Web.Dto.Pagination;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingDDD.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _iStockService;
        private readonly IMapper _mapper;

        public StockController(IStockService iStockService, IMapper mapper)
        {
            _iStockService = iStockService;
            _mapper = mapper;
        }

        // GET: api/<StockController>
        [HttpGet("Pagination")]
        public async Task<IActionResult> Get([FromQuery] PaginationFilterDto filter)
        {
            var route = Request.Path.Value;

            var result = _mapper.Map<PagedResponseDto<List<StockDto>>>(await _iStockService.GetAllAsync(_mapper.Map<PaginationFilterEntity>(filter), route));
            return Ok(result);
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _mapper.Map<StockDto>(await _iStockService.GetByIdAsync(id));
            return Ok(result);
        }
    }
}
