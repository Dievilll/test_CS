using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers_tabs.DTOs.Def
{
    public class UpdateDefRequestDto
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}