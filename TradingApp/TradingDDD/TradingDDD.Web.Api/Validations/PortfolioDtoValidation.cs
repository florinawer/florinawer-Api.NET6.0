using FluentValidation;
using TradingDDD.Web.Dto;

namespace TradingDDD.Web.Api.Validations
{
    public class PortfolioDtoValidation : AbstractValidator<PortfolioDto>
    {
        public PortfolioDtoValidation()
        {
            RuleFor(p => p.Amount).NotEmpty();
            RuleFor(p => p.BuyPrice).NotEmpty();
            RuleFor(p => p.BuyDate).NotEmpty();
            RuleFor(p => p.Stock).NotEmpty();
        }
    }
}
