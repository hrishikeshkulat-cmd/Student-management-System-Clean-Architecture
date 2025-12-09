using Restful_Api1.Models;

namespace Restful_Api1.Repositories
{
    public interface ICourseRepository
    {

        Task<Course> CreateAsync(Course course);
        Task<Course?> GetByIdAsync(int id);
        Task<List<Course>> GetAllAsync();
        Task UpdateAsync(Course course);
        Task DeleteAsync(Course course);


    }
}
