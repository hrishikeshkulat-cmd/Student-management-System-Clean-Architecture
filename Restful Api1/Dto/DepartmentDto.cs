using System.ComponentModel.DataAnnotations;

namespace Restful_Api1.Dto
{
    public class DepartmentDto
    {

        [Required]
        [MaxLength(100)]
        public string? DepartmentName { get; set; } = null!;

    }
}
