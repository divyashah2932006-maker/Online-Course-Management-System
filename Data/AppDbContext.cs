using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "C# Programming Basics", Instructor = "Rahul Mehta", Category = "Programming", DurationWeeks = 6, Fee = 2999, Description = "Learn C# from scratch." },
                new Course { CourseId = 2, Title = "ASP.NET Core MVC", Instructor = "Neha Shah", Category = "Web Development", DurationWeeks = 8, Fee = 4999, Description = "Build web apps with ASP.NET Core." },
                new Course { CourseId = 3, Title = "SQL Server Essentials", Instructor = "Amit Joshi", Category = "Database", DurationWeeks = 5, Fee = 2499, Description = "Queries, joins and design." }
            );
        }
    }
}