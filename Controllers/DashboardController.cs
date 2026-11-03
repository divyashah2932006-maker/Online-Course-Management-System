using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        public DashboardController(AppDbContext db) { _db = db; }

        public async Task<IActionResult> Index()
        {
            var vm = new DashboardViewModel
            {
                TotalCourses = await _db.Courses.CountAsync(),
                TotalEnrollments = await _db.Enrollments.CountAsync(),
                Recent = await _db.Enrollments
                            .OrderByDescending(e => e.EnrolledOn)
                            .Take(5).ToListAsync()
            };
            return View(vm);
        }
    }
}