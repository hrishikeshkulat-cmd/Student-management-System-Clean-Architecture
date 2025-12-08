using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Repositories;
using System.Threading.Tasks;

namespace Restful_Api1.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _deptRepository;

        public DepartmentService(IDepartmentRepository deptRepository)
        {
            _deptRepository = deptRepository;
        }



        public async   Task<Department> CreateDepartmentAsync(DepartmentDto dto)
        {

            var name = dto.DepartmentName?.Trim();
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Department name cannot be empty",nameof(dto.DepartmentName));
            }

            var department = await _deptRepository.CreateDepartmentAsync(new DepartmentDto { DepartmentName = name });
            return department;
        }

      public async  Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _deptRepository.GetAllDepartmentsAsync();
        }

       public async  Task<Department?> GetDepartmentByIdAsync(int id)
        {
            var department = await _deptRepository.GetDepartmentByIdAsync(id);

            if(department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }
            return department;


        }






    }
}
