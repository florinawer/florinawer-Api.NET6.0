using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Infrastructure.Data.Model;

namespace TradingDDD.Domain.Entities
{
    public class StockEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
    }
}
