using backend.Data;
using backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var course= await _context.Course.ToListAsync();

            return Ok(course);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course is null)
                return NotFound("course not found");
            return Ok(course);
        }
        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }
        [HttpPut]
        public async Task<ActionResult<Course>> UpdateCourse(Course course)
        {
            var updatedCourse = await _context.Course.FindAsync(course.Id);
            if (updatedCourse is null)
                return NotFound("course not found");
            updatedCourse.courseName = course.courseName;
            updatedCourse.courseCode = course.courseCode;
            await _context.SaveChangesAsync();
            return Ok(updatedCourse);
        }
        [HttpDelete]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course is null)
                return NotFound("course not found");
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return Ok(course);
        }
    }
}
