using Restful_Api1.Dto;
using Restful_Api1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restful_Api1.Service
{
   
    public interface IDepartmentService
    {
        Task<Department> CreateDepartmentAsync(DepartmentDto dto);

        Task<List<Department>> GetAllDepartmentsAsync();

        Task<Department?> GetDepartmentByIdAsync(int id);

    }
}
