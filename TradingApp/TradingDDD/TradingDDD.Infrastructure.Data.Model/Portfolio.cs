using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDDD.Infrastructure.Data.Model
{
    public class Portfolio
    { 
        public int Id { get; set; }
        public int Amount { get; set; }
        public int BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public int StockId { get; set; }
        public Stock? Stock { get; set; }
    }
}

