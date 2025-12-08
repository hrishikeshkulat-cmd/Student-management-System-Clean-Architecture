using Microsoft.AspNetCore.Mvc;
using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Service;

namespace Restful_Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
      public async   Task<IActionResult> GetAllStudents([FromQuery]StudentQueryParameters parameters)

        {
            var hk = await _studentService.GetAllStudentsWithQueryAsync(parameters);
            return Ok(hk);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var stud = await _studentService.GetByIdAsync(id);
            if (stud == null)
                return NotFound("id not found");

            return Ok(stud);

        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdStudent = await _studentService.CreateStudentAsync(dto);
            if (createdStudent == null)
            {
                return BadRequest("Invalid Department ID");
            }
            return Ok(createdStudent);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdStudent = await _studentService.UpdateStudentAsync(id, dto);

            if (!createdStudent)
            {
                return NotFound("Student not found");
            }
            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {

            var del = await _studentService.DeleteStudentAsync(id);

            if (!del)
            {
                return NotFound("Student not found");
            }
            return NoContent();

        }

        [HttpGet("{id}/with-department")]
        public async Task<IActionResult> GetByIdWithDepartmentAsync(int id)
        {
            var dto=await _studentService.GetByIdWithDepartmentAsync(id);
            if(dto== null)
                return NotFound("id not found");

            return Ok(dto);

        }




    }

}




