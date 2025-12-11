namespace Restful_Api1.Models
{
    public class Student
    {
        public int  Id { get; set; }
        public string ? Name  { get; set; }

        public int Age { get; set; }


        // One-to-one navigation to StudentAddress

        public StudentAddress? Address { get; set; }
        // Many-to-one navigation to Department

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; } 
    }
}
