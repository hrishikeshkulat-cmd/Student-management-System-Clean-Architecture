using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Restful_Api1.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }= null!;

        public List<Student>? Students { get; set; }


    }
}
