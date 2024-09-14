using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workers_tabs.DTOs.Def
{
    public class CreateDefRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Symbol must be at least 2 characters long")]
        [MaxLength(10, ErrorMessage = "Symbol must be at most 10 characters long")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "CompanyName must be at least 2 characters long")]
        [MaxLength(10, ErrorMessage = "CompanyName must be at most 10 characters long")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000, ErrorMessage = "Purchase must be between 1 and 1000000")]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.01, 100, ErrorMessage = "LastDiv must be between 0.01 and 100")]
        public decimal LastDiv { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Industry must be at least 2 characters long")]
        [MaxLength(10, ErrorMessage = "Industry must be at most 10 characters long")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 5000000000, ErrorMessage = "MarketCap must be between 1 and 5000000000")]
        public long MarketCap { get; set; }
    }
}