using Restful_Api1.Dto;
using Restful_Api1.Models;
using Microsoft.EntityFrameworkCore;

namespace Restful_Api1.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }



        public async  Task<Department> CreateDepartmentAsync(DepartmentDto dto)
        {
             // Implementation for creating a department
              var department= new Department
              {
                DepartmentName = dto.DepartmentName
              };

             _context.Departments.Add(department);

            await  _context.SaveChangesAsync();
            
            return department;

        }
       public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

      public async   Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);


        }


    }
}
