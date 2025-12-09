using Restful_Api1.Models;
using Microsoft.EntityFrameworkCore;

namespace Restful_Api1.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<Course> CreateAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;

        }
        public async Task<Course?> GetByIdAsync(int id)
        {
             var course= await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
             return  course;

        }

       public async  Task<List<Course>> GetAllAsync()
        {
          return await _context.Courses.ToListAsync();
            


        }

       public async Task UpdateAsync(Course course)
        {

             _context.Courses.Update(course);
            await _context.SaveChangesAsync();
           


        }

      public async   Task DeleteAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }








    }
}
