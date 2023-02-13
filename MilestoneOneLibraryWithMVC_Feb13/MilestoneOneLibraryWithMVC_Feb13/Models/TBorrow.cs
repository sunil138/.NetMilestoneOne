using System;
using System.Collections.Generic;

namespace MilestoneOneLibraryWithMVC_Feb13.Models
{
    public partial class TBorrow
    {
        public int BorrowId { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? BookId { get; set; }
        public int? StudentId { get; set; }
    }
}
