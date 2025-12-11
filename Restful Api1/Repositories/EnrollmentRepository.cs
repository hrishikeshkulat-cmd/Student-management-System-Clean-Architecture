using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Restful_Api1.Repositories
{
    public class EnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }


        public async  Task<bool> EnrollmentExistsAsync(int studentId, int courseId)
        {
             var exist =await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

        }
         
        public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
        {
              _contrxt.enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }



       public async  Task<bool> RemoveEnrollmentAsync(int studentId, int courseId)
        {
            var hk= await  _context.Enrollments.firstorDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);
            if(hk == null) return false;
            _context.Enrollments.Remove(hk);
            await _context.SaveChangesAsync();
            return true;
        }

       public async  Task<List<Course>> GetCoursesForStudentAsync(int studentId)
        {

            return await _context.Enrollments
                .where(e => e.StudentId == studentId)
                .include(e => e.Course)
                .select(e => e.Course)
                .ToListasync();

        }
       
        public async Task<List<Student>> GetStudentsForCourseAsync(int courseId)
        {
            

        }






    }
}
