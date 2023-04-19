using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDDD.Domain.Entities
{
    public class PortfolioEntity
    {
        public int Amount { get; set; }
        public int BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public StockEntity? Stock { get; set; }
    }
}
