using Devanshi_Kapadia1_InClassApi.Dtos;
using Devanshi_Kapadia1_InClassApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devanshi_Kapadia1_InClassApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetCourseByName/{courseName}")]
        public async Task<ActionResult<CourseDto>> GetCourseByName(string courseName)
        {
            var course = await _courseService.GetCourseByName(courseName);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpGet("GetAllCourses")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpPut("UpdateCourse")]
        public async Task<IActionResult> UpdateCourse(CourseDto courseDto)
        {
            await _courseService.UpdateCourse(courseDto);
            return NoContent();
        }
    }
}
