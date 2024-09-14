using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workers_tabs.DTOs
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "Title must be at most 50 characters long")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "Title must be at most 50 characters long")]
        public string Content { get; set; } = string.Empty;
    }
}