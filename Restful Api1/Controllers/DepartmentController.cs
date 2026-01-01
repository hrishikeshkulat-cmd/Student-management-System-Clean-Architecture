using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Repositories;
using Restful_Api1.Service;
namespace Restful_Api1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _deptService;

        public DepartmentController(IDepartmentService deptService)
        {
            _deptService = deptService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartmentAsync(DepartmentDto dto)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = await _deptService.CreateDepartmentAsync(dto);
            return Ok(department);
        }

        [HttpGet]
       public async  Task<IActionResult> GetAllDepartmentsAsync()
        {
            var hk= await _deptService.GetAllDepartmentsAsync();
            return Ok (hk);
        }
        [HttpGet("{id}")]
       public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            var hk = await _deptService.GetDepartmentByIdAsync(id);
            return Ok(hk);

        }


    }

}
