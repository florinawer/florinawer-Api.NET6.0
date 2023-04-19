using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDDD.Domain.Entities
{
    public class EmailEntity
    {
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
