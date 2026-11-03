using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;
    public HomeController(ILogger<HomeController> logger, AppDbContext db) { _logger = logger; _db = db; }

    public async Task<IActionResult> Index()
    {
        ViewBag.FeaturedCourses = await _db.Courses.OrderBy(c => c.CourseId).Take(6).ToListAsync();
        ViewBag.CourseCount = await _db.Courses.CountAsync();
        ViewBag.CategoryCount = await _db.Courses.Select(c => c.Category).Distinct().CountAsync();
        return View();
    }
    public IActionResult Privacy() => View();
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
