using Microsoft.EntityFrameworkCore;
using Restful_Api1.Models;

namespace Restful_Api1.Repositories
{


    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        // CHECK if enrollment exists
        public async Task<bool> EnrollmentExistsAsync(int studentId, int courseId)
        {
            return await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        // ADD enrollment
        public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        // REMOVE enrollment
        public async Task<bool> RemoveEnrollmentAsync(int studentId, int courseId)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment == null)
                return false;

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        // GET courses for a student
        public async Task<List<Course>> GetCoursesForStudentAsync(int studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .Select(e => e.Course)
                .AsNoTracking()
                .ToListAsync();
        }

        // GET students for a course
        public async Task<List<Student>> GetStudentsForCourseAsync(int courseId)
        {
            return await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Include(e => e.Student)
                .Select(e => e.Student)
                .AsNoTracking()
                .ToListAsync();
        }
    }

}

