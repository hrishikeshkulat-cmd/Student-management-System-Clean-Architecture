namespace Restful_Api1.Dto
{
    public class EnrollmentDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledOn { get; set; }
        public string? Grade { get; set; }

    }
}
