using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers_tabs.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? DefId { get; set; }

        public Def? Base { get; set; }
    }
}