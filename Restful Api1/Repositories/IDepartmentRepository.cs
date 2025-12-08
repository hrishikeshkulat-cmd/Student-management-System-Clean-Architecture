using Restful_Api1.Dto;
using Restful_Api1.Models;

namespace Restful_Api1.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartmentAsync(DepartmentDto dto);

        Task<List<Department>> GetAllDepartmentsAsync();

        Task <Department?>GetDepartmentByIdAsync(int id);


    }
}
