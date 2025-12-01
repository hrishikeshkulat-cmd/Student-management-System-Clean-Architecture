using System.ComponentModel.DataAnnotations;

namespace Restful_Api1.Models
{
    public class StudentDto
    {
        [Required(ErrorMessage = "Name is required")]

        public string? Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }



    }
}
