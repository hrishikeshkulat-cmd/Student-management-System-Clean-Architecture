using Restful_Api1.Models;

namespace Restful_Api1.Service
{
    public interface IStudentService
    {

        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(Student student);
        Task<bool> UpdateAsync(int id, StudentDto dto);
        Task<bool> DeleteAsync(int id);


    }
}
