using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("list")]
        public IActionResult GETAll()
        {
            return Ok(_studentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public IActionResult getbyid(int id)
        {
            var stud = _studentService.GetByIdAsync( id);
            if (stud == null)
                return NotFound("id not found");

            return Ok(stud);

        }

        [HttpPost("create")]
        public IActionResult Added(Student student)
        {
            _studentService.AddAsync( student);
            return Created("", student);
        }

        [HttpPut("{id}")]
        public IActionResult updatestd(int id, StudentDto dto)
        {
            var hk=_studentService.UpdateAsync( id, dto);
            if (hk==null)
                return NotFound();

            return NoContent();

        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var del=_studentService.DeleteAsync(id);
            if(del==null) return NotFound("not deleted");
            return NoContent();
        }


    }
}