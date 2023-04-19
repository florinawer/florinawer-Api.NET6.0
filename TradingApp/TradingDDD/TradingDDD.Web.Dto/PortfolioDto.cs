using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TradingDDD.Web.Dto
{
    public class PortfolioDto
    {
        public int Amount { get; set; }
        public int BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public StockDto? Stock { get; set; }
    }
}
