using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers_tabs.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now.ToUniversalTime(); // для postgresql только так, для MS SQL Server можно DateTime.Now
        public int? DefId { get; set; }
    }
}