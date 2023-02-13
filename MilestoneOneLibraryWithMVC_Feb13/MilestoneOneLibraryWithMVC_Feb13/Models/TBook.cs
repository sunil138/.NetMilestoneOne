using System;
using System.Collections.Generic;

namespace MilestoneOneLibraryWithMVC_Feb13.Models
{
    public partial class TBook
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? BookPageCount { get; set; }
        public int? AuthorId { get; set; }

    }
}
