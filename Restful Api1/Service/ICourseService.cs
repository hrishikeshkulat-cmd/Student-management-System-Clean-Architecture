using Restful_Api1.Dto;
using Restful_Api1.Models;

namespace Restful_Api1.Service
{
    public interface ICourseService
    {
        Task<CourseDto> CreateAsync(CreateCourseDto course);

        Task<CourseDto?> GetByIdAsync(int id);

        Task<List<CourseDto>> GetAllAsync();

        Task <bool> UpdateAsync(int id,UpdateCourseDto course);

        Task<bool> DeleteAsync(int id);



    }
}
