using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CoursesApiController(AppDbContext db) { _db = db; }

        // GET api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
            => await _db.Courses.ToListAsync();

        // GET api/courses/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            return c == null ? NotFound() : c;
        }

        // POST api/courses
        [HttpPost]
        public async Task<ActionResult<Course>> Post(Course c)
        {
            _db.Courses.Add(c);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = c.CourseId }, c);
        }

        // PUT api/courses/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Course c)
        {
            if (id != c.CourseId) return BadRequest();
            if (!await _db.Courses.AnyAsync(x => x.CourseId == id)) return NotFound();
            _db.Entry(c).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/courses/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            if (c == null) return NotFound();
            _db.Courses.Remove(c);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}