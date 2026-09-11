using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class DashboardStats
    {
        public int TotalStudents { get; set; }
        public int TotalPrograms { get; set; }
        public int EnrolledToday { get; set; }
        public string TopProgram { get; set; } = "None";
        public Dictionary<string, int> ProgramDistribution { get; set; } = new();
        public Dictionary<string, int> GenderDistribution { get; set; } = new();
        public Dictionary<string, int> YearLevelDistribution { get; set; } = new();
    }
}
