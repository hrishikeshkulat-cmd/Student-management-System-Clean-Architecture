using Restful_Api1.Models;

namespace Restful_Api1.Repositories
{
    public interface IEnrollmentRepository
    {

            Task<bool> EnrollmentExistsAsync(int studentId, int courseId);

            Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);
            Task<bool> RemoveEnrollmentAsync(int studentId, int courseId);

            Task<List<Course>> GetCoursesForStudentAsync(int studentId);
            Task<List<Student>> GetStudentsForCourseAsync(int courseId);
        


    }
}
