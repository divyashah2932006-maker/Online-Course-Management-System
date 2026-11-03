using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext _db;
        public EnrollmentController(AppDbContext db) { _db = db; }

        private void LoadCourses()
        {
            ViewBag.Courses = new SelectList(_db.Courses.ToList(), "CourseId", "Title");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Create(int? courseId)
        {
            LoadCourses();
            return View(new Enrollment { CourseId = courseId ?? 0 });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(Enrollment e)
        {
            if (!ModelState.IsValid)
            {
                LoadCourses();
                return View(e);
            }
            e.EnrolledOn = DateTime.Now;
            _db.Enrollments.Add(e);
            await _db.SaveChangesAsync();
            return RedirectToAction("Success");
        }

        [AllowAnonymous]
        public IActionResult Success() => View();

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = await _db.Enrollments.Include(x => x.Course)
                                .OrderByDescending(x => x.EnrolledOn).ToListAsync();
            return View(list);
        }
    }
}
