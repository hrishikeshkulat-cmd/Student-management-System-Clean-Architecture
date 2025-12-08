using System.ComponentModel.DataAnnotations;

namespace Restful_Api1.Dto
{
    public class UpdateStudentDto
    {
        [Required]
        public string? Name { get; set; }
        [Range(1,100)]
        public int Age { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
