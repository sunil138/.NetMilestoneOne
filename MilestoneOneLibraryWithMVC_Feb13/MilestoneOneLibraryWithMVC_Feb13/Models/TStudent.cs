using System;
using System.Collections.Generic;

namespace MilestoneOneLibraryWithMVC_Feb13.Models
{
    public partial class TStudent
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int? StudentAge { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }
    }
}
