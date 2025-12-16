using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful_Api1.Dto;
using Restful_Api1.Service;

namespace Restful_Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _eservice;

        public EnrollmentController(IEnrollmentService eservice)
        {
           _eservice = eservice;

        }

        [HttpPost]
        public async  Task<IActionResult> EnrollmentExistsAsync(EnrollStudentDto dto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var enroll =await  _eservice.EnrollmentExistsAsync(dto);

            if(!enroll)
            {
                return BadRequest("Enrollment failed. Student/Course may not exist or already enrolled");
            }

            return Ok("Student enrolled successfully.");

        }
        [HttpDelete("{studentId:int}/{courseId:int}")]
        public async Task<IActionResult> UnenrollStudentAsync(int studentId, int courseId)
        {
          

            var unroll = await  _eservice.UnenrollStudentAsync(studentId, courseId);

            if (!unroll)
            {
                return NotFound("student not found");
            }

            return NoContent();

        }


        [HttpGet("Student/{studentId:int}/Course")]
      public   async Task<IActionResult> GetCoursesForStudentAsync(int studentId)
        {
            var Getcourse = await  _eservice.GetCoursesForStudentAsync(studentId);

            return Ok(Getcourse);
            
             
        }

        [HttpGet("Course/{courseId:int}/Student")]
       public async Task<IActionResult>GetStudentsForCourseAsync(int courseId)
        {
            var Getstudent= await _eservice.GetStudentsForCourseAsync(courseId);
            return Ok(Getstudent);
        }





    }
}
