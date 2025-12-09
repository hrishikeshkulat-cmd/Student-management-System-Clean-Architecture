using Microsoft.AspNetCore.Mvc;
using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Service;

namespace Restful_Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _course;

        public CourseController(ICourseService course)
        {
            _course = course;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCourseDto course)
        {
            //framework level validaton
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //Repositories/services level validation (logic validation)
            var createdCourse = await _course.CreateAsync(course);
            if (createdCourse == null)
            {
                return BadRequest("Course is not added");
            }

            return Ok(createdCourse);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {


            var result = await _course.GetByIdAsync(id);
            if(result == null)
            {
                return NotFound($"Course with id {id} not found.");
            }


            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _course.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateCourseDto course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = await _course.UpdateAsync(id, course);
            if (!isUpdated)
            {
                return NotFound($"Course with id {id} not found.");
            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var IsDeleted = await _course.DeleteAsync (id);

            return NoContent();
        }



    }
}
