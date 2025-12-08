using Restful_Api1.Dto;
using Restful_Api1.Models;

namespace Restful_Api1.Service
{
    public interface IStudentService
    {

        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);

        Task<Student?> CreateStudentAsync(CreateStudentDto dto);

        Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto);

        Task<bool> DeleteStudentAsync(int id);

        Task<StudentWithDepartmentDto?> GetByIdWithDepartmentAsync(int id);

        Task<List<object>> GetAllStudentsWithQueryAsync(StudentQueryParameters parameters);

    }
}
