using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers_tabs.Queries
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;

        public string? CompanyName { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;
    }
}