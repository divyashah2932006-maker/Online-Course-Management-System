using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db) { _db = db; }
public IActionResult ApiDemo() => View();
        // READ + SEARCH
        [AllowAnonymous]
        public async Task<IActionResult> Index(string? search)
        {
            var q = _db.Courses.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
                q = q.Where(c => c.Title.Contains(search) || c.Instructor.Contains(search) || c.Category.Contains(search));
            ViewBag.Search = search;
            return View(await q.OrderBy(c => c.CourseId).ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            return c == null ? NotFound() : View(c);
        }

        // CREATE
        public IActionResult Create() => View(new Course());

        [HttpPost]
        public async Task<IActionResult> Create(Course c)
        {
            if (!ModelState.IsValid) return View(c);
            _db.Courses.Add(c);
            await _db.SaveChangesAsync();
            TempData["Msg"] = "Course added successfully";
            return RedirectToAction(nameof(Index));
        }

        // UPDATE
        public async Task<IActionResult> Edit(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            return c == null ? NotFound() : View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course c)
        {
            if (id != c.CourseId) return BadRequest();
            if (!ModelState.IsValid) return View(c);
            _db.Update(c);
            await _db.SaveChangesAsync();
            TempData["Msg"] = "Course updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            return c == null ? NotFound() : View(c);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            if (c != null)
            {
                _db.Courses.Remove(c);
                await _db.SaveChangesAsync();
                TempData["Msg"] = "Course deleted";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}