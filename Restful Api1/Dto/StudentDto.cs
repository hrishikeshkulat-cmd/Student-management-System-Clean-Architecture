namespace Restful_Api1.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int? DepartmentId { get; set; }
    }
}