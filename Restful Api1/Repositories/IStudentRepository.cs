using Restful_Api1.Dto;
using Restful_Api1.Models;

namespace Restful_Api1.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);

        Task<Student?> CreateStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto);
        Task<bool> DeleteStudentAsync(int id);

        Task<Student?> GetByIdWithDepartmentAsync(int id);

        Task<List<Student>> GetAllWithQueryAsync(StudentQueryParameters parameters);

    }
}
