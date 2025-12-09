using Restful_Api1.Dto;

namespace Restful_Api1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; }

        internal static object Select(Func<object, CourseDto> value)
        {
            throw new NotImplementedException();
        }


        //joining property
        // public ICollection<Enrollment>?Enrollments { get; set; } 
    }
}
