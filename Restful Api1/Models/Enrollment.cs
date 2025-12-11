namespace Restful_Api1.Models
{
    public class Enrollment
    {
          // Composite key (StudentId + CourseId) will be configured in DbContext fluent API
            public int StudentId { get; set; }
            public Student Student { get; set; } = null!;

            public int CourseId { get; set; }
            public Course Course { get; set; } = null!;

            // Extra fields for realism (nullable for now)
            public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;
            public string? Grade { get; set; }
        
    }
}
