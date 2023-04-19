using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDDD.Infrastructure.Data.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
    }
}

