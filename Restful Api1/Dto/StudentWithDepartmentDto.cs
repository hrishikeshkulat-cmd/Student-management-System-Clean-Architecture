namespace Restful_Api1.Dto
{
    public class StudentWithDepartmentDto
    {

        public int Id { get; set; }
        public string? Name { get; set; } = null!;

        public int Age { get; set; }


        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

    }
}
