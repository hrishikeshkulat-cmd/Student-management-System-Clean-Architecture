using Restful_Api1.Dto;
using Restful_Api1.Models;

namespace Restful_Api1.Service
{
    public interface IEnrollmentService
    {

        Task<bool> EnrollmentExistsAsync(EnrollStudentDto dto);
        Task<bool> UnenrollStudentAsync(int studentId, int courseId);

        Task<List<CourseDto>> GetCoursesForStudentAsync(int studentId);
        Task<List<StudentDto>> GetStudentsForCourseAsync(int courseId);


    }
}
