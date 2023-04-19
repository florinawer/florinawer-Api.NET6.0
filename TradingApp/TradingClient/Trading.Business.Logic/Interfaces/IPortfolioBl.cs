using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Common.Dto;

namespace Trading.Business.Logic.Interfaces
{
    public interface IPortfolioBl
    {
        public Task<IEnumerable<PortfolioDto>> GetAll();

        public Task<PortfolioDto> Add(PortfolioDto portfolioDto);
    }
}
