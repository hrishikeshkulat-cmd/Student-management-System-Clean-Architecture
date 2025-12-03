using Microsoft.AspNetCore.Mvc;
using Restful_Api1.Models;
using Restful_Api1.Service;
using System.Security.AccessControl;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<IActionResult> GETAll()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var stud = await _studentService.GetByIdAsync(id);
            if (stud == null)
                return NotFound("id not found");

            return Ok(stud);

        }

        [HttpPost("create")]
        public async Task<IActionResult> Added(StudentDto stud)
        {
            var Student = new Student()
            {
                Name = stud.Name,
                Age = stud.Age

            };


            var created = await _studentService.AddAsync(Student);
            return Created("", created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatestd(int id, StudentDto dto)
        {
            var hk = await _studentService.UpdateAsync(id, dto);
            if (!hk)
                return NotFound();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var del = await _studentService.DeleteAsync(id);
            if (!del) return NotFound("not deleted");
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<ActionResult> Filter([FromQuery] int? minAge, [FromQuery] int? maxAge)
        {

            var list = await _studentService.FilterAsync(minAge, maxAge);
            return Ok (list);
        }

        [HttpGet("multisearch")]
      public async Task<IActionResult> AdvancedFilterAsync([FromQuery]string? name, [FromQuery] int? minAge, [FromQuery] int? maxAge)
        {
            var multi= await _studentService.AdvancedFilterAsync(name, minAge, maxAge);
            return Ok(multi);
        }


        [HttpGet("sorting")]

      public async  Task<IActionResult> SortAsync(string orderBy, string direction)
        {
            var hk= await _studentService.SortAsync(orderBy, direction);
            return Ok(hk);
        }

        [HttpGet("searching")]

       public async Task<IActionResult> SearchAsync(string? search)
        {
            var hk = await _studentService.SearchAsync(search);
            return Ok(hk);
        }



    }

}



    
