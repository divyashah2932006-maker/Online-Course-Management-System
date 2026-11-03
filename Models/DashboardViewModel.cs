namespace OnlineCourseManagement.Models
{
    public class DashboardViewModel
    {
        public int TotalCourses { get; set; }
        public int TotalEnrollments { get; set; }
        public List<Enrollment> Recent { get; set; } = new();
    }
}