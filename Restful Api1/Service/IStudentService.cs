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
        Task<List<Student>> FilterAsync(int? minAge, int? maxAge);

        Task<List<Student>> AdvancedFilterAsync(string? name, int? minAge, int? maxAge);

        Task<List<Student>> SortAsync(string orderBy, string direction);
        Task<List<Student>> SearchAsync(string? search);




    }
}
